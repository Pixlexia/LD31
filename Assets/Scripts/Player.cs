using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {
	public ColoredPath.MyColor colortype;
	public float respawnTime, respawnCounter;
	public bool isAlive;

	// Particles
	public GameObject dieParticle1, playerColorParticle, keyParticle;

	// Use this for initialization
	void Start () {
		Spawn ();
		respawnTime = 5;
	}

	public void Spawn(){
		isAlive = true;
	}

	void Update(){
		if (!isAlive) {
			respawnCounter -= Time.deltaTime;

//			if(respawnCounter <= 0)
//				Enable();
		}
	}

	// Update is called once per frame
	void FixedUpdate () {
		rigidbody2D.velocity = Vector2.Lerp (rigidbody2D.velocity, Vector2.zero, 0.2f);
	}
	
	public void Die(){
		if (dieParticle1 && playerColorParticle) {
			Instantiate (dieParticle1, transform.position + new Vector3(0,0.3f,0), Quaternion.identity);
			GameObject p = Instantiate (playerColorParticle, transform.position + new Vector3(0,0.3f,0), Quaternion.identity) as GameObject;
//			Debug.Log (transform.GetChild(0).GetComponent<SpriteRenderer>().color);
//			Debug.Log (p);
			p.GetComponent<ParticleSystem>().startColor = transform.GetChild(0).GetComponent<SpriteRenderer>().color;
		}

		GetComponent<PlayerControl> ().move = Vector2.zero;

		GameObject.Find ("_GM").GetComponent<PlayerMaster>().Die ();
		isAlive = false;
		respawnCounter = respawnTime;

		if (!GetComponent<PlayerControl> ().enabled)
			Disable ();
	}

	public void Disable(){
		// Disable
		collider2D.enabled = false;
		GetComponent<PlayerControl> ().enabled = false;
		GetComponent<bodyMovement> ().enabled = false;
		SetSprites (false);
	}

	void Enable(){
		isAlive = true;
		collider2D.enabled = true;
		GetComponent<bodyMovement> ().enabled = true;
		SetSprites (true);
	}

	void SetSprites(bool b){
		for(int i=0; i< transform.childCount; i++)
		{
			var child = transform.GetChild(i).gameObject;
			if(child != null)
				child.SetActive(b);
		}
	}
	
	void OnTriggerEnter2D(Collider2D col){
		if (col.gameObject.tag == "Deadly") {
//			Die ();
		}
		else if(col.gameObject.tag == "Key"){
			PlayerMaster.hasKey = true;
			Destroy (col.gameObject);
			Instantiate(keyParticle, transform.position, Quaternion.identity);
		}
	}
}
