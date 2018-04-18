# Entity Parsing

&lt;explain, code here&gt;

As you can see above, text parsing returns the parsed text as a string. However, there will be times when the calling application will need to interact with hydrated object graphs instead of strings. In such a scenario, you can you useParsing out entities is very easy when you use the entity parser. way to return an object graph representation of the underlying text string. In this regard, it is a slightly higher level of abstraction above the text parsers.

...or it can take the form of simply calling the _TryGetEntity_ method directly off of the returned object like so...

```csharp
bool TryGetEntity<T>(int index, out T entity)
    where T : TSchema;
```

&lt;&gt;

```csharp
if (parse.TryGetEntity(1, out X12Segment segment))
    if (segment is GS)
        ...
```

&lt;&gt;

