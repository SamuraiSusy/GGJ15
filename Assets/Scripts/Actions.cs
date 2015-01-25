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
    public int[] pressedButtons;
    public int[] answerSheet;
    public GameObject Text;
    public int turnAmount = 0;
    public int maxTurns = 2;
    private int roundAmount;
    public int playerPoints;
    public GUIText[] stats;

    public bool isMaxTurns = false;
    private int temp = 1;

	// Use this for initialization
	void Start ()
    {
        pointList = new int[6];
        answerSheet = new int[6];
        //Text = GameObject.FindWithTag("RWText");
        randomisePointList();
        Human = GameObject.FindWithTag("Human");
        pressedButtons = new int[2];
        UIObject = GameObject.FindWithTag("UI object");
        actionsID = new int[actionCount];
        turnAmount = 0;
        roundAmount = 0;

        for(int i = 0; i < actionCount; i++)
        {
            actionsID[i] = i;
        }
        for (int i = 0; i < pressedButtons.Length; i++)
        {
            pressedButtons[i] = -1;
        }

	}
	
	// Update is called once per frame
	void Update ()
    {
        if (roundAmount > 2)
        {
            Application.LoadLevel("score");
        }

        stats[0].text = "Points: " + (GameScore.roundScores[0] +
                                    GameScore.roundScores[1] +
                                    GameScore.roundScores[2]);
        stats[1].text = "Round " + (roundAmount + temp);
        stats[2].text = "Choices: " + (2 - turnAmount);
	}

    public void PlayerTurn(int id)
    {
        //ROWScript rows = Text.GetComponent<ROWScript>();
        if(!isMaxTurns)
        {
            ChooseAction(id);
            pressedButtons[turnAmount] = id;
            turnAmount++;
            if (turnAmount >= maxTurns)
            {
                isMaxTurns = true;
                Invoke("CountPoints", 1.2f);
            }
        }
        else
        {
            Debug.Log("Can't press!");
        }
        CorrectAnswer(id);
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

    public void CorrectAnswer(int choise)
    {
        answerSheet[choise] = pointList[choise];
        if (answerSheet[choise] < 0)
        {
            Debug.Log("wrong");
            var obj1 = (GameObject)Instantiate(Text, new Vector3(0.5f, 0.5f, 0), Quaternion.identity);
            obj1.GetComponent<ROWScript>().isRight(false);
            obj1.GetComponent<GUIText>().text = "BAD";
            obj1.GetComponent<GUIText>().color = Color.red;
        }
        else if(answerSheet[choise] >= 0 && answerSheet[choise] < 7)
        {
            Debug.Log("right");
            var obj2 = (GameObject)Instantiate(Text, new Vector3(0.5f, 0.5f, 0), Quaternion.identity);
            obj2.GetComponent<ROWScript>().isRight(false);
            obj2.GetComponent<GUIText>().text = "RIGHT";
            obj2.GetComponent<GUIText>().color = Color.green;
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
    }

    void Hit()
    {
        // animation
        // randomize how many points
        playerPoints += pointList[1];
        Debug.Log("Hit()");
    }

    void Kiss()
    {
        // animation
        playerPoints += pointList[2];
        Debug.Log("Kiss()");
    }

    void Wink()
    {
        // animation
        playerPoints += pointList[3];
        Debug.Log("Wink()");
    }

    void Talk()
    {
        // anim
        playerPoints += pointList[4];
        Debug.Log("Talk()");
    }

    void ShowMuscle()
    {
        // animation
        playerPoints += pointList[5];
        Debug.Log("ShowMuscle()");
    }
    
}