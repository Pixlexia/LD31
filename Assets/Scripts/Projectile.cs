using UnityEngine;
using System.Collections;

public class Projectile : MonoBehaviour {

	public Vector3 dir;
	public float speed;
	public bool canCollideWithWalls = false;

	void Start(){
//		collider2D.enabled = false;
		Destroy (gameObject, 3f);

		if (dir.x != 0) {
			transform.Rotate(new Vector3(0,0,90));		
		}
	}

	// Update is called once per frame
	void Update () {
		transform.position += new Vector3 (dir.x * speed * Time.deltaTime, dir.y * speed * Time.deltaTime, 0);
//		StartCoroutine ("EnableCollider");
	}

	IEnumerator EnableCollider(){
		yield return new WaitForSeconds (0.05f);
		collider2D.enabled = true;
	}

	void OnTriggerEnter2D(Collider2D col){
		if (col.gameObject.tag == "Player") {
			col.GetComponent<Player> ().Die ();
			Destroy (this.gameObject);
		}
		else if(col.gameObject.tag == "Crate"){
			Destroy(gameObject);
		}
		else if (canCollideWithWalls) {
			Destroy (this.gameObject);
		}
	}

	void OnTriggerExit2D(Collider2D col){
		if (col.gameObject.tag == "Wall")
			canCollideWithWalls = true;
	}
}
