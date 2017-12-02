# LINQ to HL7

&lt;intro here&gt;

**Challenge: **Assume that you needed to extract all the tests from a lab order and return a single object given the below HL7 message.

Imagine that you are building a lab orders intake system. Your system should be able to extract certain information from an ORM O01 HL7 message \(see below HL7\) such as order number \(ORC-2\), order group number \(ORC-4\), to save the order. A order \(i.e. the ORM message\) may come with one or more tests \(i.e. ORC/OBR combinations\) to be performed by the lab.

```
MSH|^~\&|MACHETELAB|^DOSC|MACHETE|18779|20130405125146269||ORM^O01|1999077678|P|2.3|||AL|AL
PID|1|000000000026|60043^^^MACHETE^MRN||MACHETE^JOE||19890909|F|||123 SEASAME STREET^^Oakland^CA^94600||5101234567|5101234567||||||||||||||||N
PD1|M|F|N||||F|
PV1|1|O|||||92383^Machete^Janice||||||||||||12345|||||||||||||||||||||||||201304051104
PV2||||||||20150615|20150616|1||||||||||||||||||||||||||N
IN1|1|||MACHETE INC|1234 Fruitvale ave^^Oakland^CA^94601^USA||5101234567^^^^^510^1234567|074394|||||||A1|MACHETE^JOE||19890909|123 SEASAME STREET^^Oakland^CA^94600||||||||||||N|||||666889999|0||||||F||||T||60043^^^MACHETE^MRN
GT1|1|60043^^^MACHETE^MRN|MACHETE^JOE||123 SEASAME STREET^^Oakland^CA^94600|5416666666|5418888888|19890909|F|P
AL1|1|FA|^pollen allergy|SV|jalubu daggu||
ORC|NW|PRO2350||XO934N|||^^^^^R||20130405125144|91238^Machete^Joe||92383^Machete^Janice
OBR|1|PRO2350||11636^Urinalysis, with Culture if Indicated^L|||20130405135133||||N|||||92383^Machete^Janice|||||||||||^^^^^R
DG1|1|I9|788.64^URINARY HESITANCY^I9|URINARY HESITANCY
ORC|NW|PRO2351||XO934N|||^^^^^R||20130405125144|91238^Machete^Joe||92383^Machete^Janice
OBR|1|PRO2350||11637^Urinalysis, with Culture if Indicated^L|||20130405135133||||N|||||92383^Machete^Janice|||||||||||^^^^^R
DG1|1|I9|788.64^URINARY HESITANCY^I9|URINARY HESITANCY
ORC|NW|PRO2352||XO934N|||^^^^^R||20130405125144|91238^Machete^Joe||92383^Machete^Janice
OBR|1|PRO2350||11638^Urinalysis, with Culture if Indicated^L|||20130405135133||||N|||||92383^Machete^Janice|||||||||||^^^^^R
DG1|1|I9|788.64^URINARY HESITANCY^I9|URINARY HESITANCY
```

How would you approach this problem with your current parser? Let me quess, you'd probably write a couple loop statements to iterate over the message and some conditional statements to determine if you have the correct segments and determine when to start grabbing the next block of segments that you need. Am I getting warm? If you've been in healthcare for any length of time, this is just how things are, that is, before Machete.

Imagine if you could write an expressive LINQ query like this...

```csharp
var result = parse.Query(query =>
{
    var obxQuery = from obx in query.Select<OBX>()
        from nte in query.Select<NTE>().ZeroOrMore()
        select new
        {
            OBX = obx,
            NTE = nte
        };

    var obrQuery = from obr in query.Select<OBR>()
        from dg1 in query.Select<DG1>().Optional()
        select new
        {
            OBR = obr,
            DG1 = dg1
        };

    var testQuery = from orc in query.Select<ORC>()
        from obr in obrQuery.ZeroOrMore()
        select new
        {
            ORC = orc,
            OBR = obr
        };

    return from msh in query.Select<MSH>()
        from pid in query.Select<PID>()
        from skip in query.Except<HL7Segment, ORC>().ZeroOrMore()
        from tests in testQuery.ZeroOrMore()
        select new
        {
            MSH = msh,
            PID = pid,
            Tests = tests
        };
});
```

There is quite a bit to unpack here, so let's go over the steps that are needed to perform the above task.

1. Call the _Query_ extension method off of the parse, _EntityResult&lt;HL7Entity&gt;_ to set up the query.
2. Instruct the parser which entities to select from the source document structure in the order in which you expect them to appear. This is accomplished by calling the method _Select&lt;TEntity&gt;_ off of the _IQueryBuilder&lt;TSchema&gt;_ projection \(e.g. _query_\).
3. Indicate the number of expected entities \(e.g. segments\) for which the parser should expect to parse. This is accomplished by calling extension methods \(e.g. _Optional_, _ZeroOrMore_, etc.\) that hang off of the _Select&lt;TEntity&gt;_ method.
4. Return the final query.

The caveat to all of this LINQ Kung Fu is that your query must be reflective of the document structure in order for it to execute. Take a look at the return statement, what you'll notice is that there are a couple variables, _msh_ and _skip_, that are not returned in the final anonymous object. These statements are meant to inform the parser to bypass the specified entities when it encounters them during parsing. Remember, the parser's cursor cannot move backwards, which means that your query may have to select entities for which it will never return let alone use.

Hmm, all this Kung Fu just to return a list of POCO objects? Big deal, right? Perhaps if you are new to healthcare this wouldn't be all that exciting, after all, you're probably already use to querying over complex data. However, if you are an industry veteran then you are smiling right about now because you know all to well that in order to perform the above task you are usually faced with writing perhaps hundred lines of code.

