using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerMaster : MonoBehaviour {
	public Camera cam;
	public List<GameObject> characters;
	public int currentChar;
	public static bool hasKey;
	public bool isFollowing, gameover;
	public GameObject checkpoint;

	public GameObject raft;

	// die timer
	bool respawning;
	float respawnTimer = 1, respawnCount;

	// Use this for initialization
	void Start () {
		Physics2D.IgnoreLayerCollision (8, 8);
		currentChar = 0;
		isFollowing = true;
	}
	
	// Update is called once per frame
	void Update () {
		if (!gameover) {
			if (characters.Count > 1) {
				if (Input.GetKeyDown (KeyCode.Q)) {
					SwitchNext();
				}
				else if(Input.GetKeyDown(KeyCode.E)){
					SwitchPrev ();
				}
				
				if (Input.GetKeyDown (KeyCode.Space)) {
					BreakGroup();		
				}
			}
			
			if (respawning) {
				respawnCount -= Time.deltaTime;
				if(respawnCount <= 0){
					Respawn();
					respawning = false;
				}
			}
		}
	}

	public void Die(){
		respawning = true;
		respawnCount = respawnTimer;

		characters [currentChar].GetComponent<PlayerControl> ().enabled = false;
//		SwitchPrev ();
	}

	void Respawn(){
		foreach (GameObject g in characters) {
			g.GetComponent<Player>().Respawn(checkpoint.transform.position);
		}
		characters [currentChar].GetComponent<Player> ().RespawnController (checkpoint.transform.position);
	}

	public void SaveCheckpoint(GameObject g){
		checkpoint = g;
	}

	void SwitchNext(){
		DisableCurrentCharControl();
		
		if(currentChar > 0)
			currentChar--;
		else
			currentChar = characters.Count - 1;
		
		
		SwitchPlayer();
	}

	void SwitchPrev(){
		DisableCurrentCharControl();
		
		if(currentChar < characters.Count - 1)
			currentChar++;
		else
			currentChar = 0;
		
		SwitchPlayer();
	}

	void BreakGroup(){
		isFollowing = !isFollowing;
		foreach (GameObject go in characters) {
			if(go.GetComponent<FollowPlayer>().isRescued)
				go.GetComponent<FollowPlayer>().enabled = isFollowing;
		}

		if (isFollowing)
			characters [currentChar].GetComponent<FollowPlayer> ().enabled = false;
	}

	void BreakFromGroup2(){
		if (!characters [currentChar].GetComponent<FollowPlayer> ().brokenFromGroup) {
			int i = 0;
			
			i = (currentChar < characters.Count - 1) ? currentChar + 1 : 0;
			
			characters [i].GetComponent<FollowPlayer> ().enabled = false;
			characters [currentChar].GetComponent<FollowPlayer> ().BreakFromGroup ();
		}
		else{
			characters [currentChar].GetComponent<FollowPlayer> ().ConnectToGroup ();
			GetFollower (currentChar).GetComponent<FollowPlayer>().enabled = true;
		}
	}

	void SwitchPlayer(){
		cam.gameObject.GetComponent<LerpToTarget> ().target = characters [currentChar];
		Debug.Log (characters [currentChar].name);
		EnableCurrentCharControl ();
	}
	
	void DisableCurrentCharControl(){
		characters [currentChar].GetComponentInChildren<ArrowPoint> ().enabled = false;
		
		characters [currentChar].GetComponent<PlayerControl> ().enabled = false;		
		characters [currentChar].GetComponent<PlayerControl> ().move = Vector3.zero;		
		characters [currentChar].GetComponent<FollowPlayer> ().isMoving = false;		

		if(isFollowing)
			characters [currentChar].GetComponent<FollowPlayer> ().enabled = true;

//		if(!characters[currentChar].GetComponent<FollowPlayer>().brokenFromGroup && !GetFollowing(currentChar).GetComponent<FollowPlayer>().brokenFromGroup)
	}

	void EnableCurrentCharControl(){
		characters [currentChar].GetComponent<PlayerControl> ().enabled = true;		
		characters [currentChar].GetComponent<FollowPlayer> ().enabled = false;	
		characters [currentChar].GetComponentInChildren<ArrowPoint> ().enabled = true;
	}

	GameObject GetFollower(int i){
		if(i == characters.Count - 1)
			return characters[0];
		else
			return characters[i + 1];
	}

	GameObject GetFollowing(int i){
		if (i == 0) {
			return characters[characters.Count-1];		
		}
		else
			return characters[i - 1];
	}

	public void GameOver(){
		gameover = true;
		foreach (GameObject g in characters) {
			g.GetComponent<PlayerControl>().enabled = false;		
			g.GetComponent<FollowPlayer>().isMoving = false;		
			g.GetComponent<FollowPlayer>().enabled = false;		
			g.GetComponent<PlayerControl>().move = Vector3.zero;

			cam.GetComponent<LerpToTarget>().target = raft;
		}
	}

}
