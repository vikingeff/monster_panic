﻿using UnityEngine;
using System.Collections;

public class SpawnScript : MonoBehaviour {

	public GameObject toSpawn;
	public float timer = 0.0f;
	public float delay = 3.0f;
	public int nb_spawn = 10;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		//timer += Time.deltaTime;
		while (--nb_spawn > 0)
		//if (timer >= delay)
		{
			//timer = 0.0f;
			Instantiate(toSpawn, transform.position, Quaternion.Euler(0, 0, 0));
		}
	}
}
