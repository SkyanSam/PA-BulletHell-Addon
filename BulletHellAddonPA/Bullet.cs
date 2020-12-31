using PA_PrefabBuilder;
using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;

namespace BulletHellAddonPA
{
    class Bullet
    {
        public GameObject bullet;
        public GameObject[] gfxList;
        public float speed;
        public float startTime;
        public float lifeTime;
        public float distance;
        public float rotation;
        public Vector2 startPosition;
        public Vector2 endPosition;
        
        public Bullet(float bulletSpeed, float startTime, float _lifetime, float rotation, Vector2 pos)
        {
            lifeTime = _lifetime;
            speed = bulletSpeed;

            // Creating GameObject
            bullet = new GameObject(Program.random.Next(0, 1000000).ToString(), "Bullet", Shapes.Triangle);
            bullet.Type = ObjectType.Empty;

             // Clone Graphics
            gfxList = new GameObject[Program.graphicsObjects.Length];
            for(int i = 0; i < Program.graphicsObjects.Length; i++) {
                gfxList[i] = Program.graphicsObjects[i].Clone();
                gfxList[i].ID = Program.random.Next(0, 100000000).ToString();
                gfxList[i].Parent = bullet.ID;
                gfxList[i].Type = ObjectType.Normal;
            }
            Console.WriteLine("gfxList Length: " + gfxList.Length);

            // Calculating Position & Rotation
            startPosition = pos;
            distance = speed * lifeTime;
            Vector2 dir = new Vector2((float)Math.Cos(Program.DegToRad * (double)rotation), (float)Math.Sin(Program.DegToRad * (double)rotation));
            endPosition = (dir * distance) + startPosition;

            // Setting Events for Position & Rotation
            bullet.AddEvent(EventType.pos, startTime, startPosition.X, startPosition.Y, Easing.Linear);
            bullet.AddEvent(EventType.pos, startTime + lifeTime, endPosition.X, endPosition.Y, Easing.Linear);
            bullet.AddEvent(EventType.rot, startTime, rotation, null, Easing.Linear);
        }
    }
}
