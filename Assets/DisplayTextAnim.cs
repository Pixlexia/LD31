using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class DisplayTextAnim : MonoBehaviour {
	public string text;
	public float speed;
	public float pause;
	float animSpeed;
	string tempText;

	void Start(){ 
		StartCoroutine( AnimateText(text) ); 
	}
	
	IEnumerator AnimateText(string strComplete)
	{ 
		int i = 0; 
		tempText = ""; 
		while( i < strComplete.Length )
		{ 
			if(strComplete[i] == '%')
			{	
				animSpeed = pause; 
				i++;
			}
			else
			{
				animSpeed = speed;
				tempText += strComplete[i++];
			}	
			gameObject.transform.GetComponent<Text>().text = tempText;
			yield return new WaitForSeconds(animSpeed); 
		} 
	}
}
