using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Handles : MonoBehaviour {

    public GameObject defensiveHandle1;
    public GameObject defensiveHandle2;
    public GameObject offensiveHandle1;
    public GameObject offensiveHandle2;

    private float lastLTouchZ = 0;
    private float lastRTouchZ = 0;

    // Use this for initialization
    void Start () {

        lastLTouchZ = OVRInput.GetLocalControllerPosition(OVRInput.Controller.LTouch).z;
        lastRTouchZ = OVRInput.GetLocalControllerPosition(OVRInput.Controller.RTouch).z;

    }
	
	// Update is called once per frame
	void Update () {

        if(OVRInput.Get(OVRInput.Button.One))
        {
            Vector3 pos = new Vector3(-0.0788f, 0.891f, 1.72f);
            GameObject.Find("Ball").transform.position = pos;
        }

        if (OVRInput.Get(OVRInput.Button.PrimaryHandTrigger) && OVRInput.Get(OVRInput.Button.SecondaryHandTrigger))
        {
            MoveBar(OVRInput.Controller.LTouch, defensiveHandle1);
            MoveBar(OVRInput.Controller.RTouch, defensiveHandle2);

            RotateBar(OVRInput.Controller.LTouch, defensiveHandle1);
            RotateBar(OVRInput.Controller.RTouch, defensiveHandle2);
        }

        if (OVRInput.Get(OVRInput.Button.PrimaryIndexTrigger) && OVRInput.Get(OVRInput.Button.SecondaryIndexTrigger))
        {
            MoveBar(OVRInput.Controller.LTouch, offensiveHandle1);
            MoveBar(OVRInput.Controller.RTouch, offensiveHandle2);

            RotateBar(OVRInput.Controller.LTouch, offensiveHandle1);
            RotateBar(OVRInput.Controller.RTouch, offensiveHandle2);
        }
    }

    void MoveBar(OVRInput.Controller controller, GameObject handle)
    {
        // back and forth movement
        Vector3 p = OVRInput.GetLocalControllerPosition(controller);
        Vector3 newPos = handle.transform.position;

        if(controller == OVRInput.Controller.LTouch)
        {
            newPos.z += (p.z - lastLTouchZ);
            lastLTouchZ = p.z;
        }
            

        if (controller == OVRInput.Controller.RTouch)
        {
            newPos.z += (p.z - lastRTouchZ);
            lastRTouchZ = p.z;
        }

        float min = handle.GetComponent<Rack>().minZ;
        float max = handle.GetComponent<Rack>().maxZ;

        if (newPos.z > min && newPos.z < max)
            handle.transform.position = newPos;
    }

    void RotateBar(OVRInput.Controller controller, GameObject handle)
    {
        Quaternion rot = OVRInput.GetLocalControllerRotation(controller);
        rot.x = 0;
        rot.y = 0;
        handle.transform.rotation = rot;
    }
}
