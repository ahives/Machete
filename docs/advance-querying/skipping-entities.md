# Skipping Entities

&lt;say something cool here&gt;

There are situations when you want to skipping over segments during parsing because are simply not interested in the data. In such scenarios you need a mechanism to do so, otherwise, you would have to greedily parse each segment, in order, until you arrive at your target. Remember, Machete features a forward-only parser.

Given the below HL7...

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
```

&lt;say something cool here&gt;

...write a query that would move the cursor from its current position at the PID segment to the ORC segment. How would you do such a thing? Well, you might just write a query using the _Skip_ method like this...

```csharp
var query = entityResult.Query(q =>
{
    return from msh in q.Select<MSH>()
        from pid in q.Select<PID>()
        from skipped in q.Select<HL7Segment>().Skip(q.Select<ORC>())
        from orc in q.Select<ORC>()
        select new
        {
            MSH = msh,
            PID = pid,
            ORC = orc
        };
});
```

The key to this magic is the following piece of code...

```csharp
from skipped in q.Select<HL7Segment>().Skip(q.Select<ORC>())
```

The above code reads as follows; starting from the current cursor position \(i.e. the PID segment\), move the cursor past any HL7 segment until you have identified that the current segment is an ORC at which point, stop, then set the current cursor at that  position.

Like most operators within Machete's LINQ API, _Skip_ is fully composeable. Notice that it allows you to pass in a parser and it  returns a parser back to be further composed.

