# Query Theory

&lt;say something cool here&gt;

When accessing data from a relational database, what is the first thing you notice? Interestingly, it is also the most obvious thing to notice. Its the language. The language is the primary point of contact between you and database engine. In the world of document parsing this does not hold true. If you've ever used a healthcare parser before, then the word query is simply not in the vocabulary you've become accustomed to. Let me guess, you call a bunch of methods passing in integer values specifying the index of the data you trying to extract, right? Am I close? Querying doesn't even exist, right? That's not the case in Machete. Just like with relational databases, Machete's query engine sits atop the parser in order to provide a layer of abstraction by which the user can access data in a declarative manner.

#### Data processing challenges

When you execute a SQL query against a relational database what do you suppose happens? Well, if you've designed your schema correctly and have an index then the database will go there first and pull the locations it needs to lookup in the data file. It will then go to the data file using the location from the index, go to the location, and then grab the specified data. Grabbing the data actually involves parsing because, guess what, the data is stored as delimited strings. I mean, how else would the query engine know how to later apply the schema to your data upon return. But what about large amounts of data. Surely, large data file processing is not a challenge that must be dealt with outside of the database world. Well, tell that to folks in healthcare who have to handle GB Eligibility files.

#### Similar problem, similar solution

Hmm, does any of the above challenges sound familiar? They should, after all, these are the very same challenges faced today by your favorite document parsers. The good thing is that every one of these challenges there, Machete has a solution. Relational databases use indexing to efficiently pinpoint data within an internal document structure. Sounds smart, we'll take it. Machete internally uses indexing as well to store data coordinates, which is why it is so proficient at seeking to positions within the document structure. Relational databases provides its users with a declarative language to interact with data. Machete provides its users with a similar declarative language, [LINQ](/linq-support/README.md), to interact with data. Relational databases generate execution plans when their fed queries to ensure they get executed in the most efficient manner possible. Machete does the same using predefined [schema](/core-concepts/schema.md), [object mappers](/extending-machete/defining-entity-maps.md), and [lazy text evaluation](/core-concepts/lazy-text-evaluation.md).

&lt;end&gt;

