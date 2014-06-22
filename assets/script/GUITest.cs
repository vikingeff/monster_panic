using UnityEngine;
using System.Collections;

public class GUITest : MonoBehaviour {

	//public TextMesh super_score;
	public GUIText super_score;
	public MovePeopleScript Move;

	void Start() {
    }
   
    void Update() {
    	super_score.text = "pouet";
    	move = GameObject.GetComponent<MovePeopleScript>();
   		move.score = 7777;
    }

	void OnGUI () {
	}
}
