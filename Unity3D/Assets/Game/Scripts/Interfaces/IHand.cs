using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

namespace Assets.Game.Scripts.Interfaces
{
    interface IHand
    {
        SteamVR_Input_Sources HandType { get; }
        ICollection<Collider> GetHovers();
    }
}
