## Academy2021Assignment for Next Games by Juho Puurunen

## To test the game

`clone repository`
 
 Then open the project in Unity and choose GameScene from Scenes folder

## Game documentation
When I first watched the video about the gameplay for the assignment, I knew right away that I could compare the player's ball color component to the obsctacles color component. So I made a script that gets the game objects exact colors, so if they would be changed they would always still work in the game. The ball gets it's color with these values.
```c#
    orange = GameObject.Find("Orange").GetComponent<SpriteRenderer>().color;
    cyan = GameObject.Find("Cyan").GetComponent<SpriteRenderer>().color;
    pink = GameObject.Find("Pink").GetComponent<SpriteRenderer>().color;
    green = GameObject.Find("Green").GetComponent<SpriteRenderer>().color;
```
I wanted to test different kind of obstacles and how they would be passable, so I made everything straight to the GameScene. Bcause the assignment said this should only take one working day, I didn't take the time to implement the SpawnManager feature. But as I like the idea of the game, and I need more projects in my portfolio, I'm sure I'm gonna do that next, and build a browser playable version so I can put it in there. 

The Defeat sound given with the project wasn't to my liking, and Unity had some problems with it so I visited the site in the sounds_copyrighted.txt and found a sound that I preferred. 

## What features I'd like to add

 - Randomized spawner for obstacles, and a counter that could add spawnable obstacles as the player goes through levels, so the game could be an endless arcade type game. (Now just one level is hard set in the GameScene). I'd implement it by writing a script "SpawnManager", that would handle the spawning and use the level number as a multiplier for how many obstacles there are. Like "LevelNumber * (4 * LevelNumber)". Speeds of the rotation and movement could be randomized between certain points. Like "90-180".
 - Life feature. Player could gather up to three 'save lives', if the player hits the wrong color, they could reset in front of the obstacle if said power ups have been gathered. 
 - Slow feature. Player could gather a power up that could slow the next obstacle in sight. (Could be hard to implement in such a fast phased game, could be a pause to choose which obstacle to slow down, if there is blades inside the circle  or other multipart obsctacle etc.)
 - Pause button could be a good add on. 
 ```c#
 void PauseGame ()
    {
        Time.timeScale = 0;
    }

void ResumeGame ()
    {
        Time.timeScale = 1;
    }
```

## Bugs and issues
The sounds provided with the project dir. were in .flac format that in my knowledge Unity doesn't support. But when clicked as Ambisonic, they worked. But then the editor would complain about not having a ambisonic plugin. Tapping the option of as beign ambisonic would fix this issue. Weird.

The  stars scripted 'animation' "ScaleBehaviour" can be a performance issue, but in the editor there is no lag. I implemented it this way because I wanted to try it out.
