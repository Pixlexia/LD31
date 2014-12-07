using UnityEngine;
using System.Collections;

public class Spike : MonoBehaviour {

	public bool activated, selfActivating;

	void Start(){
		if (activated)
			Activate ();
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
		if (!activated && selfActivating){
			Activate ();

			if(col.gameObject.tag == "Player")
				col.gameObject.GetComponent<Player>().Die ();
		}
		else if (activated && col.gameObject.tag == "Player") {
			Activate();		
			col.gameObject.GetComponent<Player>().Die();
		}
	}
}
