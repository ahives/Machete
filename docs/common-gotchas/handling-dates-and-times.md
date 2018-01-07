# Handling Dates/Times

Dealing with dates and times can be tricky at times--no pun intended. A poorly designed schema can derail the prime directive of Machete's parsing engine, that is, _do no harm_. All data is treated as a string until Machete is instructed to return a strongly typed value.



Unfortunately, when dealing with dates and times there is a way to accidentally destroy returned data. Imagine that you have defined a field to be of type, _DateTime_, and that the data came in accompanied by time zone information to put the date and time parts into context. When Machete returns this data as a DateTime object it will do so leaving out the time zone part.

That's the bad news. The good news is that Machete doesn't allow you to work on the source data. Just to qualify the earlier statement that Machete allows you to destroy data, this is technically correct because you are able if you went ahead and saved or transmitted the value

always keeps a copy of the source data as a string so it is possible to still that data. The other part of this is that we strongly recommend using DateTimeOffset in these situations because it is not destructive.

