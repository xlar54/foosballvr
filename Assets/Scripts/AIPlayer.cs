using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIPlayer : MonoBehaviour {

    public GameObject aiPlayerHandle;
    public GameObject[] handlesToRaise;

    public float rotationAmount = 90.0f;

    public bool rotating = false;

    public float angle = 60.0f;

    public float speed = 8.0f;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        if (rotating)
        {
           // aiPlayerHandle.transform.Rotate(0, 0, -rotationAmount * Time.deltaTime * speed);
            aiPlayerHandle.transform.rotation = Quaternion.Euler(0,0, Mathf.Sin(Time.time * speed) * angle);

            foreach (GameObject g in handlesToRaise)
            {
                SwingOpen(g);
            }
        }
		
	}

    void SwingOpen(GameObject g)
    {
        Quaternion newRotation = Quaternion.AngleAxis(90, Vector3.forward);
        g.transform.rotation = Quaternion.Slerp(g.transform.rotation, newRotation, .05f);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "Ball")
            rotating = true;
    }

    private void OnTriggerExit(Collider other)
    {
        rotating = false;
    }
}
