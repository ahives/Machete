# Accessing Fields

&lt;say something cool here&gt;

Before diving into the specifics of how to access fields, let's first start with the below code snippet that will serve as the baseline for all subsequent examples in this section.

```csharp
1: ParseResult<HL7Entity> parse = parser.Parse(message);
2: 
3: var result = parsed.Query(query =>
4:    from msh in query.Select<MSHSegment>()
5:    from pid in query.Select<PIDSegment>()
6:    select pid);
7:
8: var patientIdNumber = result.Select(x => x.PatientId).Select(x => x.IdNumber);
```

&lt;say something cool about HasValue and IsPresent here&gt;

* [HasValue](#hasvalue)
* [IsPresent](#ispresent)

&lt;say something cool about HasValue and IsPresent here&gt;

#### HasValue

If you are doing anything interesting with Machete, there will be times when you will need to check a field to see if data is present. For instance, you need to check the existence of a field to inform your program on whether or not proceed with its execution. In such a scenario you would probably expect there to be something within the API that would allow for this common task, right? Well, there is such a functionality and its appropriately named, _HasValue_. When called, HasValue will return a boolean value indicating whether or not the field has a _logical null value_. If you are familiar with HL7, there is a concept within the specification that outlines that double quotes, "", within a delimited field will denote to the receiving system that the field value should be considered null. In such a case, we define this in Machete as being a logical null value.

Given the above baseline code, here is all you would need to check whether or not the field under investigation is a logical null value...

```csharp
bool hasValue = patientIdNumber.HasValue;
```

Of course, if you wanted to perform the same check using Machete's fluent syntax you can very well do that too...

```csharp
bool hasValue = result.Select(x => x.PatientId).Select(x => x.IdNumber).HasValue;
```

&lt;end&gt;

#### IsPresent

While HasValue is used to determine the presence of a logical null value, there are times when you will want to determine whether there is any data present in the field. To do that it's just as simple...

```csharp
bool isDataPresent = patientIdNumber.IsPresent;
```

But of course, if you wanted to perform the same task using Machete's fluent syntax you can very well do so as well...

```
bool isDataPresent = result.Select(x => x.PatientId).Select(x => x.IdNumber).IsPresent;
```

&lt;end&gt;

