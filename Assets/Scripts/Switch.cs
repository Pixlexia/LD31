using UnityEngine;
using System.Collections;

public class Switch : MonoBehaviour {

	public enum SwitchType { spike, door }
	public SwitchType switchType;

	public bool state = false;

	public GameObject[] target;

	void OnTriggerEnter2D(Collider2D col){
		state = !state;

		if (col.gameObject.tag == "Player") {
			foreach(GameObject go in target){
				if(switchType == SwitchType.spike)
					go.GetComponent<Spike>().Switch(state);
				//				else if(switchType == SwitchType.door)
				//					go.GetComponent<Door>().Switch(state);
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
