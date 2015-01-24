using UnityEngine;
using System.Collections;

public class GameSettings : MonoBehaviour
{

	// Use this for initialization
	void Start ()
    {
        Screen.orientation = ScreenOrientation.Portrait;
        Screen.SetResolution(720, 1280, true);
	}
	
	// Update is called once per frame
	void Update ()
    {
	
	}
}
