using UnityEngine;
using System.Collections;

public class MainMenu : MonoBehaviour
{
    public GameObject startButton, tutorialButton, creditsButton;

	// Use this for initialization
	void Start ()
    {
        startButton = GameObject.FindWithTag("Start");
        tutorialButton = GameObject.FindWithTag("Tutorial");
        creditsButton = GameObject.FindWithTag("Credits");
	}
	
	// Update is called once per frame
	void Update ()
    {
        PressButton();
	}

    void PressButton()
    {
        //if (Vector2.Distance(startButton.transform.localPosition, Camera.main.ScreenToWorldPoint(Input.mousePosition)) == 0.1f && Input.GetMouseButtonDown(0))
        //{
        //    Debug.Log("start");
        //    //Application.LoadLevel("test");
        //}
        //else if (Vector2.Distance(tutorialButton.transform.localPosition, Camera.main.ScreenToWorldPoint(Input.mousePosition)) == 0.1f && Input.GetMouseButtonDown(0))
        //{
        //    Debug.Log("tuto");
        //    //Application.LoadLevel("tutorial");
        //}
        //else if (Vector2.Distance(creditsButton.transform.localPosition, Camera.main.ScreenToWorldPoint(Input.mousePosition)) == 0.1f && Input.GetMouseButtonDown(0))
        //{
        //    Debug.Log("cred");
        //    //Application.LoadLevel("credits");
        //}
    }
}