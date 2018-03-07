// Generate Shrine
// Adds a command to generate one or more shrines.
// Most of this code is taken from Mods\WorldGen\DolphinShrine.cs

// Usage: /generateshrine [number],[size]
// number (optional) - The number of shrines you want to generate.
// size (optional) - A number from 1 to 20. Any bigger and it starts messing up the coordinates.

// Copyright (c) Strange Loop Games. All rights reserved.
// See LICENSE file in the project root for full license information.

namespace Eco.Mods
{
    using Eco.Gameplay.Systems.Chat;
    using Eco.Gameplay.Players;
    using Eco.World;
    using Eco.World.Blocks;
    using Eco.Gameplay.Objects;
    using Eco.Shared.Utils;
    using Eco.Shared.Math;
    using System;

    public class GenerateShrineCommands : IChatCommandHandler
    {
        [ChatCommand("Generates a shrine.", ChatAuthorizationLevel.Admin)]
        public static void GenerateShrine(User user, int numberOfShrines = 1, int shrineSize = 12)
        {
			if(shrineSize < 1 || shrineSize > 20)
            {
                ChatManager.DebugAddToChatLog("#Shrine location", "Shrine size must be between 1 and 20", user.Name, 1);
                return;
            }

            for (int i = 0; i < numberOfShrines; ++i)
            {
                var location = World.GetRandomLandPos() + (Vector3i.Down * (shrineSize * 2));

                location.SpiralOutXZIter(shrineSize).ForEach(x =>
                {
                    var height = Math.Min((shrineSize * 0.5f), (shrineSize * 0.6f) - WorldPosition3i.Distance(x, location));
                    for (int j = 0; j < height; ++j)
                    {
                        if (!World.GetBlock((Vector3i)x + (Vector3i.Up * j)).Is<Impenetrable>())
                            World.DeleteBlock((Vector3i)x + (Vector3i.Up * j));
                        if ((int)WorldPosition3i.Distance(x, location) != 0 && !World.GetBlock((Vector3i)x + (Vector3i.Down * j)).Is<Impenetrable>())
                            World.SetBlock<WaterBlock>((Vector3i)x + (Vector3i.Down * j));
                    }
                });
                WorldObjectUtil.Spawn("EckoStatueObject", null, (Vector3i)location);

                ChatManager.DebugAddToChatLog("#Shrine location", location.ToString(), user.Name, 1);
            }

        }
    }
}