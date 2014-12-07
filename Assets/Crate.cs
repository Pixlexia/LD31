using UnityEngine;
using System.Collections;

public class Crate : MonoBehaviour {
	void OnCollisionEnter2D(Collision2D col){
		if (col.gameObject.GetComponent<CanPushBlocks> () && col.gameObject.GetComponent<PlayerControl>().enabled) {
			rigidbody2D.isKinematic = false;		
		}
	}

	void OnCollisionExit2D(Collision2D col){
		if (col.gameObject.GetComponent<CanPushBlocks> ()) {
			rigidbody2D.isKinematic = true;		
		}
	}
}
