# Configuring Machete

In general, when configuring Machete you should consider the following...

> Classes that implement specified schema including user defined entities are generated during initialization of the schema

Because of this, it would behove you to initialize the schema, parser, formatter, and validator within global scope of your application. This way, you take a one-time hit upfront during service or application start up as oppose to each call. For this reason, it is recommended that you do one of the following:

* [Configuring Machete Core in a service](#configuring-machete-core-in-a-service)
* [Configuring Machete Core in ASP.NET](#configuring-machete-core-in-aspnet)
* [Configuring Machete Core in unit tests](#configuring-machete-core-in-unit-tests)

If you've chosen the Inversion of Control \(IoC\) route, then life is good. Register your dependencies, add injection points and let your favorite IoC container do all the magic for you. If for some reason that isn't your current reality, no worries, this document will guide you through that scenario as well. We recognize that you may have to go 20th century programmer and dust off that old [Singleton Pattern](#implementing-the-singleton-pattern) you tucked away during the IoC craze and get busy. Either way, there is a way forward as long as you keep in mind the expensive nature of initializing Core components on each transaction.

#### Configuring Machete Core in a service

There are a couple ways to configure Core components within a service:

* Initialize within the Main method and pass to your method

```csharp
class Program
{
    public void Main()
    {
        var schema = Machete.Schema.Factory.CreateHL7<HL7Entity>(cfg => cfg.AddFromNamespaceContaining<MSH>());
        var parser = Machete.Parser.Factory.CreateHL7(schema);
        var formatter = Machete.Formatter.Factory.CreateHL7(schema);

        YourRunMethodHere(parser, formatter);
    }
}
```

* Inject dependencies within the caller's constructor using an IoC container

#### Configuring Machete Core in ASP.NET

You'd want to configure Core components in a place where it does not get called on every page request. This usually would be done inside of the Global.ascx file's Init method. But remember, you should initialize Core in such a way that the components you need access to are accessible throughout your application.

#### Configuring Machete Core in unit tests

The good news is that Machete provides a groovy way of configuring its core components in unit tests. Depending on which schema you are working with, your test fixture should simply derive from one of the pre-built test harnesses like so...

```csharp
[TestFixture]
public class SomeGroovyTests :
    HL7MacheteTestHarness<MSH, HL7Entity>
{
    ...
}
```

That's it. Done. Well, not quite. Now that you've derived from the test harness you are now able to call the Core components like so...

```csharp
var parse = Parser.Parse(message);
var result = await Formatter.FormatToStringAsync(entityResult);
```

#### Implementing the Singleton Pattern

There are a couple of ways to implement the Singleton pattern in order to expose Core components, that is, you can do it the easy way and let your dependency injection engine do the work for you...

```csharp
// Autofac
var builder = new ContainerBuilder();

builder.RegisterType<RegisterMachetteCore>().As<IRegisterMacheteCore>().SingleInstance();
```

...or you can do it the hard way

```csharp
public sealed class MacheteSingleton
{
    static MacheteSingleton _instance = null;
    static readonly object _padlock = new object();
    static IEntityParser<HL7Entity> _parser;
    static IFormatter<HL7Entity> _formatter;

    public IEntityParser<HL7Entity> Parser { get { return _parser; } }
    public IFormatter<HL7Entity> Formatter { get { return _formatter; } }

    public static MacheteSingleton Instance
    {
        get
        {
            lock (_padlock)
            {
                if (_instance == null)
                    _instance = new MacheteSingleton();

                return _instance;
            }
        }
    }

    Singleton()
    {
        var schema = Machete.Schema.Factory.CreateHL7<HL7Entity>(cfg => cfg.AddFromNamespaceContaining<MSH>());
        _parser = Machete.Parser.Factory.CreateHL7(schema);
        _formatter = Machete.Formatter.Factory.CreateHL7(schema);
    }
}
```



