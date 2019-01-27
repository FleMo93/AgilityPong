using Assets.Game.Scripts.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Game.Scripts
{
    [RequireComponent(typeof(Rigidbody))]
    class Bat : Grabbable
    {
        //[SerializeField]
        //private Transform ControllerAnchor;

        //public Vector3 AnchorOffset
        //{
        //    get
        //    {
        //        return this.transform.position - ControllerAnchor.localPosition;
        //    }
        //}

        //public bool IsGrabbed { get; private set; }

        //object grabbedBy;
        //Rigidbody rigbod;

        //public event EventHandler GrabbedByAnotherOne;

        //void Start()
        //{
        //    rigbod = GetComponent<Rigidbody>();
        //}

        //public bool Drop(object sender)
        //{
        //    if(!IsGrabbed)
        //    {
        //        Debug.LogWarning("Someone called drop, but the object is not grabbed");
        //        return false;
        //    }

        //    if(grabbedBy != sender)
        //    {
        //        Debug.LogWarning("Someone called drop but this object is not grabbed by the sender. Listen to the GrabbedByAnotherOne-Event to prevent this in the future.");
        //        return false;
        //    }

        //    rigbod.isKinematic = false;
        //    IsGrabbed = false;
        //    return true;
        //}

        //public void Grab(object sender)
        //{
        //    grabbedBy = sender;

        //    if (!IsGrabbed)
        //    {
        //        rigbod.isKinematic = true;
        //        IsGrabbed = true;
        //    }

        //    if (GrabbedByAnotherOne != null)
        //    {
        //        GrabbedByAnotherOne(this, new EventArgs());
        //    }
        //}
    }
}
