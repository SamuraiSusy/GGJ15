using UnityEngine;
using System.Collections;

public class HumanScript : MonoBehaviour {

	public Sprite[] faceSprite = null;
	public Sprite[] eyeSprite = null;
	public Sprite[] mouthSprite = null;

	public GameObject type;

	private GameObject[] humanParts = new GameObject[3];

	private Vector2 whereTo;
	private Vector2 whereFrom;
	private Vector2 whereItStands;
	private bool isSpawned;
	private bool isReadyToLeave;
	// Use this for initialization
	void Start () 
	{	
		//Create human parts default
		var obj3 = (GameObject)Instantiate (type);
		var obj2 = (GameObject)Instantiate (type);
		var obj1 = (GameObject)Instantiate (type);

		//Set parts to correct place and set parent
		humanParts[0] = obj1;
		humanParts[0].transform.parent = transform;

		humanParts[1] = obj2;
		humanParts[1].transform.parent = transform;

		humanParts[2] = obj3;
		humanParts[2].transform.parent = transform;

		//Set where to and where from human moves
		whereTo 	= new Vector2(-5, transform.position.y - 1);
		whereFrom  	= new Vector2( 5, transform.position.y - 1);
		whereItStands = new Vector2 (0, 0);

		isSpawned 		= false;
		isReadyToLeave 	= false;

		rollRandomHuman ();
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (Input.GetKey ("space"))
		{
			respawnHuman ();
		}
		if (Input.GetKey ("up"))
		{
			isReadyToLeave = true;
		}

		if(!isSpawned)
		{
			transform.position = Vector2.Lerp(transform.position, whereItStands, 4 * Time.deltaTime);

			if(Vector2.Distance(transform.position, whereItStands) < 0.01f)
			{
				isSpawned = true;
			}
		}
		if (isReadyToLeave)
		{
			transform.position = Vector2.Lerp(transform.position, whereTo, 4 * Time.deltaTime);
			
			if(Vector2.Distance(transform.position, whereTo) < 0.01f)
				respawnHuman();
		}
	}

	public void respawnHuman()
	{
		spawnHuman ();
		rollRandomHuman ();
		//TODO: increase counter how many you have meet
		//		and play some sounds etc.
	}

	public void rollRandomHuman()
	{
		humanParts [0].GetComponent<SpriteRenderer> ().sprite = faceSprite [Random.Range (0, 3)];
		humanParts [1].GetComponent<SpriteRenderer> ().sprite = eyeSprite [Random.Range (0, 3)];
		humanParts [2].GetComponent<SpriteRenderer> ().sprite = mouthSprite [Random.Range (0, 3)];
	}

	public void spawnHuman()
	{
		transform.position = whereFrom;
		isSpawned = false;
		isReadyToLeave = false;
	}

	public void canLeave()
	{
		isReadyToLeave = true;
	}

}
