using UnityEngine;
using System.Collections;

public class SpeechTrigger : MonoBehaviour {
	public ColoredPath.MyColor colortype;
	public string text;
	public GameObject canvas, speechText;

	// Use this for initialization
	void Start () {
		canvas = GameObject.Find ("Canvas");
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D col){
		if (col.gameObject.GetComponent<Player> () && col.gameObject.GetComponent<Player> ().colortype == colortype) {
			GameObject go = Instantiate (speechText, new Vector3 (col.transform.position.x,col.transform.position.y + 1,0), Quaternion.identity) as GameObject;
			go.GetComponent<PositionUI> ().player = col.gameObject;
			
			go.gameObject.transform.localScale = Vector3.one;
			
			go.transform.parent = canvas.transform;
			
			go.GetComponent<DisplayTextAnim> ().text = text;
			go.GetComponent<DisplayTextAnim> ().enabled = true;
			
			Destroy (gameObject);
		}
	}
}
