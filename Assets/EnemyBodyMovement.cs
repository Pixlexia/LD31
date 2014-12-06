using UnityEngine;
using System.Collections;

public class EnemyBodyMovement : bodyMovement {
	public Enemy enemyScript;

	// Use this for initialization
	public override void Start () {
		enemyScript = GetComponent<Enemy> ();
	}
	
	// Update is called once per frame
	public override void Update () {
		if (enemyScript.isMoving) {
			MoveAnimation();		
		}
		else{
			StopAnimation();
		}
	}
}
