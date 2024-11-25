# Kieran-OutplayTest

Hello, Outplay Team, this is my submission for the test. Each exercise is organised into each of 
there respective folders in the same Unity project. Each one has a scene which you can run to 
test out my submission. Please let me know if there are any issues with the application.

All my documentation is through commenting in the code, if you need a separate document for me to 
go over the project, please let me know and I will get one written up.

How to test:

Exercise one:

To test exercise one all you need to do is click on the ball 
object in the hierarchy and change some of the values within 
it and click run, debug messages will be outputted representing the results. 
The current setup can only handle gravity going downwards.

Exercise two:

To test this, it is the same as exercise one just click 
the board in the hierarchy and change the values within. 
this one has a seed value which is used for the random generator to get different boards.
A board will be displayed on screen representing the Jewels 
and the result will be outputted through a debug message.

If the best score is equal to 2 it means that there is no valid move

Exercise 3:

This one is slightly different there are 3 key objects to look at first is the main object 
which you can add more points to if wanted as well as change the speed.
 
Second Object is Main Object Points which is a storage for three game objects which is 
currently used so that the designers can move them to change the path of the main objects. 

Last Object is the GameManager which you can change the values which represents the area 
that the obstacles can spawn in. 

when the play button is hit the Main Object should follow the path and disappear whenever 
it hits an obstacle or reaches the end point and play both the audio and particle system.
