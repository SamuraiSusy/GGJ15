using UnityEngine;
using System.Collections;

public class HumanScript : MonoBehaviour {

	public Sprite[] faceSprite = null;
	public Sprite[] eyeSprite = null;
	public Sprite[] mouthSprite = null;
	public Sprite[] bodySprite = null;
	public Sprite[] hairSprite = null;
	public Sprite[] bangSprite = null;
	public Sprite[] noseSprite = null;
	public Sprite[] browSprite = null;

	public GameObject type;

	private GameObject[] humanParts = new GameObject[8];

	private Vector2 whereTo;
	private Vector2 whereFrom;
	private Vector2 whereItStands;
	private bool isSpawned;
	private bool isReadyToLeave;
	// Use this for initialization
	void Start () 
	{	
		//Create human parts default
		var obj1 = (GameObject)Instantiate (type);
		var obj2 = (GameObject)Instantiate (type);
		var obj3 = (GameObject)Instantiate (type);
		var obj4 = (GameObject)Instantiate (type);
		var obj5 = (GameObject)Instantiate (type);
		var obj6 = (GameObject)Instantiate (type);
		var obj7 = (GameObject)Instantiate (type);
		var obj8 = (GameObject)Instantiate (type);

		//Set parts to correct place and set parent
		humanParts[0] = obj1;
		humanParts[0].transform.parent = transform;
		humanParts[0].transform.position = new Vector2(0, 0.30f);

		humanParts[1] = obj2;
		humanParts[1].transform.parent = transform;
		humanParts[1].transform.position = new Vector2(0, 0.30f);

		humanParts[2] = obj3;
		humanParts[2].transform.parent = transform;

		humanParts[3] = obj4;
		humanParts[3].transform.parent = transform;
		humanParts[3].transform.position = new Vector2(0, 0.30f);
		
		humanParts[4] = obj5;
		humanParts[4].transform.parent = transform;
		humanParts[4].transform.position = new Vector2(0, 0.30f);
		
		humanParts[5] = obj6;
		humanParts[5].transform.parent = transform;

		humanParts[6] = obj7;
		humanParts[6].transform.parent = transform;
		
		humanParts[7] = obj8;
		humanParts[7].transform.parent = transform;


		//Set where to and where from human moves
		whereTo 	= new Vector2(-5, transform.position.y - 1);
		whereFrom  	= new Vector2( 5, transform.position.y - 1);
		whereItStands = new Vector2 (0, 1.2f);

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
            canLeave();
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
	}

	public void rollRandomHuman()
	{
		var color = new Vector4 (Random.Range (0.25f, 1.0f), Random.Range (0.25f, 1.0f), Random.Range (0.25f, 1.0f), 1);

		humanParts [7].GetComponent<SpriteRenderer> ().sprite = hairSprite [Random.Range (0, hairSprite.Length)];
		humanParts [7].GetComponent<SpriteRenderer> ().color = new Vector4(color.x,color.y,color.z,1);

		humanParts [6].GetComponent<SpriteRenderer> ().sprite = bodySprite [Random.Range (0, bodySprite.Length)];
		humanParts [5].GetComponent<SpriteRenderer> ().sprite = faceSprite [Random.Range (0, faceSprite.Length)];
		humanParts [4].GetComponent<SpriteRenderer> ().sprite = eyeSprite [Random.Range  (0, eyeSprite.Length)];
		humanParts [3].GetComponent<SpriteRenderer> ().sprite = mouthSprite [Random.Range(0, mouthSprite.Length)];

		humanParts [2].GetComponent<SpriteRenderer> ().sprite = bangSprite [Random.Range (0, bangSprite.Length)];
		humanParts [2].GetComponent<SpriteRenderer> ().color = new Vector4(color.x,color.y,color.z,1);

		humanParts [1].GetComponent<SpriteRenderer> ().sprite = noseSprite [Random.Range (0, noseSprite.Length)];
		humanParts [0].GetComponent<SpriteRenderer> ().sprite = browSprite [Random.Range (0, browSprite.Length)];
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
