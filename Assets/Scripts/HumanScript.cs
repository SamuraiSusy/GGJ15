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
	public bool isSpawned;
	public bool isReadyToLeave;

	int one;
	int two;
	int tre;
	int fou;
	int fiv;
	int six;
	int sev;
	int eig;

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
		//saveCurHuman ();
		rollRandomHuman ();
	}
	
	public void saveCurHuman()
	{
		switch (GameScore.curRound) {

		case 0:
			GameScore.humanOne[7] = eig;
			GameScore.humanOne[6] = sev;
			GameScore.humanOne[5] = six;
			GameScore.humanOne[4] = fiv;
			GameScore.humanOne[3] = fou;
			GameScore.humanOne[2] = tre;
			GameScore.humanOne[1] = two;
			GameScore.humanOne[0] = one;
			break;
		case 1:
			GameScore.humanTwo[7] = eig;
			GameScore.humanTwo[6] = sev;
			GameScore.humanTwo[5] = six;
			GameScore.humanTwo[4] = fiv;
			GameScore.humanTwo[3] = fou;
			GameScore.humanTwo[2] = tre;
			GameScore.humanTwo[1] = two;
			GameScore.humanTwo[0] = one;		
			break;
		case 2:
			GameScore.humanTre[7] = eig;
			GameScore.humanTre[6] = sev;
			GameScore.humanTre[5] = six;
			GameScore.humanTre[4] = fiv;
			GameScore.humanTre[3] = fou;
			GameScore.humanTre[2] = tre;
			GameScore.humanTre[1] = two;
			GameScore.humanTre[0] = one;
			break;
		case 3:
			GameScore.humanFou[7] = eig;
			GameScore.humanFou[6] = sev;
			GameScore.humanFou[5] = six;
			GameScore.humanFou[4] = fiv;
			GameScore.humanFou[3] = fou;
			GameScore.humanFou[2] = tre;
			GameScore.humanFou[1] = two;
			GameScore.humanFou[0] = one;
			break;
		case 4:
			GameScore.humanFiv[7] = eig;
			GameScore.humanFiv[6] = sev;
			GameScore.humanFiv[5] = six;
			GameScore.humanFiv[4] = fiv;
			GameScore.humanFiv[3] = fou;
			GameScore.humanFiv[2] = tre;
			GameScore.humanFiv[1] = two;
			GameScore.humanFiv[0] = one;
			break;
		default:
			Debug.Log("Error while saving human");
			break;
				}
	}

	public void rollRandomHuman()
	{
		if (Application.loadedLevelName != "score")
		{
			var color = new Vector4 (Random.Range (0.25f, 1.0f), Random.Range (0.25f, 1.0f), Random.Range (0.25f, 1.0f), 1);
			eig = Random.Range(0, hairSprite.Length);
			sev = Random.Range (0, bodySprite.Length);
			six = Random.Range (0, faceSprite.Length);
			fiv = Random.Range (0, eyeSprite.Length);
			fou = Random.Range (0, mouthSprite.Length);
			tre = Random.Range (0, bangSprite.Length);
			two = Random.Range (0, noseSprite.Length);
			one = Random.Range (0, browSprite.Length);

				humanParts [7].GetComponent<SpriteRenderer> ().sprite = hairSprite [eig];
				humanParts [7].GetComponent<SpriteRenderer> ().color = new Vector4 (color.x, color.y, color.z, 1);

				humanParts [6].GetComponent<SpriteRenderer> ().sprite = bodySprite [sev];
				humanParts [5].GetComponent<SpriteRenderer> ().sprite = faceSprite [six];
				humanParts [4].GetComponent<SpriteRenderer> ().sprite = eyeSprite [fiv];
				humanParts [3].GetComponent<SpriteRenderer> ().sprite = mouthSprite [fou];

				humanParts [2].GetComponent<SpriteRenderer> ().sprite = bangSprite [tre];
				humanParts [2].GetComponent<SpriteRenderer> ().color = new Vector4 (color.x, color.y, color.z, 1);

				humanParts [1].GetComponent<SpriteRenderer> ().sprite = noseSprite [two];
				humanParts [0].GetComponent<SpriteRenderer> ().sprite = browSprite [one];
		}
		else
		{	
			
			var color = new Vector4 (Random.Range (0.25f, 1.0f), Random.Range (0.25f, 1.0f), Random.Range (0.25f, 1.0f), 1);

			humanParts [7].GetComponent<SpriteRenderer> ().sprite = hairSprite [eig];
			humanParts [7].GetComponent<SpriteRenderer> ().color = new Vector4 (color.x, color.y, color.z, 1);
			
			humanParts [6].GetComponent<SpriteRenderer> ().sprite = bodySprite [sev];
			humanParts [5].GetComponent<SpriteRenderer> ().sprite = faceSprite [six];
			humanParts [4].GetComponent<SpriteRenderer> ().sprite = eyeSprite [fiv];
			humanParts [3].GetComponent<SpriteRenderer> ().sprite = mouthSprite [fou];
			
			humanParts [2].GetComponent<SpriteRenderer> ().sprite = bangSprite [tre];
			humanParts [2].GetComponent<SpriteRenderer> ().color = new Vector4 (color.x, color.y, color.z, 1);
			
			humanParts [1].GetComponent<SpriteRenderer> ().sprite = noseSprite [two];
			humanParts [0].GetComponent<SpriteRenderer> ().sprite = browSprite [one];

		}
	}

	public void spawnHuman()
	{
        GetComponent<AudioSource>().pitch = Random.Range(0.6f, 1.5f);
        GetComponent<AudioSource>().PlayDelayed(0.25f);
		transform.position = whereFrom;
		isSpawned = false;
		isReadyToLeave = false;
	}

	public void canLeave()
	{
		isReadyToLeave = true;
	}

}
