using UnityEngine;
using System.Collections;

public class ColoredPath : MonoBehaviour {

	public enum MyColor { red, yellow, green, blue};
	public MyColor color;

	// Use this for initialization
	void Start () {
		gameObject.tag = color.ToString () + "area";
		GetComponent<SpriteRenderer> ().color = GameColors.colors [color.ToString ()];
	}

	void OnTriggerEnter2D(Collider2D col){
		if (col.gameObject.tag == "Player" && col.gameObject.GetComponent<Player> ().colortype != color)
			col.gameObject.GetComponent<Player> ().Die ();
	}

	public void Deactivate(){
		GetComponent<SpriteRenderer> ().color = new Color (0.9f, 0.9f, 0.9f, 1);
		collider2D.enabled = false;
	}

}
