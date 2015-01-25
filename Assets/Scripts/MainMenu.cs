using UnityEngine;
using System.Collections;

public class MainMenu : MonoBehaviour {

	//public int buttonCount = 3;
	//public GameObject   buttonPref;
	//public GameObject[] ActionButtons;
	// Use this for initialization
	void Start () 
	{
		/*
		float os1 = 0;
		float os2 = 0f;
		ActionButtons = new GameObject[buttonCount];

		for (int i = 0; i < buttonCount; ++i) {
						if (i < 3) {
								ActionButtons [i] = (GameObject)Instantiate (buttonPref, new Vector3 (-1.7f + os1, -3.85f), Quaternion.identity);
								os1 += 1.7f;
								//TODO: put own GUITEXT to own thing
						}
				}

		*/
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (Input.GetMouseButtonDown (0))
						Application.LoadLevel ("testi");

	}
}
