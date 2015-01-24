using UnityEngine;
using System.Collections;

public class UI : MonoBehaviour
{
    public GameObject ActionObject;
    public int[] buttonIDs;
    public int buttonCount = 6;
    public GameObject[] actionButtons;
    public GameObject buttonPref;
    public Sprite[] buttonIcons;
    private float buttonRadius = 0.64f;
    private bool isButtonDown = false;

	// Use this for initialization
	void Start ()
    {
        ActionObject = GameObject.FindWithTag("Action object");
        float os1 = 0;
        float os2 = 0f;
        actionButtons = new GameObject[buttonCount];
        

        for (int i = 0; i < buttonCount; ++i)
        {
            if (i < 3)
            {
                actionButtons[i] = (GameObject)Instantiate(buttonPref, new Vector3(-1.7f + os1, -3.85f), Quaternion.identity);
                os1 += 1.7f;
                actionButtons[i].GetComponent<SpriteRenderer>().sprite = buttonIcons[i];
            }
            else if (i >= 3 && buttonCount <= 6)
            {
                actionButtons[i] = (GameObject)Instantiate(buttonPref, new Vector3(-1.7f + os2, -2.1f), Quaternion.identity);
                os2 += 1.7f;
                actionButtons[i].GetComponent<SpriteRenderer>().sprite = buttonIcons[i];
            }

        }
	}
	
	// Update is called once per frame
	void Update ()
    {
        IsButtonPressed();
	}

    void IsButtonPressed()
    {
        Actions actions = ActionObject.gameObject.GetComponent<Actions>();
        if (Input.GetMouseButtonDown(0) && !isButtonDown)
        {
            isButtonDown = true;
            for (int i = 0; i < buttonCount; i++)
            {
                if (Vector2.Distance(actionButtons[i].transform.localPosition, Camera.main.ScreenToWorldPoint(Input.mousePosition)) < buttonRadius)
                {
                    actions.PlayerTurn(i);
                }
            }
        }
        else
            isButtonDown = false;
    }
}