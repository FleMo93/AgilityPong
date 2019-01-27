using Assets.Game.Scripts.Interfaces;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class Hand : MonoBehaviour, IHand
{
    [SerializeField]
    private SteamVR_Input_Sources _handType;
    public SteamVR_Input_Sources HandType { get { return _handType; } }

    [SerializeField]
    private float _hoverRadius = 0.075f;
    [SerializeField]
    private Transform _hoverPoint;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnDrawGizmos()
    {
        DrawHoverPoint();
    }

    private void DrawHoverPoint()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(_hoverPoint.transform.position, _hoverRadius);
    }

    public ICollection<Collider> GetHovers()
    {
        return Physics.OverlapSphere(_hoverPoint.transform.position, _hoverRadius);
    }
}
