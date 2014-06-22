using UnityEngine;
using System.Collections;

public class DestructBuildingScript : MonoBehaviour {

	public GameObject toSpawn;
	public float speed = 1.0f;
	public bool destruct = false;
	public bool instance = false;
	public int d_building = 0;

	// Use this for initialization
	void Start () {
		//GameObject go = GameObject.Find("MovePeopleScript");
		//MovePeopleScript MovePeople = go.GetComponents <MovePeopleScript> ();
		//MovePeople = gameObject.GetComponent<MovePeopleScript>();
	}
	
	// Update is called once per frame
	void Update () {
		if (destruct) {
			if (!instance) {
				Instantiate(toSpawn, transform.position, transform.rotation);
				instance = true;
				d_building += 1;
			}			
			speed += 4 * Time.deltaTime;
			transform.Translate (new Vector3 (0, -Time.deltaTime * speed, 0), Space.World);
			if (transform.position.y < -15) {
				Destroy(gameObject);

			}
			Debug.Log(d_building);
		}
	}
}
