using UnityEngine;
using System.Collections;

public class Controller : MonoBehaviour {

    public float speed = .5f;
    float hAxis;
    float vAxis;
    //Rigidbody rig;
    CharacterController controller;
    void Start()
    {
        controller = GetComponent<CharacterController>();
        //rig = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        
    }

	void Update () 
    {
        hAxis = Input.GetAxis("Horizontal");
        vAxis = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(hAxis, 0.0f, vAxis) * speed;
        controller.Move(movement);
        //rig.velocity = velocity * speed;
	}
}
