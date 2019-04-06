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
|PlayerObject| Is the main player model that we are using. The model has a few major scripts attached to it that allow it to pick up shield and ammo packs, as well as weapons.|VN1 VN2 VN21 VN22 VN23|
|ColliderController| This script at the start intializes the amount of ammo the player has to zero as well as the amount of shield to zero. When the player collides with ammo pack they will see in the bottom left their ammo cache to increase by 20. If they collide with a shield pack the bar above their health bar will increase to 25 and they will begin to see a blue bar to appear, this indicates the shield.|VN6 VN31|
|FirstPersonController| This controller is a standard asset that unity comes with that you can import it any scene. This is in charge of all the player movement such as walking, sprinting, jumping, and looking around. It comes with preset animations as well as sound when walking or sprinting. We tweeked the settings of the controller to fit to what we wanted.|VN1 VN2 VN21 VN22 VN23|

