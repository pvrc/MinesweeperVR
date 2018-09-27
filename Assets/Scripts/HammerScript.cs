using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HammerScript : MonoBehaviour {

    private SteamVR_TrackedObject trackedObj;

    private SteamVR_Controller.Device Controller
    {
        get { return SteamVR_Controller.Input((int)trackedObj.index); }
    }

    public GameObject hammerPrefab;
    private GameObject hammer;
    private FixedJoint joint;

    void Awake()
    {
        trackedObj = GetComponent<SteamVR_TrackedObject>();
    }

    // Use this for initialization
    void Start () {
        hammer = Instantiate(hammerPrefab);
        joint = gameObject.AddComponent<FixedJoint>();
        joint.connectedBody = hammer.GetComponent<Rigidbody>();
        joint.breakForce = 10000;
        joint.breakTorque = 10000;
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
