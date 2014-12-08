using UnityEngine;
using System.Collections;

public class JumpToRaftTrigger : MonoBehaviour {

	public GameObject raft;

	void OnTriggerEnter2D(Collider2D col){
		if (col.gameObject.GetComponent<Player>() && col.gameObject.GetComponent<PlayerControl> ().enabled) {
			Debug.Log ("asd");
		}
	}
}
