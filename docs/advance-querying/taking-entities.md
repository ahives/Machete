# Taking Entities



&lt;say something cool here&gt;

```
MSH|^~\&|MACHETELAB|^DOSC|MACHETE|18779|20130405125146269||ORM^O01|1999077678|P|2.3|||AL|AL
PID|1|000000000026|60043^^^MACHETE^MRN||MACHETE^JOE||19890909|F|||123 SEASAME STREET^^Oakland^CA^94600||
IN1|1|||MACHETE INC|1234 Fruitvale ave^^Oakland^CA^94601^USA||5101234567^^^^^510^1234567|074394
IN1|2|||MACHETE INC|1234 Fruitvale ave^^Oakland^CA^94601^USA||5101234567^^^^^510^1234567|074395
IN1|3|||MACHETE INC|1234 Fruitvale ave^^Oakland^CA^94601^USA||5101234567^^^^^510^1234567|074395
IN2|1|||||||||910842RN49
GT1|1|60043^^^MACHETE^MRN|MACHETE^JOE||123 SEASAME STREET^^Oakland^CA^94600|5416666666|5418888888|19890909|F
AL1|1|FA|^pollen allergy|SV|jalubu daggu||
ORC|NW|PRO2350||XO934N|||^^^^^R||20130405125144|91238^Machete^Joe||92383^Machete^Janice
```

&lt;end&gt;

#### Take

&lt;explain here&gt;

```csharp
var query = entityResult.Query(q =>
    from msh in q.Select<MSH>()
    from pid in q.Select<PID>()
    from insurance in q.Select<IN1>().Take(2)
    select insurance);
```

&lt;end&gt;

The above query would yield the following output...

```
IN1|1|||MACHETE INC|1234 Fruitvale ave^^Oakland^CA^94601^USA||5101234567^^^^^510^1234567|074394
IN1|2|||MACHETE INC|1234 Fruitvale ave^^Oakland^CA^94601^USA||5101234567^^^^^510^1234567|074395
```

&lt;end&gt;

#### TakeWhile

Using the Take operator is useful but there will be times when you will not know how many entities to take and, therefore, would want to take as many entities as possible so as long as a particular condition is met. In such a case you would modify the above code like this...

```csharp
var query = entityResult.Query(q =>
    from msh in q.Select<MSH>()
    from pid in q.Select<PID>()
    from insurance in q.Select<IN1>().TakeWhile(x => x.GroupNumber.IsEqualTo("074395"))
    select insurance);
```

&lt;end&gt;

The above query will select each IN1 entity and check to see if the GroupNumber is equal to 074395. This query yields the following output...

```
IN1|2|||MACHETE INC|1234 Fruitvale ave^^Oakland^CA^94601^USA||5101234567^^^^^510^1234567|074395
IN1|3|||MACHETE INC|1234 Fruitvale ave^^Oakland^CA^94601^USA||5101234567^^^^^510^1234567|074395
```



&lt;end&gt;

