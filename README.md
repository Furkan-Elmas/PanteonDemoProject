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

Goal: \
Player must reach to the finish line without touching any obstacle or falling down.
Opponents can win too. So player must be quick. If any opponent arrives the finish line before player the game will be over.

You can find a playable .exe file in BuildFolders.

## Development Process
In this project it was tried stick to Object-Oriented Programming and S.O.L.I.D principles. Therefore each class was generated with Single-responsibility principle.

All variables are named clear and understandable. Also supported with comment lines.

Singleton, Object Pooling, Observer design patterns are used.

Navigation Mesh Agent Unity Tool is used for enemy AI. But there are some bugs, like-> opponents are not moving back to start line after game stopped.

There are placed 2 Camera for painting game. Painting camera is viewing a RenderTexture to create. 
Game camera is viewing the painting wall that has RenderTexture.

If there is anything you want to say please connect me or send a pull-request.

Best Regards
Furkan Elmas
