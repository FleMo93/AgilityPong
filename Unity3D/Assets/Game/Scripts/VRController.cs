using Assets.Game.Scripts.Interfaces;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;
using Valve.VR.InteractionSystem;

namespace Assets.Game.Scripts
{
    [RequireComponent(typeof(IHand))]
    public class VRController : MonoBehaviour
    {
        public SteamVR_Action_Boolean grabAction;
        public SteamVR_Action_Boolean resetBall;

        [SerializeField]
        private Transform _attachPoint;
        [SerializeField]
        private GameObject _otherHand;

        private IHand hand;
        private GrabbedObject grabbedObject;


        private void Start()
        {
        }

        private void OnEnable()
        {
            if (hand == null)
                hand = this.GetComponent<IHand>();

            if (grabAction == null)
            {
                Debug.LogError("<b>[SteamVR Interaction]</b> No plant action assigned");
                return;
            }

            grabAction.AddOnChangeListener(
                OnGrab,
                hand.HandType);

            //resetBall.AddOnChangeListener(
            //    ResetBall,
            //    hand.HandType
            //    );
        }

        private void OnGrab(SteamVR_Action_Boolean fromAction, SteamVR_Input_Sources fromSource, bool newState)
        {
            if (newState)
            {
                if (grabbedObject != null)
                {
                    Drop();
                }
                else
                {
                    Grab();
                }
            }
        }

        private void Grab()
        {
            grabbedObject = GetObjectToGrab();

            if(grabbedObject == null)
            {
                return;
            }

            grabbedObject.GameObject.transform.SetParent(_attachPoint);
            grabbedObject.GameObject.transform.localRotation = Quaternion.identity;
            grabbedObject.GameObject.transform.position = Vector3.zero;
            grabbedObject.GameObject.transform.localPosition = grabbedObject.Grabbable.AnchorOffset;
            grabbedObject.Grabbable.Grab(this);
            grabbedObject.Grabbable.GrabbedByAnotherOne += Grabbable_GrabbedByAnotherOne;
            return;
        }

        private void Grabbable_GrabbedByAnotherOne(object sender, EventArgs e)
        {
            this.grabbedObject.Grabbable.GrabbedByAnotherOne -= Grabbable_GrabbedByAnotherOne;
            this.grabbedObject = null;
        }

        private GrabbedObject GetObjectToGrab()
        {
            foreach (Collider collider in hand.GetHovers())
            {
                IGrabbable grabbable = collider.GetComponent<IGrabbable>();
                if (grabbable != null)
                {
                    return new GrabbedObject(collider.gameObject, grabbable);
                }
            }

            return null;
        }

        private void Drop()
        {
            grabbedObject.GameObject.transform.SetParent(null);
            grabbedObject.Grabbable.Drop(this);
            grabbedObject.Grabbable.GrabbedByAnotherOne -= Grabbable_GrabbedByAnotherOne;
            grabbedObject = null;
        }
    }
}