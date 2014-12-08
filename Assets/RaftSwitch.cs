using UnityEngine;
using System.Collections;

public class RaftSwitch : Switch {
	public GameObject blueSwitch;
	public GameObject raft;

	void OnTriggerEnter2D(Collider2D col){
		if (blueSwitch.GetComponent<SwitchHold>().state && col.gameObject.tag == "Player" && col.gameObject.GetComponent<PlayerControl> ().enabled
		    && raft.GetComponent<Raft>().count == 3) {
			state = true;
			Activate();
		}
	}

	void Update(){
		if(state)
			child1.localPosition = new Vector3 (child1.localPosition.x, -0.20f, child1.localPosition.z);
		else
			child1.localPosition = new Vector3 (child1.localPosition.x, -0.14f, child1.localPosition.z);
	}

	public void Activate(){
		GameObject.Find ("_GM").GetComponent<PlayerMaster> ().GameOver ();
		raft.GetComponent<Raft> ().startMoving = true;
	}
}
