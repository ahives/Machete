# Querying Document Structures

&lt;say something cool here&gt;

The query engine is the center of the universe when it comes to data access in Machete. This is in stark contrast to conventional data processing APIs. Historically, there has been a thin layer of abstraction between calling applications and the mechanisms used to actually parse and return data. The reason for this is that

#### It's better to Query

Think back to when you first started using C\#, were you happy without LINQ and lambdas? Were you happy with the performance of walking the document structure? Were you happy with writing the same code over and over to iterate in memory collections? I mean, life was good, right? Even after when LINQ became a thing, your favorite parser still little to no native support. If your parser returned a collection surely you could use LINQ to query over it. This means that the parser is tightly coupled to the document structure. Who cares, right? As long as my application can get the job done and doesn't blow up, I'm good. Right? True, but, what if you could adapt the parser to the data. That would not just be cool, but, it would be extremely useful. If you have built any backend healthcare data processing systems you will immediately know the answer to this next question; how many systems that send data to the systems you've built actually adhere to the underlying specification?

Symbiotic relationship

&lt;say something cool here&gt;

When accessing data within a document structure, the parser usually serves as the point of entry into most parsing APIs. While parsing has the same importance in all relevant APIs, in Machete, however, it is not considered to be the point of entry. In fact, before we continue, let's get something straight, parsing is only a useful activity if the ultimate goal is to extract data. Parsing, in this regard, is a means to an end. That said,

As important as it is to parse data in Machete, it is even more important to instruct the parser

When accessing data from a relational database, what is the first thing you notice? Interestingly, it is also the most obvious thing to notice. Its the language. The language is the primary point of contact between you and database engine. In the world of document parsing this does not hold true. If you've ever used a healthcare parser before, then the word query is simply not in the vocabulary you've become accustomed to. Let me guess, you call a bunch of methods passing in integer values specifying the index of the data you trying to extract, right? Am I close? Querying doesn't even exist, right? That's not the case in Machete. Just like with relational databases, Machete's query engine sits atop the parser in order to provide a layer of abstraction by which the user can access data in a declarative manner.

#### Imperative vs. Declarative

Think about what the mental approach would be to extracting data and returning it the calling application;

1. Locate the row where the target data resides
2. Locate the comma delimited column where the target data resides
3. Extract the string-based data
4. Apply language typing rules to the text
5. Return typed data to the calling application

Nothing changes in as far as what needs to happen in order to return strongly typed data to the calling application. The difference, however, is in the approach. Conventional parsers require the developer to provide an explicit set of actions to parse textual data using more of an _Imperative Programming_ model; that is, here is what I want and how I want it. Machete, on the other hand, favors a more _Declarative Programming_ model whereby the calling application describes what it wants and how it wants it.

#### Forward-only Parsing

Machete defines a forward-only parser, which essentially means that the internal cursor that the parser uses to locate data within the document structure can only be moved forward. Therefore, queries must be defined in such a way that they respect the order of the data. Imagine you wanted to write a query to grab the following HL7 data...

```
MSH|^~\&|MACHETELAB|^DOSC|MACHETE|18779|20130405125146269||ORM^O01|1999077678|P|2.3|||AL|AL
PID|1|000000000026|60043^^^MACHETE^MRN||MACHETE^JOE||19890909|F|||123 SEASAME STREET^^Oakland^CA^94600||
IN1|1|||MACHETE INC|1234 Fruitvale ave^^Oakland^CA^94601^USA||5101234567^^^^^510^1234567|074394
IN1|2|||MACHETE INC|1234 Fruitvale ave^^Oakland^CA^94601^USA||5101234567^^^^^510^1234567|074395
IN1|3|||MACHETE INC|1234 Fruitvale ave^^Oakland^CA^94601^USA||5101234567^^^^^510^1234567|074396
IN2|1|||||||||910842RN49
GT1|1|60043^^^MACHETE^MRN|MACHETE^JOE||123 SEASAME STREET^^Oakland^CA^94600|5416666666|5418888888|19890909|F
AL1|1|FA|^pollen allergy|SV|jalubu daggu||
ORC|NW|PRO2350||XO934N|||^^^^^R||20130405125144|91238^Machete^Joe||92383^Machete^Janice
OBR|1|PRO2350||11636^Urinalysis, with Culture if Indicated^L|||20130405135133||||N|||||92383^Machete^Janice
```

Although there are multiple ways to construct a query given the criteria we will take the simplest route at query might look something like this...

```csharp
var result = parse.Query(q =>
{
    return from msh in q.Select<MSH>()
        from pid in q.Select<PID>()
        from in1 in q.Select<IN1>().ZeroOrMore()
        from in2 in q.Select<IN2>().ZeroOrMore()
        from gt1 in q.Select<GT1>().ZeroOrMore()
        from al1 in q.Select<AL1>().ZeroOrMore()
        from orc in q.Select<ORC>().ZeroOrMore()
        select new
        {
            MSH = msh,
            PID = pid,
            IN1 = in1,
            IN2 = in2,
            Guarantors = gt1,
            Allergies = al1,
            Tests = orc
        };
});
```

&lt;analyze this here&gt;

The above query instructs the cursor to move forward per the below diagram, one segment at a time.

![](/assets/ParsingCursor1.png)

To drive this point home, imagine if the above query was tweaked just a little bit to look like this...

```csharp
return from msh in q.Select<MSH>()
    from in1 in q.Select<IN1>().ZeroOrMore()
    from pid in q.Select<PID>()
    from in2 in q.Select<IN2>().ZeroOrMore()
    from gt1 in q.Select<GT1>().ZeroOrMore()
    from al1 in q.Select<AL1>().ZeroOrMore()
    from tests in testQuery.ZeroOrMore()
    select new
    {
        MSH = msh,
        PID = pid,
        IN1 = in1,
        IN2 = in2,
        Guarantors = gt1,
        Allergies = al1,
        Tests = orc
    };
```

The movement of the cursor would then look something like this...![](/assets/ParsingCursor2.png)

Notice that, starting from the MSH segment, the cursor skips over the PID segment, jumping to the IN1 segment then attempting to jump backwards to the PID segment. That's a mouth full to even describe what's going on. Good thing is, it's not allowed. That said, it is possible to skip over segments as you will find out in [Skipping Entities](/advance-querying/skipping-entities.md). Even so, it must be done forwardly. The takeaway here is that queries must follow the structure of the data.

In other words, the query cannot define the parsing of entities that appear in the corresponding document structure out of order.

has always been at the forefront the point of entry to these , bleeding the internals

Machete allows the developer to instruct the parser on how to behave while it does the work of finding and returning data to the calling application.

If you've ever used a parsing library before it should not be a surprise that the center of the universe starts with the

is not your first foray into using

When accessing data within a document structure, the parser can be considered core functionality. While this is true, even in Machete, it is not, however, the point of entry into the API. That moniker is reserved for the query engine. The query engine provides mechanism that enables developers to describe what they want to parse and how to parse it. This instruction set is  then handed off to the parsing engine to subsequently execute the parsing rules against the document structure. This is in stark contrast to how most all parsing APIs work. Unfortunately, most toolkits expose the parsing engine directly to developers through its API. In Machete, however, the parser is abstracted away from the developer by way of the query engine. The purpose of this abstraction is to enable developers to express both what is to be extracted and how it is to be extracted. This makes the relationship between the query engine and parser symbiotic.

&lt;**current challenge here**&gt;

In a perfect world you wouldn't perhaps need a mechanism to adapt to the data if all systems adhered to the underlying specification. Unfortunately, this is not the current reality. Instructing the parser on how to its job through the query is much more flexible and performant than hard coding parsing rules into the engine. Data is code and if you keep this in mind you will begin to understand how important and powerful it is to be able to change the search pattern for which the parser uses to subsequently extract data from the document structure.

&lt;**end**&gt;

#### 



