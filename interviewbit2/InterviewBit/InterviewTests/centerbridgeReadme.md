Disclaimer: I don't play chess, know the rules or the pieces. I am just doing a rudimentary run through of 
how the pieces move from here: https://www.wholesalechess.com/pages/new-to-chess/pieces.html



h2 DfsHelper
In the checks, I sacrificed a bit of repetition for better readability. 
Rather than use a 'catch all' method to encapsulate all the checks, I left each
on their own so as you are stepping through the code, you can clearly see the condition
being looked at in context rather than having to switch to the base class and lose that context.

Since the actual implementation of the checks are in the base class, then changes are done in one place.
The same argument can be made for the situation described above. However, given the scope of this particular
problem, I went with the readability option.


h2 Testing
For this exercise, I just wrote minimal test cases to statisfy the majority of the conditions. In a production
system there would be many more unit tests to handle the cases I am not including here.