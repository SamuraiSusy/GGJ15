using UnityEngine;
using System.Collections;

public class Actions : MonoBehaviour
{
    public GameObject UIObject;
    public int actionCount = 7;
    public int[] actions;

	// Use this for initialization
	void Start ()
    {
        UIObject = GameObject.FindWithTag("UI object");
        actions = new int[actionCount];

        for(int i = 0; i < actionCount; i++)
        {
            actions[i] = i;
        }

	}
	
	// Update is called once per frame
	void Update ()
    {
	
	}

    public void ChooseAction()
    {
        if(actions[actionCount] == 1)
        {
            DoSomething1();
        }
        else if(actions[actionCount] == 2)
        {
            DoSomething2();
        }
        else if (actions[actionCount] == 3)
        {
            DoSomething3();
        }
        else if (actions[actionCount] == 4)
        {
            DoSomething4();
        }
        else
        {
            Debug.Log("something else");
        }
    }

    void DoSomething1()
    {
        if (actions[actionCount] == 1)
        {
            Debug.Log("action #" + actionCount);
        }
    }

    void DoSomething2()
    {
        if (actions[actionCount] == 2)
        {
            Debug.Log("action #" + actionCount);
        }
    }

    void DoSomething3()
    {
        if (actions[actionCount] == 3)
        {
            Debug.Log("action #" + actionCount);
        }
    }

    void DoSomething4()
    {
        if (actions[actionCount] == 4)
        {
            Debug.Log("action #" + actionCount);
        }
    }
}
