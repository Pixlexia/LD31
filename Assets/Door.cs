using UnityEngine;
using System.Collections;

public class Door : MonoBehaviour {

	public void Activate(){
		transform.GetChild (0).gameObject.SetActive (false);
		transform.GetChild (1).gameObject.SetActive (false);
	}
}
