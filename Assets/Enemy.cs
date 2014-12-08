using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {
	public GameObject[] targets;
	public GameObject target;
	public float speed;
	public GameObject eyebrows;
	public bool isMoving;

	public Color stunnedBodyColor, stunnedLegColor;
	public GameObject body, leg1, leg2;
	Color origBodyColor, origLegColor;

	public bool patroling, followPlayer;
	int currentTarget;

	// status effect
	bool isStunned;
	float stunTimer, stunCount;

	float origSpeed;

	// Use this for initialization
	void Start () {
		stunTimer = 5;

		currentTarget = 0;

		if(targets.Length > 0)
			target = targets [0];

		origSpeed = speed;

		origBodyColor = body.GetComponent<SpriteRenderer> ().color;
		origLegColor = leg1.GetComponent<SpriteRenderer> ().color;
	}
	
	// Update is called once per frame
	void Update () {
		if (isStunned) {
			stunCount -= Time.deltaTime;

			if(stunCount <= 0){
				UnStun();
			}
		}
		else{
			
			if (patroling && targets.Length > 0){
				Patrol ();
			}
			else if(followPlayer){
				FollowPlayer();
			}

			if(target){
				isMoving = true;
				transform.position = Vector3.MoveTowards (transform.position, target.transform.position, speed * Time.deltaTime);
			}
		}
	}

	void Patrol(){
		if (Vector3.Distance (transform.position, targets[currentTarget].transform.position) < 0.2f) {
			currentTarget = (currentTarget == targets.Length-1)? 0 : currentTarget+1;
			target = targets[currentTarget];
		}

		// check if players are near
		GameObject[] players = GameObject.FindGameObjectsWithTag ("Player");
		foreach (GameObject p in players) {
			if(Vector3.Distance (transform.position, p.transform.position) < 4){
				// start chasing
				patroling = false;
				followPlayer = true;
				target = p;
				speed = 3.5f;

				eyebrows.SetActive(true);
			}
		}
	}

	void FollowPlayer(){
		if (Vector3.Distance (transform.position, target.transform.position) > 5) {
			// stop chasing if player is too far
			StopChasing();
		}
	}

	void StopChasing(){
		followPlayer = false;
		patroling = true;
		target = targets[currentTarget];
		speed = origSpeed;
		
		eyebrows.SetActive(false);
	}

	void OnTriggerEnter2D(Collider2D col){
		if (col.gameObject.tag == "Deadly") {
			Die ();		
		}
	}

	void OnCollisionEnter2D(Collision2D col){
		if (col.gameObject.tag == "Player") {
			col.gameObject.GetComponent<Player>().Die();	
			StopChasing();
		}
	}

	public void Stun(){
		isStunned = true;
		stunCount = stunTimer;

		body.GetComponent<SpriteRenderer> ().color = stunnedBodyColor;
		leg1.GetComponent<SpriteRenderer> ().color = stunnedLegColor;
		leg2.GetComponent<SpriteRenderer> ().color = stunnedLegColor;

		isMoving = false;
	}

	public void UnStun(){
		isStunned = false;
		body.GetComponent<SpriteRenderer> ().color = origBodyColor;
		leg1.GetComponent<SpriteRenderer> ().color = origLegColor;
		leg2.GetComponent<SpriteRenderer> ().color = origLegColor;

	}

	void Die(){
		Destroy (gameObject);
	}
}
