# Defining Value Converters

&lt;say something cool here&gt;

Imagine if you had the below HL7...

```
MSH|^~\&|MACHETELAB||UBERMED||201701131234||ORU^R01|K113|P|
MS1|5101234567
```

...and you've defined a segment that has a single field, Phone, for which you wish to convert that looks like this...

```csharp
public interface MacheteSample1Segment :
    HL7Segment
{
    Value<string> Phone { get; }
}
```

...for which you wish to convert to look like this...

```
(XXX) XXX-XXXX
```

Machete allows you to create what's called a, _Value Converter_, to convert the data during execution of the query. So, let's jump into some code.

```csharp
public class PhoneNumberValueConverter :
    IValueConverter<string>
{
    public bool TryConvert(TextSlice slice, out Value<string> convertedValue)
    {
        Debug.Assert(slice != null);

        var text = slice.Text.ToString();

        if (text.Length < 10)
        {
            convertedValue = Value.Invalid<string>(slice);
            return false;
        }

        string phone = $"({text.Substring(0, 3)}) {text.Substring(3, 3)}-{text.Substring(6, 4)}";

        convertedValue = new ConvertedValue<string>(slice.SourceText, slice.SourceSpan, phone);
        return true;
    }
}
```

Notice that the method follows the traditional TryGet method signature whereby a boolean is returned depending on whether or not a value proper value could be returned. Also, close attention should be paid to the false case in which we would want to return an invalid value. In Machete, an invalid can is classified as one where attempted access via the _Value_ property would throw an exception indicating that there is problem converting the value. Being that is the case, you should also expect the _HasValue_ property to be false and _IsPresent_ to be true as well indicating that while there is data in the field, you do not consider it to be useful value.

#### Usage

Ok, now that we've went through the trouble of writing the above value converter, let's look at how would we use it to solve the problem.

```csharp
public class MacheteSample1SegmentMap :
    HL7SegmentMap<MacheteSample1Segment, HL7Segment>
{
    public MacheteSample1SegmentMap()
    {
        Id = "MS1";

        Value(x => x.Phone, 1, x =>
        {
            x.Converter = new PhoneNumberValueConverter();
            x.MaxLength = 10;
        });
    }
}
```

That's one way to do it, but, that's not thinking like a bad ass Machete wielding developer. Remember, everything in Machete is tuned for performance, that goes for value converters as well. In the above code snippet you are essentially constructing a new value converter object each time the Value property is called on the Phone field. There has to be a better way of doing this, right? Of course, there is. Take a look at the below code snippet that defines a static class to construct the value converter. Remember, the value converter is stateless, therefore, it makes perfect sense to define a static for your value converters like this...

```csharp
public static class MacheteSampleValueConverters
{
    public static readonly IValueConverter<string> FormattedPhoneNumber = new PhoneNumberValueConverter();
}
```

Rewriting the above entity map yields...

```csharp
public class MacheteSample1SegmentMap :
    HL7SegmentMap<MacheteSample1Segment, HL7Segment>
{
    public MacheteSample1SegmentMap()
    {
        Id = "MS1";

        Value(x => x.Phone, 1, x =>
        {
            x.Converter = MacheteSampleValueConverters.FormattedPhoneNumber;
            x.MaxLength = 10;
        });
    }
}
```

Now, the value converter is not constructed every time you want to access the corresponding field. Isn't that pretty cool? Rhetorical question, of course it is cool.

