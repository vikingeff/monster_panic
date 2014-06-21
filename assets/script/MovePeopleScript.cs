using UnityEngine;
using System.Collections;

public class MovePeopleScript : MonoBehaviour {

	public GameObject deadBody;
	public float speed = 2.0f;
	public float timer = 0.0f;
	public Vector3 direction;
	public bool isPanic = false;
	public float timerPanic = 0.0f;
	public float delayPanic = 10.0f;
	public static int nb_panic = 0;
	public UnityEngine.Texture panicText;
	public UnityEngine.Texture normalText;
	public static float score = 0.0f;

	// Use this for initialization
	void Start () {
		direction = new Vector3(Random.Range(-1.0f, 1.0f) * Time.deltaTime * speed, 0, Random.Range(-1.0f, 1.0f) * Time.deltaTime * speed);
	}
	
	// Update is called once per frame
	void Update () {
		float time = Time.deltaTime;
		timer += time;
		if (timer >= 3.0f) {
				timer = 0.0f;
				direction = new Vector3 (Random.Range (-1.0f, 1.0f) * time * speed, 0, Random.Range (-1.0f, 1.0f) * time * speed);
		}
		transform.Translate (direction, Space.World);
		if (isPanic) {
				timerPanic += time;
		}
		if (timerPanic >= delayPanic) {
				speed = 2.0f;
				isPanic = false;
				timerPanic = 0.0f;
				renderer.material.mainTexture = normalText;
				nb_panic--;
		}
		if (nb_panic > 0)
			score += (16 * nb_panic); 
		Debug.Log(score);
	}

	void OnCollisionEnter(Collision collision) {
		if ((collision.gameObject.CompareTag ("People") || collision.gameObject.CompareTag ("Building")))
		{
			float time = Time.deltaTime;
			direction = new Vector3(Random.Range(-1.0f, 1.0f) * time * speed, 0, Random.Range(-1.0f, 1.0f) * time * speed);
			timer = 0.0f;
		}
	}

	public void Panic()
	{
		if (!isPanic)
		{
			speed = 5.0f;
			isPanic = true;
			nb_panic++;
            renderer.material.mainTexture = panicText;
		}
	}

	public void Die()
	{
		Vector3 pos = transform.position;
		pos.y = -1.8f;
		Instantiate(deadBody, pos, Quaternion.Euler(0, 0, 0));
		Destroy (gameObject);
		score += 5000;
		nb_panic--;
	}
}
