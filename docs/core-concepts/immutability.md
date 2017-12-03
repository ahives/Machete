# Immutability

Data fidelity is the most important attribute of healthcare systems. Ironically, most all healthcare parsers expose their specification model through publicly accessible classes and/or properties. Such APIs are arguably simpler to use if you plan on manipulating the parsed data. On the other hand, they are also prone to side effects and are notoriusly more difficult to debug. In the Functional Programming world, this is referred to as _state mutation_. State mutation happens when an object is made mutable and therefore is able to be changed during execution. Let's look at a concrete example of state mutation.

```csharp
1: var list = new List<int>{1, 5, 2, 4, 3};
2: Action op1 = () => Console.WriteLine(list[2]);
3: Action op2 = () => {
4:    list[2] = list[2] * 2;
5:    Console.WriteLine(list[2]); };
6: Parallel.Invoke(op1, op2);
```

You would expect that the value at position 2 in the list to be different now that I've changed the value on line 4, right? This is what's called state mutation, that is, the state of the list has mutated into an entirely new list. Such behavior can cause a system to execute in some really gnarly ways. While the above example seems pretty harmless, think about what it would mean if data flowing through a healthcare system mutated, then was transmitted to another system where an awaiting ER room physician poised to operate on an incompacitated patient has to make a life or death decision based on said data. We realized those are the stakes with the applications that are and will be built with Machete. Therefore, Machete does not allow parsed data to be changed, PERIOD. If changing the parsed data is intended, this has to be done explicitly in another API on a copy of the parsed data. Therefore, it can be said that the parsed data is immutable.

There are a few techniques that Machete employs to prevent state mutation of parsed data:

* [Schema definition](#schema-definition)
* [API boundaries](#api-boundaries)

One of the core tenants of Machete is how it separates concerns when it comes to parsing and translating data. That said, parsed data is immutable. Put simple, when source data is parsed, it cannot be changed during this process.The primary reason for this is to maintain fidelity of the source data. This is extremely important concept in healthcare.

There are a couple ways we decide to solve this problem within Machete.

#### Schema Definition

The first way we solved the problem of state mutation is via how specifications are defined, in particular, the parsed object model is immutable. To better understand this, lets take a look at the below HL7 segment.

```csharp
public interface MSH :
    HL7V26Segment
{
    Value<string> EncodingCharacters { get; }
    Value<HD> SendingApplication { get; }
    Value<HD> SendingFacility { get; }
    Value<HD> ReceivingApplication { get; }
    Value<HD> ReceivingFacility { get; }
    Value<DateTimeOffset> DateTimeOfMessage { get; }
    Value<string> Security { get; }
    Value<MSG> MessageType { get; }
    Value<string> MessageControlId { get; }
    Value<PT> ProcessingId { get; }
    Value<VID> VersionId { get; }
    Value<decimal> SequenceNumber { get; }
    Value<string> ContinuationPointer { get; }
    Value<string> AcceptAcknowledgmentType { get; }
    Value<string> ApplicationAcknowledgmentType { get; }
    Value<string> CountryCode { get; }
    ValueList<string> CharacterSet { get; }
    Value<CWE> PrincipalLanguageOfMessage { get; }
    Value<string> AlternateCharacterSetHandlingScheme { get; }
    ValueList<EI> MessageProfileIdentifier { get; }
    Value<XON> SendingResponsibleOrganization { get; }
    Value<XON> ReceivingResponsibleOrganization { get; }
    Value<HD> SendingNetworkAddress { get; }
    Value<HD> ReceivingNetworkAddress { get; }
}
```

Notice anything?

**Hint:** how would one implement this interface?

Oops, gave it away.

There are a couple things that immediately stick out here; 1\) the segment is defined as an interface instead of a class and 2\) the properties that define the fields do not expose setters. Put simply, you are not allowed to define the interaction of the specification with the parser, Machete takes care of this on your behalf, which means that there is no opportunity to inject logic that may introduce side effects. Once the interface is defined, Machete will generate the backing class behind the scenes.

#### API Boundaries

The other way that Machete enforces immutability is within the relationship between the Parsing API and the Translation API. Take a look at the below code snippet...

```

```

As was previously stated, Machete does not allow for manipulation of the parse via the Parsing API. It does, however, through the Translation API, with one caveat, that is, it does not work directly on the parse. Translating data is an explicit action in Machete and not an accidental one like with most parsers. The reason for this is simple, most parsers both enable and allow actors to manipulate the parsed data model. Not the case with Machete. In order to translate data, one must write the necessary code to define what's called a _translate_ and explicitly feed it to the Translator engine, which will then return a copy of the parsed data model with the translated data per the instructions provided by the translate.

While we recognize that separating parsing from translation makes for a slightly more difficult developer experience, we feel that data fidelity take presidence considering the reality of the potential reprecussions of inaccurate patient health information exchange. That said, we've made sure that the APIs are congruent with each other so that the developer experience will be very consistent.

