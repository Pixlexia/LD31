using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SwitchHold : Switch {

	public List<GameObject> steppers;

	public override void Start(){
		steppers = new List<GameObject> ();
		base.Start ();
	}

	void OnTriggerStay2D(Collider2D col){
		state = true;

		if (col.gameObject.GetComponent<CanSwitchTraps> ()) {
			foreach (GameObject go in target) {
				if(go.GetComponent<SpikeShooter>())
					go.GetComponent<SpikeShooter>().Activate();
				else if(go.GetComponent<Spike>()){
					go.GetComponent<Spike>().Hold();
				}
			}
		}
	}
	
	void OnTriggerEnter2D(Collider2D col){
		if (col.gameObject.tag == "Player" || col.gameObject.tag == "Crate") {
			if(!steppers.Contains(col.gameObject)){
				steppers.Add (col.gameObject);
			}
			foreach(GameObject go in target){
				if(col.gameObject.GetComponent<CanOpenDoors>() && go.GetComponent<Door>()){
					go.GetComponent<Door>().Activate();
					state = true;
				}
				else if(go.GetComponent<SpikeShooter>() && col.gameObject.GetComponent<CanSwitchTraps>()){
					state = true;
					go.GetComponent<SpikeShooter>().Activate();
				}
			}
		}
	}

	void OnTriggerExit2D(Collider2D col){

		if (col.gameObject.tag == "Player" || col.gameObject.tag == "Crate") {
			steppers.Remove(col.gameObject);

				state = false;
			foreach(GameObject go in target){
				if(col.gameObject.GetComponent<CanSwitchTraps>()){
					if(steppers.Count < 1){
						if(go.GetComponent<Spike>())
							go.GetComponent<Spike>().Off();
						else if(go.GetComponent<SpikeShooter>())
							go.GetComponent<SpikeShooter>().Deactivate();
					}
				}
				else if(col.gameObject.GetComponent<CanOpenDoors>() && go.GetComponent<Door>()){
					go.GetComponent<Door>().Deactivate();
				}
			}
		}
	}
}
