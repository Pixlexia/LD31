using UnityEngine;
using System.Collections;

public class ArrowPoint : MonoBehaviour {
	Color origColor;
	SpriteRenderer sprite;

	void Awake(){
		sprite = GetComponent<SpriteRenderer> ();
		origColor = GetComponent<SpriteRenderer> ().color;
		origColor = new Color (origColor.r, origColor.g, origColor.b, 1);
		sprite.color = new Color (0, 0, 0, 0);
		
	}

	void OnEnable(){
		sprite.color = origColor;
	}

	void OnDisable(){
		sprite.color = new Color (0, 0, 0, 0);
	}

	void Update () {
		StartCoroutine ("Wait");
	}

	IEnumerator Wait(){
		yield return new WaitForSeconds(0.3f);
		sprite.color = Color.Lerp (sprite.color, new Color (0, 0, 0, 0), 0.1f);
	}
}
