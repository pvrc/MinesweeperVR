using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlagScript : MonoBehaviour {

    private SteamVR_TrackedObject trackedObj;

    private SteamVR_Controller.Device Controller
    {
        get { return SteamVR_Controller.Input((int)trackedObj.index); }
    }

    public GameObject flagPrefab;
    private GameObject flag;
    private FixedJoint joint;

    void Awake()
    {
        trackedObj = GetComponent<SteamVR_TrackedObject>();
    }
    // Use this for initialization
    void Start () {
        flag = Instantiate(flagPrefab);
        joint = gameObject.AddComponent<FixedJoint>();
        joint.connectedBody = flag.GetComponent<Rigidbody>();
        joint.breakForce = 10000;
        joint.breakTorque = 10000;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
