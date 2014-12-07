using UnityEngine;
using System.Collections;

public class Checkpoint : MonoBehaviour {
	void OnTriggerEnter2D(Collider2D col){
		if (col.gameObject.tag == "Player") {
			if(col.gameObject.GetComponent<PlayerControl>().enabled){
				GameObject.Find ("_GM").GetComponent<PlayerMaster>().SaveCheckpoint(gameObject);
				GetComponent<SpriteRenderer> ().color = GameColors.colors["green"];
			}

		}

	}
}
