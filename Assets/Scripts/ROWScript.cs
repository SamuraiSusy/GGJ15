using UnityEngine;
using System.Collections;

public class ROWScript : MonoBehaviour {
	
	// Use this for initialization
	void Start () 
	{
		gameObject.SetActive (false);
		isRight (true);	
	}
	
	// Update is called once per frame
	void Update () 
	{
		transform.Translate (new Vector3 (0, 0.25f * Time.deltaTime));
	}

	IEnumerator show()
	{
		yield return new WaitForSeconds(1.25f);
		Destroy (gameObject);
	}

	public void isRight(bool isIt)
	{

		gameObject.SetActive (true);
		if(isIt)		
			GetComponent<GUIText> ().color = Color.green;
		else		
			GetComponent<GUIText> ().color = Color.red;

		StartCoroutine ("show");
	}
}
