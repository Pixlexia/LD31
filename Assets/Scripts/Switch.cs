using UnityEngine;
using System.Collections;

public class Switch : MonoBehaviour {
	public enum TargetType { spike, door }
	public TargetType switchType;
	
	public bool state = false;
	
	public GameObject[] target;
}
