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
        return          "Game over" + "\n\n" +
                        "Round 1: " + roundScores [0] + "\n" +
                        "Round 2: " + roundScores[1] + "\n" +
                        "Round 3: " + roundScores[2] + "\n" +
                        "Round 4: " + roundScores[3] + "\n" +
                        "Round 5: " + roundScores[4] + "\n" +
                        "Overall: " + (roundScores [0]+roundScores [1]+roundScores [2]+roundScores [3]+roundScores [4]) + "\n\n" + 
                        "Tap to continue"
                        ;
	}
}
