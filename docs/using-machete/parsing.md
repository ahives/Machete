# Parsing

Parsing is considered core functionality in Machete in that everything else stands on its shoulders. Without this service, nothing else matters. That said, Machete has managed to make it pretty painless and simple. To parse a document structure in Machete you need to do the following:

* Initialize the parser

```csharp
var schema = Machete.Schema.Factory.CreateX12<X12Entity>(cfg => cfg.AddFromNamespaceContaining<ISA>());
var parser = Machete.Parser.Factory.CreateX12(schema);
```

* Parse the document structure

```csharp
EntityResult<X12Entity> parse = parser.Parse(message);
```

But, as simple as the above code may look, there is a significant amount of magic going on under the hood. First, let's get a few things straight starting with the use of the word _parser_ itself. _Parser_ is a somewhat loaded word since Machete employs several parsers to perform the task of parsing what we refer to generically as a document structures \(e.g. message, document, etc.\). Each parser performs a very specific job.

To be clear, calling the _Parse_ method does not actually parse the document structure in the way you might think. It is minimalistic in that only the boundaries \(i.e. end of line\) of the entity are discovered initially. That said, you'll see that calling _Parse_ returns an _EntityResult_ rather than an actual parsed object structure. There is a reason for this, that is, we haven't told the parser what exactly we would like it to parse yet. Remember, parsing in Machete is done lazily, therefore, the entity maps are not actually called when the _Parse_ method is called. Once a query is performed against the document structure, only then are entity maps called to convert the parsed text into entities.

In Machete, there are three classifications of parsing: text parsing, entity parsing, and stream parsing.

After parsing the document structure, you have several choices as to what you can do next...

* [Format the document structure](/using-machete/formatting-document-structures.md)
* Validate the document structure
* [Query the document structure](/using-machete/querying-document-structures.md)

In other words, everything in Machete that enables one to perform work on a document structure begins with parsing. While building Machete, we understood day one that there will be different use cases even with something so core as parsing that we enable you to parse in different ways to fulfill said use cases.

