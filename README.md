### Project Arrythmia Bullet Hell Addon
A console application to easily make bullet hell presets from JSON (also supports custom graphics, not just basic shapes)

1a. Make a prefab that stores the graphics that will be used in each bullet.
1b. Then link to the prefab file in the console application.
`C:\Program Files (x86)\Steam\steamapps\common\Project Arrhythmia\beatmaps\prefabs\bullet_triangle.lsp`

2a. Make a json file following this format
```
{
    "presets" : [
        {
            "posX": 2,
            "posY": 2,
            "time": 5,
            "spawnCount": 2,
            "spawnRate": 0.5,
            "minRotation": 0,
            "maxRotation": 360,
            "offsetRotation":  15,
            "numberOfBullets": 8,
            "bulletSpeed": 10,
            "parentID": "null",
            "isRandom": false
        }
    ]
}
```
2b. Then in the console application link to the json file.
`D:\Documents\ProjectArrythmia\input.json`

3. In the console application link to the place where project arrythmia prefabs are stored on your device
`C:\Program Files (x86)\Steam\steamapps\common\Project Arrhythmia\beatmaps\prefabs`

There are still a few things that need to be fixed and I haven't exported an app that can be used without Visual Studio 2019/2017.

