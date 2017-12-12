# Accessing Field Data

With most things in Machete there are multiple ways to perform the same task. Accessing field data is no different. Choosing one way over another is depends on what behavior can you tolerate.

The below code will serve as the baseline for the subsequent code snippets in this section.

```csharp
ParseResult<HL7Entity> parse = parser.Parse(message);

var result = parse.Query(query =>
    from msh in query.Select<MSHSegment>()
    from pid in query.Select<PIDSegment>()
    select pid);
```

In addition, we will use the below HL7 fragment as the reference data for the sample code in this section as well...

```
MSH|^~\&|MACHETELAB|^DOSC|MACHETE|18779|20130405125146269||ORM^O01|1999077678|P|2.3|||AL|AL
PID|1|09823^^^^^^^abc|60043^^^MACHETE^MRN||MACHETE^JOE||19890909|F|||123 SEASAME STREET^^Oakland^CA^94600
...
```

A parser cannot be 99.999 percent accurate because that 1/100th that it isn't can be the difference between life and death. That said, it should also be known that systems fail so the assumption is that all data flowing through your parser will not be pristine. This is especially the case when string data is manipulated as a way of better dealing with said data in the application. I mean, we all know how this works; garbage comes in, the parser attempts to convert the garbage into a known language primitive type, data gets lost and/or the system faults, and the pagers go off. Sounds familiar, right? Although Machete is not immune to this problem, it does come with the antidote. Below are the mechanisms that Machete provides to remediate the many variants of this problem as it relates to type conversion.

* [Value](#value)
* [ValueOrDefault](#valueordefault)
* [TryGetSlice](#trygetslice)

#### Value

When [defining entities](/extending-machete/defining-entities.md) you'll notice that fields are defined with different language primitives. That being said, the applications you may write perhaps may want to take advantage of the typing system that Machete provides. To do this is pretty simple...

```csharp
DateTimeOffset expirationDate = result.Select(x => x.PID)
    .Select(x => x.PatientId)
    .Select(x => x.ExpirationDate)
    .Value;
```

The above code snippet represents how you would access a complex field value \(i.e. a field of type Entity\), in this case a field of type CX. Looking closer at the above example, notice that the ExpirationDate field in the CX entity type is defined as DateTimeOffset and performing such an action on the field will call the corresponding type converter for that primitive type. What would you expect to happen if garbage data came in the field for which ExpirationDate was mapped to? Since Value will attempt to type the string data to its target type, it will throw ValueFormatException. This is only the case with non-string types since the source is string data to begin with. As you will see later in this section there are ways to deal with this gracefully.

There may be situations when, perhaps, you want to access fields directly. You could do that to...

```csharp
CX patientId = result.Select(x => x.PID).Select(x => x.PatientId).Value
```

In this case, the above code will not result in an exception being thrown since it is defined as an entity. But, if it were defined as a  simple type \(i.e. defined as a language primitive\) then it would throw an exception if it had garbage data for the same reason as described earlier. Although the Value property gives you all the amenities of accessing strongly typed data it does come with the pitfalls of value conversion.

#### ValueOrDefault

Despite the emphasis put on data fidelity, the reality is that data is not always pristine. For that reason, there will be times where you will need to return source data for inspection. For this use case and similar, Machete provides the _ValueOrDefault_ extension method. ValueOrDefault performs a similar role to what the _Value_ property is used for with a couple of additions;

* Garbage data cannot not cause ValueOrDefault to throw an exception
* If the specified type cannot be returned, then a default value can be specified and subsequently returned

```csharp
string patientId = result.Select(x => x.PID)
    .Select(x => x.PatientId)
    .Select(x => x.IdNumber)
    .ValueOrDefault();
```

In the above code, ValueOrDefault will return a value if one exists otherwise it will safely return either the predefined default value of the corresponding type or a value specified by the caller \(see below code snippet\).

```csharp
string patientId = result.Select(x => x.PID)
    .Select(x => x.PatientId)
    .Select(x => x.IdNumber)
    .ValueOrDefault(1000);
```

In the above code snippet, we will return a default value, 1000, if the target field cannot be typed appropriately.

#### TryGetSlice

As you've seen above, the ValueOrDefault method provides an elegant way of typing field data even if said data will cause an application to fault in normal situations. However, there are still scenarios where you simply want to return what was found in the source field no matter if it is garbage or not. _TryGetSlice_ to the rescue. When used properly, TryGetSlice will return the source text without any attempt to type the data. Let's take a look at some code.

```csharp
result.Select(x => x.PID).Select(x => x.PatientId).Slice.TryGetSlice(2, out TextSlice slice);

string patientIdField = slice.Text.ToString();
```

Given the HL7 fragment up top, the above code will return the value "09823^^^^^^^abc". Pretty cool, huh? But, you want to go deeper, right? Let me guess, you want to get at the data that is inside the CX entity, right? Here is how you would do that...

```csharp
result.Select(x => x.PID)
        .Select(x => x.PatientId)
        .Select(x => x.ExpirationDate)
        .Slice
        .TryGetSlice(7, out TextSlice slice);

string expirationDate = slice.Text.ToString();
```

In this case you specify the index you are trying to parse, which in the example is CX-8 \(remember the entity is zero-based\). The above code snippet will return the value "abc", which according to the schema definition this would be the ExpirationDate field.

