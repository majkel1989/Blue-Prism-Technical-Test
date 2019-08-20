# Getting started

At the begining I have read carefully Test description and made some notes i.e. splitting app idea into small pieces\
I have created GitHub repository and console app using VSCode

# Step 1 - Console UI

Created simple console UI to interact with User and obtain needed parameters

# Step 2 - Parameters DTO

Created parameters DTO to store User parameters

# Step 3 - Parameters validation

Added Parameters validation & updated parameters DTO to make sure UI is fully ready to use

# Step 4 - Algorithm

1. At the beginning I tried to understand correctly the problem
2. Loaded only 4 letter long Words from the file, as mentioned in spec, which can make our Input list smaller
3. Remembered that years ago, while studing, I wrote an application which was calculating shortest path (using graphs) from Point A to B based on Dijkstra's algorithm
4. Above algorithm could be an over kill for our app and our input is not prepared for it so tried to figure something else out of it
5. Drew a picture of a Tree where Nodes where our Words (starting with Start Word) and Vertices where straight relations with Child Words that were Different by 1 Letter with Parent Word
6. Needed Lists of Chiled Words associeted to the Parent Word
7. Found BFS algorithm and implemented my own Queue to get above Lists, that BFS algorithm shown me the only one left piece of the logic I were missing which was Level of the Node
8. Implemented Dictionary to store all the Nodes information I needed (Parent Word, Node Level & List of Child Words)
9. Wrote function to get Result Words from above Dictionary and released that to make it look as expected I need to reverse it
10. Instead of reversing result list I switched in my algorithm Start Word & End Word together so now all looks as expected without any need to add additional step to reverse it

# Algorithm Complexity

Big Notation complexity (related to the algorithm code commented Steps):
1) While loop that checks if there is anything on the Queue before continue - worst possible scenario O(n) - can loop over all words in the dictionary
2) Foreach loop that iterates over all words that left in dictionary - worst possible scenario O(n - 1) - also can loop over all words in the dictionary but within each while loop iteration we delete at least 1 Word
3) IsWordValid() method to check if Child Word is different only by 1 letter from Parent Word - always O(m) where 'm' is specified Length of our Words
- Summing up our, worst case scenario, complexity is [O(n) * O(n - 1) * O(m)] which we can simplyfy to [O((n^2 - n) * m)]

# Summary - Refactor & Additions

Things that could be added/updated to improve application:
1. Interface for Algorithm class (if in the future we wanted to use different algorithms to solve our problem without updating existing code - similar way as made for UserInterface)
2. Parameter & Document Handler to move pieces of code there making code cleaner
3. Handle errors with try-catch blocks (preapre error handling standard)
4. Loging errors and user logs to make solving errors & maintaining app easier
5. Cache for Word List files - if the same file provided (and not changed) we could load it from cache
6. Create code comments standard over app logic (right now focused just on algorithm)
7. Parameters initialized manually in ConsoleInterface could be moved to App.config file and loaded on App start
8. Unit tests to cover app logic
9. Split Word Algorithm into following, separate logic, pieces (related to the algorithm code commented Steps) and Unit test them:\
a) STEP I: Global initialization - unit tested by checking if wrongly initialized tables are handled\
b) STEP II: Parent Node initialization - unit tested by checking if Parent Word initialized succesfully\
c) STEP III: Check if next Word is valid - unit tested by checking if IsWordValid() method returns correct value no matter what parameters are supplied\
d) STEP IV: Logic to Pop new valid word to the Queue for next iteration - unit tested by checking if Queue & Words Tree is updated correctly
