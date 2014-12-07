using UnityEngine;
using System.Collections;

public class PositionUI : MonoBehaviour {
	public int maxHealth=100; 
	public GameObject target;
	public int curHealth=50; 
	public Vector3 screenPosition;
	public float healthBarLenght;

	// Use this for initialization
	void Start () { 
		healthBarLenght=Screen.width/2; 
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnGUI(){
		
		screenPosition = Camera.main.WorldToScreenPoint(transform.position);
		screenPosition.y = Screen.height - screenPosition.y;
		
		GUI.Box(new Rect(screenPosition.x-10,screenPosition.y-40,healthBarLenght,20),curHealth+"/"+maxHealth);
	}

}
