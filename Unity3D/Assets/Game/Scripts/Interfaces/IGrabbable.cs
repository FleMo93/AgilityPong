using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Game.Scripts.Interfaces
{
    interface IGrabbable
    {
        Vector3 AnchorOffset { get; }
        void Grab(object sender);
        bool Drop(object sender);
        bool IsGrabbed { get; }

        event EventHandler GrabbedByAnotherOne;
    }
}
