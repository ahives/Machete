# Defining Fields

What is an entity without fields? Well, to answer ever so bluntly, not very useful. Just like there is more than meets the eye to defining entities, the same can be said with defining fields. Defining a field within an entity looks like this...

```csharp
[Value|ValueList]<TValue> FieldNameHere { get; }
```

To define a field, you'll need to answer the following questions:

* Is the field value complex or primitive \(e.g. string, int, bool, etc.\)
* Is the field value singular or plural

The answers to these questions will serve to guide you in determining how to define your field, in particular, whether to use [_Value&lt;TValue&gt;_](#value) or [_ValueList&lt;TValue&gt;_](#valuelist) and what type is _TValue_.

#### Value

A _Value_ can be defined as a property on an entity that is mapped by the schema. When a field is defined as being of type _Value_, it means that the field has a single associated value \(i.e. is not a list\). If you need to mentally map this to your preferred healthcare specification then most specifications would refer to this as not _repeating_.

```csharp
Value<TValue> FieldNameHere { get; }
```

For a list of types currently supported by Machete please take a look at the table in the [supported types](#supported-types) section below.

#### ValueList

A _ValueList_ is can be defined as a property on an entity that is mapped by the schema just like Value. However, the difference is that if a field is defined as being a ValueList it means that the field has multiple associated values that are said to be "repeating".

```csharp
ValueList<TValue> FieldNameHere { get; }
```

For a list of types currently supported by Machete please take a look at the table in the [supported types](#supported-types) section below.

#### Supported Types

So, in the above code snippets, _TValue_, can either be a language primitive \(e.g. string, int, bool, etc.\) or another entity \(e.g. CWE, HD, etc.\). Below is a list of currently supported values...

| Type | Machete Support | Notes |
| :--- | :--- | :--- |
| string | Yes |  |
| char | No | Consider using string |
| short | Yes |  |
| ushort | No | Consider using short |
| int | Yes |  |
| uint | No | Consider using int |
| long | Yes |  |
| ulong | No | Consider using long |
| decimal | Yes |  |
| float | No | Consider using decimal |
| double | No | Consider using decimal |
| bool | Yes |  |
| DateTime | Yes | Consider using DateTimeOffset |
| DateTimeOffset | Yes |  |
| guid | Yes |  |
| byte | Yes |  |
| object | No | Consider using another type |
| dynamic | No | Consider using another type |
| Entity | Yes |  |

#### 

#### Why be unconventional?

I know what you're thinking, why not define entity fields like the rest of the world would do it, you know, like this...

```csharp
TValue FieldNameHere { get; }
```

...or like this...

```csharp
List<TValue> FieldNameHere { get; }
```

The reason lies in the nuances that are embedded in most all healthcare specifications. If you are familiar with the HL7 2.x specification\(s\) there are some nuances around what constitutes a field value. For example, did you know that a double quoted empty field \(e.g. \|""\|\) should be interpreted as a null? Did you also know that an empty field \(e.g. \|\|\) is different from a field having nothing but whitespace between delimiters \(e.g. \|     \|\)? This only becomes a problem when you attempt to strongly type these values. What if you had to make a distinction between this data and "real" data? Well, you'd probably just create extension methods to perform these tasks.
