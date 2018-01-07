# OR-ing Entities

&lt;say something cool here&gt;

There will perhaps come times during parsing when a choice may need to be made between one entity versus another. In such a scenario, Machete provides the OR parser. In this context, the OR parser hangs off of a generic parser. Say you want to parse the IN1 entity and if it doesn't exist then return the IN2 entity. To do that you would use the OR parser like this...

```csharp
var query = entityResult.Query(q =>
    from msh in q.Select<MSH>()
    from pid in q.Select<PID>()
    from insurance in q.Select<IN1>()
        .Or<HL7Entity, HL7Segment, IN1, IN2>(q.Select<IN2>())
    select insurance);
```

&lt;end&gt;

