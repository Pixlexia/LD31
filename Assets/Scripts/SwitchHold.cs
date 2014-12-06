using UnityEngine;
using System.Collections;

public class SwitchHold : Switch {

	void OnTriggerEnter2D(Collider2D col){
		state = true;

		if (col.gameObject.tag == "Player") {
			foreach(GameObject go in target){
				if(switchType == TargetType.spike)
					go.GetComponent<Spike>().Activate();
				//				else if(switchType == SwitchType.door)
				//					go.GetComponent<Door>().Activate();
			}
		}
	}

	void OnTriggerExit2D(Collider2D col){
		state = false;

		if (col.gameObject.tag == "Player") {
			foreach(GameObject go in target){
				if(switchType == TargetType.spike)
					go.GetComponent<Spike>().Deactivate();
				//				else if(switchType == SwitchType.door)
				//					go.GetComponent<Door>().Dectivate();
			}
		}
	}
}
