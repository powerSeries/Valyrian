# Design Documents

- [Program Organization](#Program-Organization)
- [Class Diagram](#Class-Diagram)
- [Major Classes](#Major-Classes)
- [Data Design](#Data-Design)
- [Business Rules](#Business-Rules)
- [User Interface](#User-Interface)
- [Build-vs-Buy Decisions](#Build-vs-Buy-Decisions)


## Program Organization

In Valyrian, we will start at the Title Screen, from here we can chose between whether or not we want to create a game or join an existing game. Depending on what chosen you will go to either the Create Game Screen or Join Game Screen. If you choose to create a game, you will be taken to Create Game Screen and will be asked to enter a room code. The room code is used so that other players can join your lobby. It will connect to the Photon Server and create a Lobby for players to join. If you had chosen to join a game it will take you to the Join Game Screen and will ask you to type in the room code. From there it will check in the server if a existing room is running with that code in the server and if there is space for you to join. Now when you are in the lobby screen depeding on who is the host decides when to start the game. When the host starts the game everyone will dropped into the Main level where everyone will be battling it. Once the game ends you will be taken back to the title screen.

![High Level Architecture](https://github.com/powerSeries/Valyrian/blob/develop/DesignDocuments/High%20Level%20Architecture.png)

|Architecture Component|User Story ID|
|:---------------------|:-----------:|
|Title Screen|VN-13 VN-16|
|Create Game Screen|VN-12 VN-15 VN-16 VN-17|
|Join Game Screen|VN-12 VN-14 VN-16|
|Server|VN-12|
|Lobby Screen|VN-12|
|Main Game Screen|VN-1 VN-2 VN-6 VN-7 VN-8 VN-10 VN-21 VN-22 VN-23 VN-31|

[Back to top](#Design-Documents)

## Class Diagram

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

[Back to top](#Design-Documents)

## Major Classes

| Class | Description |
|:------|:------------|
|Scene Controller| The scene controller allows us to change between create room menu and the join room menu. Without this class we would not be able to create the Arena where the players need to load in to.|
|Collider Controller| This class allows the player to collect both shield packs and ammo packs. It also keeps track of the amount of shield that the player has so that they don't exceed the set limit of 100. It also helps with displaying clearly onto the screen how much ammo/shield you have.|
|First Person Controller| This is essential to the player object. This class controls all the movement for the player (walking, sprinting, jumping, and looking around).|
|AutoGunMechanics| This class is used for the weapons to be able to fire and be able to see where the bullets are going. The gun will fire as if were a automatic rifle.|
|SemiGunMehanics|This class is used for the weapons to be able to fire and be able to see where the bullets are going. The gun will fire as if were a semi-automatic rifle.|
|ItemSpawn|This is an empty object that turns into the object that itemPrefab is set to. This is used to be able to spawn either a ammo pack or a shield pack within the level.|

[Back to top](#Design-Documents)

## Data Design

For this game we are not using any database to store any of objects. All the objects are stored within the Unity project. We also store values such as health, ammo, and shield within GameObjects. We are implementing a server that just establish a connection between other players and it loads the level with the player(s). We also are not storing any of the player information, so each time you play the game you are loading into the a new model with no previous information saved.

[Back to top](#Design-Documents)

## Business Rules

- Players are not allowed to regenerate health, but they can gain shield instantly. The reason for this was so when a player gets damaged they arent able to fully regenerate their health to 100%. We took this idea of not being able to regenerate health from CS:GO where the player cannot restore their own health throughout a round. So if a player wanted to gain 100 shield they would have to go search for the shield pack without encountering another player. 
  
- The ammo a player collects works across all guns. In most games you have to find ammos specific to the weapon that you find, so in games like Fortnite or Call of Duty if you find a shotgun you have to find shotgun shells for it. This gives player extra stress about being careful with the current resources they have. By removing that stress the player can focus more on the game. 

- Players are not allowed to bunny hop (B-hop), this is a technique that is used by exploiting the way physics engine works in various games. In CS:GO it preserves forward momentum and by jumping and strafing left and right when you jump you can increase your speed and be able to traverse the map faster. 

[Back to top](#Design-Documents)


## User Interface

**Disclaimer DO NOT CLICK IMAGE TO BE ABLE TO READ!** Zoom-in at the current screen you are at (Ideal Zoom 200%). Image was made in Illustrator with wrong dimensions.

![User Interface](https://github.com/powerSeries/Valyrian/blob/develop/DesignDocuments/User%20Interface%20Diagram.png)

[Back to top](#Design-Documents)

## Build-vs-Buy Decisions

### ProBuilder

Probuilder allows you to edit models within the editor with advanced features. It allows you to manipulate a list of objects any way that you want to. You extrude the object, subdivide some a face of the object. As well as being able to manipulate the object between either face of the object or its vertices. It also comes with some preset objects such as 'Stairs' it allows you to edit property of by determing how many steps you want the staircase to have. It has been very useful in creating the main building that is located at the certain of the level. 

### Photon Server

Allows us to add multiplayer capabilities to our game by providing us with a free server for us to load in our level and assets. It also is programmed to show player moments in real time, thus allowing for almost no latency between the player inputs and the server.

### Ensenasoft

Is a set of pre-made buildings that are used to fill the map with other structure to give players some cover.

### LowPolyNaturePackLite

Is a set of pre-made objects that are supposed to resemeble things you would find in nature. The pack includes various types of trees, bushes, some trees without any leaves on them. It also includes some objects that do not have the any material on them for you to apply your own texture.

[Back to top](#Design-Documents)
