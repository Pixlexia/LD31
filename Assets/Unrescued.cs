using UnityEngine;
using System.Collections;

public class Unrescued : MonoBehaviour {

	public CircleCollider2D b;

	void OnTriggerEnter2D(Collider2D col){
		if(col.gameObject.GetComponent<PlayerControl>()){
			// character rescued
			GameObject.Find ("_GM").GetComponent<PlayerMaster> ().characters.Add (gameObject);
			GameObject.Find ("_GM").GetComponent<PlayerMaster> ().characters [0].GetComponent<FollowPlayer> ().target = gameObject;
			
			GetComponent<FollowPlayer> ().enabled = true;
			GetComponent<FollowPlayer> ().isRescued = true;
			
			Destroy (b);
			Destroy (GetComponent<Unrescued> ());
		}
	}
}