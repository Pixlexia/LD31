using UnityEngine;
using System.Collections;

public class Spike : MonoBehaviour {

	public bool activated, selfActivating;

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
		if (col.gameObject.tag == "Player" && selfActivating) {
			Activate();		
			col.gameObject.GetComponent<Player>().Die();
		}
	}

	void OnTriggerExit2D(Collider2D col){
//		if (col.gameObject.tag == "Player") {
//		}
	}
}
