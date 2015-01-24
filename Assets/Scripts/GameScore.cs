using UnityEngine;
using System.Collections;

public class GameScore : MonoBehaviour {

	static public int[] roundScores = new int[5];

	// Use this for initialization
	void Start ()
	{
	
	}
	
	// Update is called once per frame
	void Update ()
	{
	
	}

	static public string getScoreList()
	{
		return "1: " + roundScores [0] + "\n" +
						"2: " + roundScores [1] + "\n" +
						"3: " + roundScores [2] + "\n" +
						"4: " + roundScores [3] + "\n" +
						"5: " + roundScores [4] + "\n";
	}
}
