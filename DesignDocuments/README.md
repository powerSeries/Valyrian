# Program Organization

![High Level Architecture](https://github.com/powerSeries/Valyrian/blob/develop/DesignDocuments/high_level.png)

| Component | Description | Story ID |
|:----------|:------------|:--------:|
| Scene Controller | The Scene controller has a list of scenes that is used in the program. It also has a script that allows you to switch between the scenes. | VN-16 |
| Scene | The has with it a canvas which is what Unity uses to allow for the creation of Text, Images, and many other things as well to display on the screen. It also has a main camera that allows the user to see what is in the scene. | N/A |
|CreateGame|This scene allows the player to create a lobby for other player to load in and be able to play. It communicates with a server that allows for the network capabilities to the lobby. Once all players have joined you can then load into the Arena. You can also move back to the main menu if you change your mind on creating a game.|VN-15 VN-16 VN-12 VN-17|  
|JoinGame| This scene allows the user to enter the lobby code to be able to join other players. Just like CreateGame the player is also allowed to go back to the main menu.|VN-12 VN-14 VN-16|
|TitleScreen| In this scene we have the option to either create a game or to join a existing game. Depending on what the player chooses he will be moved to the next appropriate screen based on their selection.|VN-13 VN-16|
|Arena| The arena is the main area that the players will load in and be able to fight other players. It takes to load in because of all the models that are placed in and as well as all the items spawning.|VN-8|

