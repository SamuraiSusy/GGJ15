using UnityEngine;
using System.Collections;

public class ScoreList : MonoBehaviour {
	
	// Use this for initialization
	void Start ()
	{
		GetComponent<GUIText> ().text = GameScore.getScoreList();
	}
	
	// Update is called once per frame
	void Update ()
	{
	    if(Input.GetMouseButtonDown(0))
        {
            Application.LoadLevel("test");
        }
	}
}
