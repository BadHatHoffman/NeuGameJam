using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WanderState : IState
{
    public Vector3 destination;

    Transform objPos;
    float checkRadius;

    public WanderState(Transform obj, float checkRad)
    {
        objPos = obj;
        checkRadius = checkRad;
    }

    public void OnEnter()
    {
        destination = objPos.position + (Random.insideUnitSphere * checkRadius);
        destination.y = 0;
    }

    public void OnExit()
    {
        
    }

    public void Tick()
    {
        if(Vector3.Distance(objPos.position, destination) < .1f /*Or after a timer just in case*/)
        {
            destination = objPos.position + (Random.insideUnitSphere * checkRadius);
            destination.y = 0;
        }
    }
}
