using UnityEngine;
using System.Collections;

public class Spike : MonoBehaviour {

	public bool activated;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Space)) {
			Activate();		
		}
	}

	public void Switch(bool b){
		if (b)
			Activate ();
		else
			Deactivate();
	}

	public void Activate(){
		activated = true;

		transform.GetChild(0).gameObject.SetActive(true);
	}

	public void Deactivate(){
		activated = false;
		transform.GetChild(0).gameObject.SetActive(false);
	}

	void OnTriggerEnter2D(Collider2D col){
		if (col.gameObject.tag == "Player") {
			Activate();		
		}
	}

	void OnTriggerExit2D(Collider2D col){
		if (col.gameObject.tag == "Player") {
			Deactivate();		
		}
	}
}
