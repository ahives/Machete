# Parsing Theory

There are two major things every data parser must be able to do; 1\) find data and 2\) be able to extract it. That's all a parser really does. That said, a parser must perform its work in the most efficient and accurate way possible all while using as little resources as possible. Why? Whenever your talking about data processing people always take for granted the little piece of code under the hood that actually performs the function of finding and extracting data. If the parser is slow, heavy, and inaccurate then so will everything that sits on top of it will be. The database industry seems to understand this concept very well. On the other hand, it  has been slow to make inroads into the world of document parsing.

#### If its data, you Seek

Most modern parsers walk through the entire document structure in search of matches specified by a query. We found this to be both tedious and rather strange considering how the human mind works. Before unpacking that statement, let me first throw out a couple of terms; _scanning_ and _seeking_. Let's define these terms through an example. Look at below data and find the value at field ORC-9.![](/assets/ParsingScan.png)Now find the same value by looking at the below data...![](/assets/ParsingSkip.png)Notice that in the first example you had to sith through data until you finally arrived at what you were looking for. Along the way you might have found yourself reading more information than what was neccesary to determine whether or not the data was relevant to your search. This is what we call, scanning. In the second example, however, you were able to go right to the quickly orient yourself within the document because everything else was out of focus. We call this seeking. At some point you have to sith through the document but your brain applies different algorithms when in heavy versus when light mode. Put simply, your brain applies situational optimizations.

The algorithm your brain applies is quite simple, yet, elegant. It's a two dimensional mathematical problem. Data exists on both the X-axis and Y-axis. Before evening attempting to navigate the document structure, you know the following;

* The first _n_ characters on each line spanning from the leftmost character to the first field delimiter character represents the target Y-axis value
* Data that falls in between every two delimeter characters after the Y-axis value represents a single field

With that information in hand, you are able to easily calculate the coordinates of the data in space. The human mind is pretty darn good at spatial recognition or else you wouldn't be able to do simple things like catching objects or navigating terrain. Oh, by the way, relational databases work similarly. If they are not provided the proper coordinates of the sought after data in the file they will perform a scan, otherwise, they will perform a seek. So, now your probably thinking, why not bake this knowledge into the parser. That's exactly what we were thinking when we built  Machete.

#### 



