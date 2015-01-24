using UnityEngine;
using System.Collections;
using System.Linq;

public class Actions : MonoBehaviour
{
    public GameObject Human;
    public GameObject UIObject;
    public int actionCount = 7;
    public int[] actionsID;
    public int[] pointList;
    public int[] painetutNapit;
    public int turnAmount = 0;
    public int maxTurns = 2;
    private int roundAmount;
    private int playerPoints;

    private bool isMaxTurns = false;

	// Use this for initialization
	void Start ()
    {
        pointList = new int[6];
        randomisePointList();
        Human = GameObject.FindWithTag("Human");
        painetutNapit = new int[2];
        UIObject = GameObject.FindWithTag("UI object");
        actionsID = new int[actionCount];
        turnAmount = 0;
        roundAmount = 0;

        for(int i = 0; i < actionCount; i++)
        {
            actionsID[i] = i;
        }
        for (int i = 0; i < painetutNapit.Length; i++)
        {
            painetutNapit[i] = -1;
        }

	}
	
	// Update is called once per frame
	void Update ()
    {
        if (roundAmount > 2)
        {
            Application.LoadLevel("score");
        }
	}

    public void PlayerTurn(int id)
    {
        if(!isMaxTurns)
        {
            ChooseAction(id);
            painetutNapit[turnAmount] = id;
            turnAmount++;
            if (turnAmount >= maxTurns)
            {
                isMaxTurns = true;
                Invoke("CountPoints", 2f);
            }
        }
        else
        {
            Debug.Log("Can't press!");
        }
    }

    void Reset()
    {
        turnAmount = 0;
        isMaxTurns = false;
        playerPoints = 0;
    }

    void CountPoints()
    {
        HumanScript humanScript = Human.gameObject.GetComponent<HumanScript>();
        GameScore.roundScores[roundAmount] = playerPoints;
        Reset();
        humanScript.canLeave();

        roundAmount++;
    }

    void ChooseAction(int id)
    {
        if(actionsID[id] == 0)
        {
            GivePresent();
        }
        else if (actionsID[id] == 1)
        {
            Hit();
        }
        else if (actionsID[id] == 2)
        {
            Kiss();
        }
        else if (actionsID[id] == 3)
        {
            Wink();
        }
        else if (actionsID[id] == 4 )
        {
            Talk();
        }
        else if (actionsID[id] == 5)
        {
            ShowMuscle();
        }
    }

    void randomisePointList()
    {
        var numbersAdded = 0;
        while(numbersAdded < 6)
        {
            var rand = Random.Range(-2,6);
            if (!pointList.Contains(rand))
            {
                pointList[numbersAdded] = rand;
                numbersAdded++;
            }
        }
    }

    void GivePresent()
    {
        // animation
        playerPoints += pointList[0];
        Debug.Log("GiveMoney()");
        Debug.Log(playerPoints);
    }

    void Hit()
    {
        // animation
        // randomize how many points
        playerPoints += pointList[1];
        Debug.Log("Hit()");
        Debug.Log(playerPoints);
    }

    void Kiss()
    {
        // animation
        playerPoints += pointList[2];
        Debug.Log("Kiss()");
        Debug.Log(playerPoints);
    }

    void Wink()
    {
        // animation
        playerPoints += pointList[3];
        Debug.Log("Wink()");
        Debug.Log(playerPoints);
    }

    void Talk()
    {
        // anim
        playerPoints += pointList[4];
        Debug.Log("Talk()");
        Debug.Log(playerPoints);
    }

    void ShowMuscle()
    {
        // animation
        playerPoints += pointList[5];
        Debug.Log("ShowMuscle()");
        Debug.Log(playerPoints);
    }
    
}