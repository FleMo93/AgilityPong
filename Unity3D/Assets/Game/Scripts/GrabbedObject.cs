using Assets.Game.Scripts.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Game.Scripts
{
    class GrabbedObject
    {
        public GameObject GameObject { get; }
        public IGrabbable Grabbable { get; }

        public GrabbedObject(GameObject gameObject, IGrabbable grabbable)
        {
            this.GameObject = gameObject;
            this.Grabbable = grabbable;
        }
    }
}
