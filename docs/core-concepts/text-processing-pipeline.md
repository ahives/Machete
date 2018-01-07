# Text Processing Pipeline

&lt;say something cool here&gt;

To define what Machete is, let's start off by stating what it isn't. Usually, defining something is simply a matter of indicating what it does. By that reasoning, though, you might be under the impression that Machete is simply another parser. After all, you've used parsers before and the thing they all have in common is that they all return data from a document structure of some kind to the caller. If the definition ends there, then, you would be correct in calling Machete a parser. However, you would be incorrect because Machete is not a parser. Well, its not only a parser. Machete is a text processing pipeline. To understand what that means, let's look at it from the outside in.

As you will learn later, calling applications do not interact directly with the parser in Machete. Instead, calling application's interact with the parser only through the explicit execution of queries. With that in mind, think of it as the calling application is responsible for handing Machete a list of instructions it wants it to execute against the document structure and return some result in a particular manner. Once the query engine has received said instructions, it will call the appropriate object mappers that have predefined information on how to parse the text.

Machete is a text processing pipeline. When you think about pr

What is Machete? The million dollar question. is so much more than a mere parser. Machete is a text processing engine. The description of what Machete is

If you have read this far, then you are probably intrigued by the

![](/assets/TextProcessingPipeline.png)

&lt;end&gt;

#### Data processing challenges

When you execute a SQL query against a relational database what do you suppose happens? Well, if you've designed your schema correctly and have an index then the database will go there first and pull the locations it needs to lookup in the data file. It will then go to the data file using the location from the index, go to the location, and then grab the specified data. Grabbing the data actually involves parsing because, guess what, the data is stored as delimited strings. I mean, how else would the query engine know how to later apply the schema to your data upon return. But what about large amounts of data. Surely, large data file processing is not a challenge that must be dealt with outside of the database world. Well, tell that to folks in healthcare who have to handle GB Eligibility files.

#### Similar problem, similar solution

Hmm, does any of the above challenges sound familiar? They should, after all, these are the very same challenges faced today by your favorite document parsers. The good thing is that every one of these challenges there, Machete has a solution. Relational databases use indexing to efficiently pinpoint data within an internal document structure. Sounds smart, we'll take it. Machete internally uses indexing as well to store data coordinates, which is why it is so proficient at seeking to positions within the document structure. Relational databases provides its users with a declarative language to interact with data. Machete provides its users with a similar declarative language,[LINQ](#), to interact with data. Relational databases generate execution plans when their fed queries to ensure they get executed in the most efficient manner possible. Machete does the same using predefined[schema](#),[object mappers](#), and[lazy text evaluation](#).

&lt;end&gt;

