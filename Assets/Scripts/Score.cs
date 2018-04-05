using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class D_score : MonoBehaviour {
	// Use this for initialization
	D_score instance;

	void Start()
	{
		Text scoreText = GetComponent<Text>();
		scoreText.text = ScoreKeeper.score.ToString();
		ScoreKeeper.Reset();


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
}