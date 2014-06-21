using UnityEngine;
using System.Collections;

public class MovePeopleScript : MonoBehaviour {

	public float speed = 2.0f;
	public float timer = 0.0f;
	public Vector3 direction;
	public bool isPanic = false;
	public float timerPanic = 0.0f;
	public float delayPanic = 10.0f;
	public static int score = 0;

	// Use this for initialization
	void Start () {
		direction = new Vector3(Random.Range(-1.0f, 1.0f) * Time.deltaTime * speed, 0, Random.Range(-1.0f, 1.0f) * Time.deltaTime * speed);
	}
	
	// Update is called once per frame
	void Update () {
		float time = Time.deltaTime;
		timer += time;
		if (timer >= 3.0f)
		{
			timer = 0.0f;
			direction = new Vector3(Random.Range(-1.0f, 1.0f) * time * speed, 0, Random.Range(-1.0f, 1.0f) * time * speed);
		}
		transform.Translate(direction, Space.World);
		if (isPanic)
		{
			timerPanic += time;
		}
		if (timerPanic >= delayPanic)
		{
			speed = 2.0f;
			isPanic = false;
			timerPanic = 0.0f;
		}
	}

	void OnCollisionEnter() {
		float time = Time.deltaTime;
		direction = new Vector3(Random.Range(-1.0f, 1.0f) * time * speed, 0, Random.Range(-1.0f, 1.0f) * time * speed);
		timer = 0.0f;
	}

	public void Panic()
	{
		if (!isPanic)
		{
			Debug.Log("Panic");
			speed = 5.0f;
			isPanic = true;
            renderer.material.mainTexture = Resources.Load("habitant_dos_apercu") as Texture;
		}
	}
}
