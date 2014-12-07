using UnityEngine;
using System.Collections;

public class SwitchHold : Switch {

	void OnTriggerStay2D(Collider2D col){
		state = true;

		foreach (GameObject go in target) {
			if(go.GetComponent<SpikeShooter>())
				go.GetComponent<SpikeShooter>().Activate();
		}
	}
	
	void OnTriggerEnter2D(Collider2D col){
		state = true;

		if (col.gameObject.tag == "Player") {
			foreach(GameObject go in target){
				if(go.GetComponent<Spike>())
					go.GetComponent<Spike>().Activate();
				else if(go.GetComponent<Door>())
					go.GetComponent<Door>().Activate();
				else if(go.GetComponent<SpikeShooter>())
					go.GetComponent<SpikeShooter>().Activate();
			}
		}
	}

	void OnTriggerExit2D(Collider2D col){
		state = false;

		if (col.gameObject.tag == "Player") {
			foreach(GameObject go in target){
				if(go.GetComponent<Spike>())
					go.GetComponent<Spike>().Deactivate();
				else if(go.GetComponent<SpikeShooter>())
					go.GetComponent<SpikeShooter>().Deactivate();
			}
		}
	}
}
