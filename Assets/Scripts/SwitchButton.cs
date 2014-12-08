using UnityEngine;
using System.Collections;

public class SwitchButton : Switch {

	void OnTriggerEnter2D(Collider2D col){
		state = !state;

		if (col.gameObject.tag == "Player" || col.gameObject.tag == "Crate") {
			foreach(GameObject go in target){
				if(go.GetComponent<Spike>())
					Debug.Log ("Switch spike");
				else if(go.GetComponent<Door>())
					go.GetComponent<Door>().Activate();
				else if(go.GetComponent<ColoredPath>())
					go.GetComponent<ColoredPath>().Deactivate();
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
