using UnityEngine;
using System.Collections;

public class SwitchButton : Switch {

	void OnTriggerEnter2D(Collider2D col){
		state = !state;

		if (col.gameObject.tag == "Player") {
			foreach(GameObject go in target){
				if(switchType == TargetType.spike)
					go.GetComponent<Spike>().Switch(state);
				else if(switchType == TargetType.door)
					go.GetComponent<Door>().Activate();
			}
		}
	}

//	void OnTriggerExit2D(Collider2D col){
//		if (col.gameObject.tag == "Player") {
//			foreach(GameObject go in target){
//				if(switchType == SwitchType.spike)
//					go.GetComponent<Spike>().Deactivate();
//				//				else if(switchType == SwitchType.door)
//				//					go.GetComponent<Door>().Deactivate();
//			}
//		}
//	}
}
