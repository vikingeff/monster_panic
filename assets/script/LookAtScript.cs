using UnityEngine;
using System.Collections;

public class LookAtScript : MonoBehaviour {

	public Transform cam;
	public Vector3 diff;
	public bool collide;

	// Use this for initialization
	void Start () {
		collide = false;
		cam = Camera.main.transform;
		}
	
	// Update is called once per frame
	void Update () {
		transform.LookAt(cam);
		if (collide)
			cam.position = new Vector3(transform.position.x, 0, transform.position.z) - diff;
	}

	void OnCollisionEnter(Collision collision) {
        if (collision.collider.CompareTag("Ground") && !collide)
        {

        	diff = transform.position - cam.position;
        	collide = true;
        	rigidbody.constraints = RigidbodyConstraints.FreezePositionY;
        	rigidbody.useGravity = false;
        	rigidbody.drag = 1000;
        	rigidbody.velocity = Vector3.zero;
        }
    }
}
