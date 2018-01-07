# Parsing Data

There are two major things every data parser must be able to do; 1\) find data and 2\) be able to extract it. That's all a parser really does. That said, a parser must perform its work accurately and in the most efficient manner possible all while using as little memory as possible. Why? Whenever your talking about data processing people always take for granted the little piece of code under the hood that actually performs the function of finding and extracting data. If the parser is slow, heavy, and inaccurate then so will everything else be that sits on top of it. The database industry seems to understand this concept very well. On the other hand, it  has been slow to make inroads into the world of document parsing.

#### Parsing

&lt;**say something cool here**&gt;

If you've read Theory of Query you already know that Machete defines a forward-only parser. This means that the internal cursor that Machete uses to seek to data can only be moved forward. In other words, the query cannot define the parsing of entities that appear in the corresponding document structure out of order.

What that means is that the LINQ query that the calling application provides must



&lt;**end**&gt;

#### If its data, you Seek

Most modern parsers walk through the entire document structure in search of matches specified by a query. We found this to be both tedious and rather strange considering how the human brain works. Before unpacking that statement, let me first throw out a couple of terms; _scanning_ and _seeking_. Let's define these terms through an example. Look at the below data and find the value XO934N.![](/assets/ParsingScan.png)Now, given the same data, find the value at location ORC-4...![](/assets/ParsingSkip.png)Notice that in the first example you had to sith through data until you finally arrived at what you were looking for. Along the way you might have found yourself reading more information than what was neccesary to determine whether or not the data was relevant to your search. This is what we call, _scanning_. In the second example, however, you were able to quickly orient yourself within the document because everything else was out of focus considering that you knew the location prior to the search. We call this _seeking_. At some point you have to sith through the document but your brain applies different algorithms when scanning  versus when seeking. Put simply, your brain applies situational optimizations to its search algorithms based on search criteria,  prior knowledge and familiarity with the data.

The algorithm your brain applies is quite simple, yet, elegant. It's a two dimensional mathematical problem. Data exists on both the X-axis and Y-axis. Before even attempting to navigate the document structure, you know the following;

* The first _n_ characters on each line spanning from the leftmost character to the first field delimiter character represents the target Y-axis value
* Data that falls in between every two delimeter characters after the Y-axis value represents a single field

With that information in hand, you are able to easily calculate the coordinates of the data in space. The human mind is pretty darn good at spatial recognition or else you wouldn't be able to do simple things like catching objects or navigating terrain. Oh, by the way, relational databases work similarly. If not provided with the coordinates of the target data in the file, they will perform a scan. The opposite is also true, that is, if given the proper coordinates of the target data in the file, they will perform a seek. So, now your probably thinking, why not bake this knowledge into the parser. That's exactly what we were thinking when we built  Machete.

#### Tokenizing the document structure

How does the brain know how to seek? Well, first of all, it must be able to recognize a dependable pattern. The brain might try to organize the data in terms of rows and columns. Once this is done, it might then generate a unique identifier for each row and keep the information pertaining to how to slice up each row into columns in short term memory. Hmm, this sounds a lot like how a relational database works. We call this process _tokenization_. Tokenizing the document structure and storing the entity identifier along with its corresponding data in memory might look something like the figure below. ![](/assets/DocumentIndexing.png)On the far left you see an index of tokenized entity identifiers \(e.g. MSH, ORC, etc.\) pointing to the data for which it is assigned to. Once the document is tokenized in this way, it becomes easy for the parser to then identify and access the corresponding data.

Performance

