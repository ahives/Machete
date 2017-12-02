# LINQ Support

Whether you've just started programming in C\# or consider yourself a veteran, you probably have used or at least tinkered with .NET Language-Integrated Query, better known as LINQ. LINQ serves as the umbrella technology for querying databases, objects, XML, and JSON in .NET. As described by Don Box and Anders Hejlsberg in their seminal white paper circa 2007 titled "LINQ: .NET Language-Integrated Query", .NET Language-Integrate Query defines a set of general purpose standard query operators that allow traversal, filter, and projection operations to be expressed in a direct yet declarative way.

LINQ and other language specific technologies like it were created for the masses to provide a generic way of dealing with data at the application level. These technologies were never designed to be domain specific. Many healthcare specifications for data exchange date back almost 40 years \(e.g. HL7, X12\). Most modern general purpose data exchange formats like JSON and XML are relatively young in comparison. That said, an entire generation of programmers have grown up with JSON and XML, which is why healthcare standards bodies have adapted their specifications \(e.g. CDA, FHIR, etc.\) over the years in face of this challenge. Though the case, the reality is that HL7 2.x and X12 as healthcare data exchange formats are not going away anytime soon.

With Machete, we've taken a popular, general purpose technology stack and added some domain specific goodness on top to form what we refer to as LINQ to Schema. LINQ to Schema generically refers to the application of LINQ to the various schemas  defined by Machete. In particular, Machete defines a set of query operators that allow traversal, filter, and projection operations specifically for querying healthcare data. In particular, under the LINQ to Schema umbrella Machete defines the following implementations:

* [LINQ to HL7](/advanced-topics/linq-support/linq-to-hl7.md)
* [LINQ to X12](/advanced-topics/linq-support/linq-to-x12.md)

#### Layouts

&lt;Talk about Layouts Here&gt;

