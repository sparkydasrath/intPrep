Disclaimer: I don't play chess, know the rules or the pieces. I am just doing a rudimentary run through of 
how the pieces move from here: https://www.wholesalechess.com/pages/new-to-chess/pieces.html

***

### Approach
Since the problem wants a count of all numbers walking the provided matrix input, a recusive + backtracking solution seems 
fitting for this scenario.

Additionally, given we want flexibility to choose the piece and the length of the digit to generate, I decided to 
use the Strategy Design Pattern. This is due to the need to change the algorithm that is used to generate the numbers
based on the type of piece and how they will move on the board.

I chose a single level inheritance based implementation as there were some utility methods that are common to all derived
strategies. Interface composition can also be used and it does come with more repetition. 

### Implementation
In the NumberGenerationStrategy checks/condition methods, I sacrificed a bit of repetition for better readability. 
Rather than use a 'catch all' method to encapsulate all the checks, I left each
on their own so as you are stepping through the code in each derived strategy, you can clearly see the condition
being looked at in context rather than having to switch to the base class and lose that context.

Since the actual implementation of the checks are in the base class, then changes are done in one place.
The same argument can be made for the situation described above. However, given the scope of this particular
problem, I went with the readability option.


### Testing
For this exercise, I just wrote minimal test cases to statisfy the majority of the conditions. In a production
system there would be many more unit tests to handle the cases I am not including here due to time contraint.