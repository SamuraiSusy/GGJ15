using UnityEngine;
using System.Collections;

public class Actions : MonoBehaviour
{
    public GameObject UIObject;
    public int actionCount = 7;
    public int[] actionsID;
    public int[] painetutNapit;
    public int turnAmount = 0;
    public int maxTurns = 2;
    private int playerPoints;

    private bool isMaxTurns = false;

	// Use this for initialization
	void Start ()
    {
        painetutNapit = new int[2];
        UIObject = GameObject.FindWithTag("UI object");
        actionsID = new int[actionCount];
        turnAmount = 0;

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

    void CountPoints()
    {
        Debug.Log(playerPoints);
    }

    void ChooseAction(int id)
    {
        if(actionsID[id] == 0)
        {
            DoSomething1();
        }
        else if (actionsID[id] == 1)
        {
            DoSomething2();
        }
        else if (actionsID[id] == 2)
        {
            DoSomething3();
        }
        else if (actionsID[id] == 3)
        {
            DoSomething4();
        }
        else if (actionsID[id] > 3 )
        {
            Debug.Log("something else");
        }
    }

    void DoSomething1()
    {
        Debug.Log("DS1");
        playerPoints += 0;
    }

    void DoSomething2()
    {
        Debug.Log("DS2");
        playerPoints += 2;
    }

    void DoSomething3()
    {
        Debug.Log("DS3");
        playerPoints += 1;
    }

    void DoSomething4()
    {
        Debug.Log("DS4");
        playerPoints += -1;
    }
}
