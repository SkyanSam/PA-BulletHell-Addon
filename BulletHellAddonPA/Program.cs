using System;
using PA_PrefabBuilder;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.IO;

namespace BulletHellAddonPA
{
    // SKYAN STUPID IDIOT GO TO BulletPresetBuilder.cs
    class Program
    {
        static string gfxPrefabPath;
        public static GameObject[] graphicsObjects;
        static string jsonPath;
        static string exportedPrefabPath;
        public static Random random;
        public static float DegToRad = (float)(Math.PI / 180);
        static void Main(string[] args)
        {
            // GRAPHICS
            PrefabBuilder gfxPrefabBuilder = new PrefabBuilder("Graphics", PrefabType.Misc1, 0);
            random = new Random();
            Console.WriteLine("Path to prefab that you want to use as a bullet: ");
            gfxPrefabPath = Console.ReadLine();
            graphicsObjects = gfxPrefabBuilder.ImportPrefab(gfxPrefabPath).ToArray();
            Console.WriteLine("Graphics Objects Count " + graphicsObjects.Length);

            // PRESET STUFF
            Console.WriteLine("Path to JSON that has bullet preset data: ");
            jsonPath = Console.ReadLine();
            BulletPresetBuilder bulletPresetBuilder = new BulletPresetBuilder();
            BulletPresetBuilder.Init(ref bulletPresetBuilder, File.ReadAllText(jsonPath));

            // EXPORT STUFF
            PrefabBuilder prefabBuilder = new PrefabBuilder("bullet_preset", PrefabType.Misc1, 0);
            Console.WriteLine("Folder you would like to export bullet presets to: ");
            exportedPrefabPath = Console.ReadLine();
            bulletPresetBuilder.GetObjects(ref prefabBuilder.Objects);
            prefabBuilder.Export(exportedPrefabPath);

        }
    }
}
