# Lazy Text Evaluation

Much of the performance gains that Machete enjoys are due in large part to how it returns values to calling applications. Machete uses a technique called _Lazy Text Evaluation_ to return converted text to calling applications. Lazy Text Evaluation is the process of evaluating text when the calling application has explicitly instructed the parser to convert text to a language primitive value \(e.g. int, bool, etc.\).

In [Query Theory](/core-concepts/query-theory.md) you learned that queries in Machete are meant to instruct the parsing engine on when and where to move the cursor in the document structure and, subsequently, extract the appropriate _text slice_.

&lt;**what is a text slice**&gt;

So, what's up with the use of the word lazy anyway? Well, we use lazy in this context to describe how text gets evaluated by  Machete; that is, parsing doesn't happen until a specific action is requested on a particular field. We realize that this may sound unintuitive having used text parsers in the past. However, it isn't all that foreign from many of your daily computing activities. Ask yourself this, if you were browsing a web page with hundreds of clickable controls \(e.g. links, buttons, etc.\) looking for something in particular to click, how would you locate and subsequently click said control? Would you click every control until you arrive at the one that is of interest to you? Of course you wouldn't; you would scroll and move your mouse to the location on the web page that is of interest to you, then click it. You've done this a million times over. Equally so, your computer wouldn't process every clickable control along the way in order to execute a user action either; that would be pretty ineffecient. Instead, your computer would record the location of the mouse pointer relative to the screen at the moment of the click to determine which item on the web page was clicked and subsequently execute its corresponding backing function. In other words, your computer enforces user interactions with web pages in the most efficient manner possible, which is lazily. When you begin to think of _Lazy Text Evaluation_ in these terms, it seems very intuitive and normal.

Now that we've looked at Lazy Text Evaluation abstractly, let's get to the meat of it, shall we. If you've read [Parsing Theory](/core-concepts/parsing-theory.md), you should be familiar with the below diagram.![](/assets/DocumentIndexing.png)

This diagram visualizes how document structures are tokenized in memory by way of an index. But, what it doesn't quite show is how text is evaluated. Let's look at an example. Say, we wanted to return the placer group number \(i.e. ORC-4.1\) field value to the calling application, we might write some code that looks a bite like this...

```csharp
string placerGroupNumber = query.Result
    .Tests[0]
    .ORC
    .PlacerGroupNumber
    .Select(x => x.EntityIdentifier)
    .Value;
```

This code will subsequently cause the query to execute but the real magic comes a bit later. This code can be broken up into two pieces; what happens before calling the _Value_ property and what happens afterwards. If you look closely, everything leading up to calling the _Value_ property refers to the location of where the text is position in the document structure. However, everything that happens after calling the _Value_ property deals directly with how the parsed text will be returned to the calling application; in particular, what entity maps and text converter should be called. In this particular scenario you would expect that the ORC and EI \(i.e. ORC-4.1 complex type\) entity maps to be called followed by the appropriate value converter; in this case a string but it could just as easily be an integer, boolean, or something else as defined by the entity.

#### Performance

So now that we've talked at length about how Machete evaluates text, let's talk about why it does it the way that it does. The below diagram represents a fragment of the target ORC segment from the previous scenario.

![](/assets/LazyTextEvaluation.png)

There are a couple ways to parse and subsequently return the value to the calling application; a\) iterate over each field until you arrive at the target text slice or b\) go directly to the target text slice. Both methods will undoubtedly arrive at the proper result but one is clearly more performant than the other, that is depending on how many fields that are in scope and the location of the target field. So, just to put this into context, according to Big O notation the algorithm performance of iterating over a set would be O\(N\), whereas, providing an index to jump directly to the target value would be O\(1\). O\(N\) in this context means that the search performance will degrade linearly in direct proportion to the increase in the size of the set. In our case, the more fields in the segment will cause the performance to degrade past the first item in the set. In contrast, O\(1\) means that the algorithm performance is relatively stable no matter the size of the set and where in the set the target item resides.

&lt;**end**&gt;

