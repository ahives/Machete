# Introducing, Machete

The Healthcare IT industry goes as far back as the 1960's. In other words, the melding of the computing and healthcare industries has been going on for over half a century. Strangely, building platforms--a la Google, Microsoft, Apple, or Apache--is a pretty recent phenomena to the Healthcare IT industry. These and many other technology organizations have blazed the trail and shown the world how to build sustainable platforms that are reliable, scalable, and maintainable. Yet, it is 2017, and still the Healthcare IT industry cannot seem to build equivalent platforms with any sort of consistency.

The reality is, platforms can't be built with consistency without having a core set of APIs and frameworks, you know, sort of like what a kernel provides to a software operating system. With that in mind, Chris Patterson and Albert L. Hives looked around in search of that core package of APIs and frameworks like what they've grown accustomed to seeing in other industries. To their surprise and dismay, it simply did not exist in healthcare. Programming language did not matter, nor did operating system or device. So, instead of waiting for others to build it, they set out to build it themselves and Machete was born. They both understood that in order to build disruptive technology like Machete, it had to be done in an environment that fostered collaboration and innovation so they chose the Open Source Software community. Ironically, the same tact has been taken in recent years by even healthcare standards bodies \(e.g. HL7, IHE, etc.\). Although we've seen more and more Connect-a-thons and Hack-a-thons pop up in recent years, we've even seen standards bodies go beyond standards \(e.g. FHIR, IHE, etc.\) and push open source implementations of said standards, we've yet to see an adaptive core for which all things healthcare can be built atop. That is, until Machete.

Machete is a framework that simplifies the task of working with healthcare data.  It fulfills many of the tasks that are required for processing healthcare data.  Specifically, it is:

* a parser
* a object mapper
* a query engine
* a translation engine
* a data validator
* an object formatter

Machete is highly optimized and leverages efficient parsing algorithms combined with lazy text evaluation, which reduces memory usage, limit garbage collection, and defer string allocations, resulting in blazing fast performance. Machete fully supports asynchronous processing of text, including streams, making it a perfect fit for building high-volume, multi-threaded, and distributed systems.

![](/assets/Machete API Framework Design 1.png)



