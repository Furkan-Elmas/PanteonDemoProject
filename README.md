# PanteonDemoProject Developed by Furkan Elmas
### Made with Unity 2020.3.35f1
---

## Game Content
Game Genre: \
Platform Runner

Game Perspective: \
Third Person Camera

Core Mechanics: \
This is a race. 10 opponents against player. Each movable character can ineract any object in the game area.
There are 4 types of obstacle and 2 types of platforms. 3 obstacles are movable and one of them is static.
Also there are a rotating platform and a flat platform.
Player can move with touching the screen and can swerve character with sliding.
There is a wall painting game after running game.

Goal: \
Player must reach to the finish line without touching any obstacle or falling down.
Opponents can win too. So player must be quick. If any opponent arrives the finish line before player the game will be over.

You can find a playable .exe file in BuildFolders.\
![Gameplay](https://user-images.githubusercontent.com/98258752/177772531-b36c27c5-5ef8-4da1-b4de-a96e6ae7ff37.png)
![Paint](https://user-images.githubusercontent.com/98258752/177772970-20748927-b642-4bed-aa4c-831b444ff948.png)


## Development Process
In this project it was tried stick to Object-Oriented Programming and S.O.L.I.D principles. Therefore each class was generated with Single-responsibility principle.

All variables are named clear and understandable. Also supported with comment lines.

Singleton, Object Pooling, Observer design patterns are used.

Navigation Mesh Agent Unity Tool is used for enemy AI. But there are some bugs, like-> opponents are not moving back to start line after game stopped.

There are 2 Camera placed the game area for painting game. Painting camera is viewing a RenderTexture to create. 
Game camera is viewing the painting wall that has RenderTexture. \
![Scene](https://user-images.githubusercontent.com/98258752/177772732-f367c5bd-a928-474e-8ea0-0b24b7d519ae.png)


If there is anything you want to say please connect me or send a pull-request.

Thanks for reading, \
Furkan Elmas
