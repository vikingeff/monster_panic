using UnityEngine;
using System.Collections;

public class InstantiateScript : MonoBehaviour {

	public GameObject monster;
	public int count = 0;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButton(0) && count == 0)
		{
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);    
			RaycastHit hit;
            if (Physics.Raycast (ray, out hit, 500f)) 
            {
            	if (hit.collider.CompareTag("Ground"))
                {
                	Vector3 pos = hit.point;
                	pos.y = 10;
					Instantiate(monster, pos, Quaternion.Euler(0, 0, 0));
					count++;
				}
            }
		}
	}
}
