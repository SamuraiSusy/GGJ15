using UnityEngine;
using System.Collections;

public class ROWScript : MonoBehaviour
{
    public GameObject ActionObj;

	// Use this for initialization
	void Start () 
	{
		gameObject.SetActive (false);
		isRight (true);
        ActionObj = GameObject.FindWithTag("Action object");
	}
	
	// Update is called once per frame
	void Update () 
	{
		transform.Translate (new Vector3 (0, 0.25f * Time.deltaTime));
	}

	public IEnumerator show()
	{
		yield return new WaitForSeconds(1.25f);
		Destroy (gameObject);
	}

	public void isRight(bool isIt /*,int scoreValue*/)
	{
        //TODO: GetComponent<GUIText>().text = scoreValue; instatiate in action
		gameObject.SetActive (true);
		if(isIt)	
        {
            //GetComponent<GUIText>().color = Color.green;
            //GetComponent<GUIText>().text = "RIGHT";
        }
		else if(!isIt)
        {
            //Debug.Log("SE MENI SINNE");
            //GetComponent<GUIText>().color = Color.red;
            //GetComponent<GUIText>().text = "BA4D";
        }

		StartCoroutine ("show");
	}
}
