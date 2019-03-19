# Test Approach

- [Test Movement](#Test-Movement)
- [Test Jumping](#Test-Jumping)
- [Test Mouse Movement](#Test-Mouse-Movement)
- [Test Picking up Items](#Test-Picking-Up-Items)




## Test Movement

This test is for checking to see if the player model moves correctly on the
X-axis and Z-axis.

| Action |Observations|
|--------|------------|
| Double click on the Unity icon | Should open a window that has the list of projects available to open |
| Click on the project that says "Valyrian Game" | Unity should begin to load all the assets that is associated with that project |
| Under the Project tab click the folder named "Scenes" | You should see the different scenes that the project has access to |
| Double-click on the scene named "Walk Test" | In the Hierarchy tab on the top right, you should see a light, a cube, and the player model |
| Click on the player model | You should see in the inspector tab all the properties that is associated with the player model. Such things like position, rotation, scripts, etc. |
| At the top click the play button | This should begin the game and you will have control of the player model |
| Check the current position of the player model in the Inspector tab | The position will be in (x,y,z) form, so the start position of the player model should be near (0, 1.48, -12.5) |
| Press and hold W to move the player forward | When moving forward the x and z position should change and you should hear a sound as the player is moving forward. The Y position value should remain constant |
| Press and hold A to move the player to the left | When moving to the left the x and the z position will change and you should hear a sound as the player is moving to the left. The Y position value should remain constant |
| Press and hold S to move the player backwards | When moving forward the x and z position should change and you should hear a sound as the player is moving backwards. The Y position value should remain constant |
| Press and hold A to move the player to the right | When moving to the left the x and the z position will change and you should hear a sound as the player is moving to the right. The Y position value should remain constant |
| Press 'esc' key in order to make the mouse appear | You should see the cursor reappear on your screen |
| Press the play button at the top again to stop the game | Unity will then stop the game and put the player model back to the original position |


## Test Jumping

This test is for checking to see if the player model is able to jump properly. By checking if its Y position changes when he jumps.

| Action |Observations|
|--------|------------|
| Double click on the Unity icon | Should open a window that has the list of projects available to open |
| Click on the project that says "Valyrian Game" | Unity should begin to load all the assets that is associated with that project |
| Under the Project tab click the folder named "Scenes" | You should see the different scenes that the project has access to |
| Double-click on the scene named "Walk Test" | In the Hierarchy tab on the top right, you should see a light, a cube, and the player model |
| Click on the player model | You should see in the inspector tab all the properties that is associated with the player model. Such things like position, rotation, scripts, etc. |
| At the top click the play button | This should begin the game and you will have control of the player model |
| Check the current position of the player model in the Inspector tab | The position will be in (x,y,z) form, so the start position of the player model should be near (0, 1.48, -12.5) |
| Press 'space' to make the player model jump | You should see in the inspector tab that when you jump the only position that changes is the Y value |
| Begin to move forward by pressing 'W' and then jump as you are walking | You should see in the inspector tab that all the position value of the player model should change |
| Press 'esc' key in order to make the mouse appear | You should see the cursor reappear on your screen |
| Press the play button at the top again to stop the game | Unity will then stop the game and put the player model back to the original position |


## Test Mouse Movement



## Test Picking Up Items
