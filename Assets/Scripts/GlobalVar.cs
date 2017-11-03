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
        public bool PassThrough;
        public Transform location;

        public EnvObject(bool v, Transform platform) : this()
        {
            PassThrough = v;
            location = platform;
        }
    }
}