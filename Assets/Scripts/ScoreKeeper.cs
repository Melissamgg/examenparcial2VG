using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;				//	We need this in order to handle the Text object

public class ScoreKeeper : MonoBehaviour
{
	public static int score = 0;            //	Player's score
	private Text scoreText;    //	So we can modify the score's Text
	ScoreKeeper instance;

	// Use this for initialization
	void Start()
	{
		//	We dynamicaly point to the Text object in our UI.
		scoreText = GetComponent<Text>();
		//Reset ();
		scoreText.text = score.ToString();

		if (instance != null)
		{
			Destroy(gameObject);
		}
		//  However, if the instance is indeed null, then we asociate it to this
		//  gameObject and we ask Unity to not destroy it on every load.
		else
		{
			instance = this;
			DontDestroyOnLoad(gameObject);
		}
	}
	// Update is called once per frame
	void Update()
	{

	}
	public void Score(int points)
	{
		score += points;
		scoreText.text = score.ToString();
	}
	public static void Reset()
	{
		score = 0;
		// scoreText.text = score.ToString ();
	}
}