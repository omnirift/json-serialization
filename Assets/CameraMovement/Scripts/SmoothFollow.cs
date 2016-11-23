using UnityEngine;
using System.Collections;

public class SmoothFollow : MonoBehaviour {

    public Transform target;
    public float cameraSpeed = 15;
    public float zOffset = 22;
    public bool smoothFollow = true;

	// Update is called once per frame
	void Update () 
    {
        if (target)
        {
            Vector3 newPos = transform.position;
            newPos.x = target.position.x;
            newPos.z = target.position.z - zOffset;

            if (!smoothFollow) transform.position = newPos;
            else transform.position = Vector3.Lerp(transform.position, newPos, cameraSpeed * Time.deltaTime);
        }
	
	}
}
