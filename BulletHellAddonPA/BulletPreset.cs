using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;

namespace BulletHellAddonPA
{
    class BulletPreset
    {
        public Bullet[][] bullets { private set; get; }
        float[] rotations;

        [JsonProperty("time")]
        public float time;

        [JsonProperty("posX")]
        public float posX;

        [JsonProperty("posY")]
        public float posY;

        [JsonProperty("spawnRate")]
        public float spawnRate;

        [JsonProperty("spawnCount")]
        public int spawnCount;

        [JsonProperty("numberOfBullets")]
        public int numberOfBullets;

        [JsonProperty("bulletSpeed")]
        public float bulletSpeed;

        [JsonProperty("minRotation")]
        public float minRotation;

        [JsonProperty("maxRotation")]
        public float maxRotation;

        [JsonProperty("offsetRotation")]
        public float offsetRotation;

        [JsonProperty("isRandom")]
        public bool isRandom;

        //public int parentID { get; set; }
        public Vector2 position {
            get
            {
                return new Vector2(posX, posY);
            }
            set
            {
                posX = value.X;
                posY = value.Y;
            }
        }

        

        public BulletPreset() { }
        public void Init()
        {
            bullets = new Bullet[spawnCount][];
            rotations = new float[numberOfBullets];
            if (isRandom) RandomRotations();
            else DistributedRotations();
            for (int t = 0; t < spawnCount; t++)
            {
                bullets[t] = new Bullet[numberOfBullets];
                for (int i = 0; i < numberOfBullets; i++)
                {
                    bullets[t][i] = new Bullet(bulletSpeed, t * spawnRate, spawnRate, rotations[i], position);
                }
            }
        }
        public float[] RandomRotations()
        {
            for (int i = 0; i < numberOfBullets; i++)
            {
                rotations[i] = (float)Math.Clamp(Program.random.NextDouble() * maxRotation, minRotation, maxRotation);
            }
            return rotations;
        }
        public float[] DistributedRotations()
        {
            for (int i = 0; i < numberOfBullets; i++)
            {
                var fraction = (float)i / ((float)numberOfBullets - 1f);
                var difference = maxRotation - minRotation;
                var fractionOfDifference = fraction * difference;
                rotations[i] = fractionOfDifference + minRotation; // We add minRotation to undo Difference
            }
            return rotations;
        }
    }
}
