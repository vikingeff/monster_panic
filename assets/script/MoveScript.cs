using UnityEngine;
using System.Collections;

public class MoveScript : MonoBehaviour {

	public float speed = 10.0f;
	public float radius = 7.0f;
	public UnityEngine.Texture backText;
	public UnityEngine.Texture frontText;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		AnimatedTextureScript other = (AnimatedTextureScript)GetComponent(typeof(AnimatedTextureScript));
		other.rowNumber = 0;
		if (Input.GetKey("up")) {
			other.rowNumber = 1;
			renderer.material.mainTexture = backText;
			transform.Translate(new Vector3(Time.deltaTime * speed, 0, Time.deltaTime * speed), Space.World);
		}
		if (Input.GetKey ("down")) {
			other.rowNumber = 1;
			renderer.material.mainTexture = frontText;
			transform.Translate (new Vector3 (-Time.deltaTime * speed, 0, -Time.deltaTime * speed), Space.World);
		}
		if (Input.GetKey("left")) {
			other.rowNumber = 1;
			other.inverse = false;
			transform.Translate(new Vector3(-Time.deltaTime * speed, 0, Time.deltaTime * speed), Space.World);
		}
		if (Input.GetKey ("right")) {
			other.rowNumber = 1;
			other.inverse = true;
			transform.Translate (new Vector3 (Time.deltaTime * speed, 0, -Time.deltaTime * speed), Space.World);
		}
	    Collider[] hitColliders = Physics.OverlapSphere(transform.position, radius);
        int i = 0;
        while (i < hitColliders.Length) {
        	if (hitColliders[i].CompareTag("People"))
        	{
        		MovePeopleScript m = hitColliders[i].GetComponent<MovePeopleScript>();
        		m.Panic();
            }
            i++;
        }
	}

	void OnCollisionEnter(Collision collision) {
		if (collision.gameObject.CompareTag ("People")) {
			MovePeopleScript m = collision.gameObject.GetComponent<MovePeopleScript>();
			m.Die ();
		}
	}
}