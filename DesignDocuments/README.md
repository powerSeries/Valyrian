# Class Diagram

![Class Diagram](https://github.com/powerSeries/Valyrian/blob/develop/DesignDocuments/Class%20Diagram.png)

| Component | Description | Story ID |
|:----------|:------------|:--------:|
| Scene Controller | The Scene controller has a list of scenes that is used in the program. It also has a script that allows you to switch between the scenes. |VN16|
| Scene | The has with it a canvas which is what Unity uses to allow for the creation of Text, Images, and many other things as well to display on the screen. It also has a main camera that allows the user to see what is in the scene. | N/A |
|CreateGame|This scene allows the player to create a lobby for other player to load in and be able to play. It communicates with a server that allows for the network capabilities to the lobby. Once all players have joined you can then load into the Arena. You can also move back to the main menu if you change your mind on creating a game.|VN15 VN16 VN12 VN17|  
|JoinGame| This scene allows the user to enter the lobby code to be able to join other players. Just like CreateGame the player is also allowed to go back to the main menu.|VN12 VN14 VN16|
|TitleScreen| In this scene we have the option to either create a game or to join a existing game. Depending on what the player chooses he will be moved to the next appropriate screen based on their selection.|VN13 VN16|
|Arena| The arena is the main area that the players will load in and be able to fight other players. It takes to load in because of all the models that are placed in and as well as all the items and weapons spawning.|VN8|
|PlayerObject| Is the main player model that we are using. The model has a few major scripts attached to it that allow it to pick up shield and ammo packs, as well as weapons.|VN1 VN2 VN22 VN23|
|ColliderController| This script at the start intializes the amount of ammo the player has to zero as well as the amount of shield to zero. When the player collides with ammo pack they will see in the bottom left their ammo cache to increase by 20. If they collide with a shield pack the bar above their health bar will increase to 25 and they will begin to see a blue bar to appear, this indicates the shield.|VN6 VN31|
|FirstPersonController| This controller is a standard asset that unity comes with that you can import it any scene. This is in charge of all the player movement such as walking, sprinting, jumping, and looking around. It comes with preset animations as well as sound when walking or sprinting. We tweeked the settings of the controller to fit to what we wanted.|VN1 VN2 VN21 VN22 VN23|
|AutoGunMechanics| This script is used to simulate a automatic rifle in the game. It also has animation and sound that is played whenever the gun is firing.|VN21|
|SemiGunMehanics| This is very similar to the AutoGunMechanic class except this one is used to simulate a rifle that fires based on the speed that you can press the left mouse click.|VN21|
|RayViewer| This class is used to see if we are displaying a Ray correctly within the scene that we are in. As well as being able to see if the ray is appearing at the correct position from the gun and traveling the correct range|VN21|
|ItemSpawn| This is an empty object that turns into the object that itemPrefab is set to. This is used to be able to spawn either a ammo pack or a shield pack within the level.|VN7 VN6 VN10|

# Major Classes

| Class | Description |
|:------|:------------|
|Scene Controller| The scene controller allows us to change between create room menu and the join room menu. Without this class we would not be able to create the Arena where the players need to load in to.|
|Collider Controller| This class allows the player to collect both shield packs and ammo packs. It also keeps track of the amount of shield that the player has so that they don't exceed the set limit of 100. It also helps with displaying clearly onto the screen how much ammo/shield you have.|
|First Person Controller| This is essential to the player object. This class controls all the movement for the player (walking, sprinting, jumping, and looking around).|
|AutoGunMechanics| This class is used for the weapons to be able to fire and be able to see where the bullets are going. The gun will fire as if were a automatic rifle.|
|SemiGunMehanics|This class is used for the weapons to be able to fire and be able to see where the bullets are going. The gun will fire as if were a semi-automatic rifle.|
|ItemSpawn|This is an empty object that turns into the object that itemPrefab is set to. This is used to be able to spawn either a ammo pack or a shield pack within the level.|


# Data Design

For this game we are not using any database to store any of objects. All the objects are stored within the Unity project. We also store values such as health, ammo, and shield within GameObjects. We are implementing a server that just establish a connection between other players and it loads the level with the player(s). We also are not storing any of the player information, so each time you play the game you are loading into the a new model with no previous information saved.

# Business Rules

- Players are not allowed to regenerate health, but can gain shield instantly.
- 

