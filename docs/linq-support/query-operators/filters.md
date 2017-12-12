# Filters

&lt;say something cool here&gt;

Projections are nice, but, trust me when I say this, filtering makes it worth getting out of bed in the morning. Bold statement, I know, but ask yourself this; how many times have you had to query over a data set without filtering said data set? If you are dealing with relatively small data sets I am pretty sure that you can enumerate the times you did not have to use filtering. However, if I were to ask you when was the last time you did not use filtering on Big Data, you'd probably paint a much different picture. My guess is that if you are doing anything interesting with large data sets you'd probably at some point need filter. Filtering is similar to projects in that it is used to exclude data from the source data set. There are two main differences between the two operators;

Projections operate on objects without conditions



Machete has you covered.

```csharp
var parse = parser.Parse(message);

var result = parse.Query(query =>
{
    return from msh in query.Select<MSH>()
        from obr in query.Select<OBR>()
            .Where(x => x.PlacerOrderNumber.HasValue &&
                        x.PlacerOrderNumber.Value.UniversalId.IsEqualTo("PRO2350"))
            .ZeroOrMore()
        select new
        {
            MSH = msh,
            Tests = obr
        };
});
```

&lt;end&gt;

