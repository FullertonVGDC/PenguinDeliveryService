using System;
using System.Collections.Generic;
using UnityEngine;

namespace GlobalVar
{
    public class EnvBluePrint
    {
        public List<EnvObject> ListObject;
        public List<Enemy> ListEnemy;
        public String Background;
        public Transform StartLoc;
        public Transform EndLoc;
        public EnvBluePrint()
        {
            ListObject = new List<EnvObject>();
            ListEnemy = new List<Enemy>();
        }
    }

    public class Enemy
    {
    }

    [Serializable]
    public struct EnvObject
    {
        public int type;
        public Vector3 location;

        public Quaternion rotation;

        public Vector3 scale;

        public EnvObject(int v, Vector3 platform, Quaternion rot, Vector3 sca) : this()
        {
            type = v;
            location = platform;
            rotation = rot;
            scale = sca;
        }
    }
}