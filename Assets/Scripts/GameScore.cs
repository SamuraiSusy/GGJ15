using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameScore : MonoBehaviour {

	static public int[] roundScores = new int[5];
	static public int curRound = 0;
	static public int winRound = 0;
	static public int[] humanOne = new int[10];
	static public int[] humanTwo = new int[10];
	static public int[] humanTre = new int[10];
	static public int[] humanFou = new int[10];
	static public int[] humanFiv = new int[10];

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
        return          "Your true love" + "\n\n" +
                        "Score: " + (roundScores [0]+roundScores [1]+roundScores [2]+roundScores [3]+roundScores [4]) + "\n\n" + 
                        "Tap to continue"
                        ;
	}

}
