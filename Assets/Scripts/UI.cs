using UnityEngine;
using System.Collections;

public class UI : MonoBehaviour
{
    public GameObject ActionObject;
    public int[] buttonIDs;
    public GameObject[] actionButtons;
    public GameObject buttonPref;

	// Use this for initialization
	void Start ()
    {
        ActionObject = GameObject.FindWithTag("Action object");
        Actions juttu = ActionObject.gameObject.AddComponent<Actions>();
        float osx = 0;
        float osy = 0.3f;
        actionButtons = new GameObject[6];

        // NOT WORKING ANYMORE
        for (int i = 0; i < juttu.actionCount; ++i)
        {
            // CAUSE OF THIS
            if(juttu.actionCount < 3)
            {
                actionButtons[i] = (GameObject)Instantiate(buttonPref, new Vector3(1f + osx, 0.1f), Quaternion.identity);
            }
            else if(juttu.actionCount >= 3 && juttu.actionCount < 7)
            {
                actionButtons[i] = (GameObject)Instantiate(buttonPref, new Vector3(0.1f + osx, 0.1f + osy), Quaternion.identity);
            }

            osx += 0.3f;
        }
	}
	
	// Update is called once per frame
	void Update ()
    {
	
	}

    void OnGUI()
    {
        //float offSet = 0;
        //for(int i = 0; i < buttonIDs.Length; i++)
        //{
        //    if (GUI.Button(new Rect(10, 10 + offSet, 100, 50), "mo"))
        //    {
        //        CallButton(buttonIDs[i]);
        //    }

        //    offSet += 60;
        //}
    }

    void CallButton(int buttonID)
    {
        //buttonID = 
        //Debug.Log("pressed" + buttonID);
    }
}