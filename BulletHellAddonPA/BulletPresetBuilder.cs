using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using PA_PrefabBuilder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;

namespace BulletHellAddonPA
{
    class BulletPresetBuilder
    {
        [JsonProperty("presets")]
        public List<BulletPreset> presets = new List<BulletPreset>();
        public BulletPresetBuilder() {
            presets = new List<BulletPreset>();
        }
        public static void Init(ref BulletPresetBuilder builder, string json)
        {
            builder = JsonConvert.DeserializeObject<BulletPresetBuilder>(json);
            for (int i = 0; i < builder.presets.Count; i++)
                builder.presets[i].Init();
        }
        public void GetObjects(ref List<GameObject> objectList) {
            foreach (var preset in presets)
            {
                Console.WriteLine("preset");
                for (int bx = 0; bx < preset.bullets.Length; bx++)
                {
                    Console.WriteLine("bx" + preset.bullets.Length);
                    Console.WriteLine("by" + preset.bullets[bx].Length);
                    for (int by = 0; by < preset.bullets[0].Length; by++)
                    {
                        var bullet = preset.bullets[bx][by];
                        Console.WriteLine("bullet");
                        objectList.Add(bullet.bullet);

                        foreach (var gfx in bullet.gfxList)
                        {
                            objectList.Add(gfx);
                        }
                    }
                }
            }
            Console.WriteLine(objectList.Count);
        }
    }
}
