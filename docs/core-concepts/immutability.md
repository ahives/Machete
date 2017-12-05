# Immutability

Data fidelity is the most important attribute of healthcare systems. Ironically, practiaclly all healthcare parsers expose their specification model through publicly accessible classes and/or properties. Such APIs are arguably simpler to use if you plan on manipulating the parsed data. On the other hand, they are also prone to side effects and are notoriusly more difficult to debug. In the Functional Programming world, this is referred to as _state mutation_. State mutation happens when an object is made mutable and therefore is able to be changed during execution. Let's look at a concrete example of state mutation.

```csharp
1: var list = new List<int>{1, 5, 2, 4, 3};
2: Action op1 = () => Console.WriteLine(list[2]);
3: Action op2 = () => {
4:    list[2] = list[2] * 2;
5:    Console.WriteLine(list[2]); };
6: Parallel.Invoke(op1, op2);
```

You would expect that the value at position 2 in the list to be different now that I've changed the value on line 4, right? This is what's called state mutation, that is, the state of the list has mutated into an entirely new list. Such behavior can cause a system to execute in some really gnarly ways. While the above example seems pretty harmless, think about what it would mean if data flowing through a healthcare system mutated, then was transmitted to another system where an awaiting ER room physician poised to operate on an incompacitated patient has to make a life or death decision based on said data. We realized those are the stakes with the applications that are and will be built with Machete. Therefore, Machete does not allow parsed data to be changed, EVER. If changing the parsed data is intended, this has to be done explicitly via the Translator API. That said, the Translator API only modifies a copy of the parsed data and not the original. Therefore, it can be said that the parsed data is immutable.

There are a few techniques that Machete employs to prevent state mutation of parsed data:

* [Schema definition](#schema-definition)
* [API boundaries](#api-boundaries)

#### Schema Definition

The data that is extracted and mapped to objects in Machete cannot be modified by external processing after the initial action of parsing has occurred. This is done quite cleverly through enforcing immutability through schema definition and construction. Take a look at the below code.

```csharp
public interface SomeEntity :
    Entity
{
    Value<string> Field1 { get; }
    Value<HD> Field2 { get; }
    ValueList<string> Field3 { get; }
}
```

There are a couple things that stick out, in partiular:

* The entity is defined as an interface instead of a class
* The properties that define the fields do not expose setters

Put simply, you are not allowed to manipulate or interject interactions into the definition of the schema. Once the interface is defined, the backing class will be generated during initialization without any public setters. The caller is handed back a read-only interface from the object mapper. Therefore, the caller is not presented an opportunity to introduce side effects that may cause state mutation.

#### API Boundaries

API boundaries within Machete are extremely strict. This does not mean that they don't work with other. It does mean, however,  that they do not step on each other. For instance, the Parsing API does not manipulate data, this burden falls on the Translator API. If data must be changed, a translate is created and explicitly executed against the parse. However, the translate is executed in a way that the source text is preserved in the parsed objects and a new object structure is created and returned to the caller \(see below code\). Think of this as a new view of the data.

```csharp
ParseResult<HL7Entity> entityResult = parser.Parse(message);

var translator = Machete.Schema.CreateTranslator(typeof(MessageTranslate), () => new MessageTranslate());
var translateResult = await translator.Translate(entityResult);
```

As you can see from the above code, translating data is an explicit action in Machete and not an accidental one like with most parsers. While we recognize that separating parsing from translation makes for a slightly more difficult developer experience, we feel that data fidelity takes presidence considering the reality of the potential reprecussions of inaccurate data. That said, we've made sure that the APIs are congruent with each other so that the developer experience will be very consistent.

