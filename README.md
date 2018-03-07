# Generate Shrine
Version 1.0

* Adds an admin command to generate one or more shrines at random locations in the world.
* Useful for adding a shrine to an older pre-7.2 world or just if you want more for some reason (pretty lights).
* Gives coordinates in chat that you can click to set a waypoint.
* You can pick them up with a hammer and place them somewhere else.

**Warning:** This will replace anything in the random location it picks. Make sure to backup your server before you use it!

Most of this code is taken from Mods\WorldGen\DolphinShrine.cs

**Usage:** /generateshrine [number],[size]
Parameters are optional.
number - (default: 1) The number of shrines you want to generate.
size - (default: 12) A number from 1 to 20. Any bigger and it starts messing up the coordinates.