using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class HandGrab : MonoBehaviour
{
    public bool grabState;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        grabState = SteamVR_Input.GetBooleanAction("GrabPinch").GetState(SteamVR_Input_Sources.RightHand);
    }

    private void OnTriggerStay(Collider other)
    {
        if (grabState)
        {
            /*j = gameObject.AddComponent<FixedJoint>();
            j.breakForce = 100000000;
            j.breakTorque = 100000000;*/
            if (other.transform.gameObject.name.Equals("hammer_mesh"))
            {
                other.transform.parent = transform;
            }
            

        }
    }
}
