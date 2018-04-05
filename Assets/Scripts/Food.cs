using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food : MonoBehaviour {

	//	Public properties
	public Sprite[] hitSprites;
	public static int breakableCount = 0;
	public GameObject smoke;
	public int scoreValue = 150;			//	Points obtained for collecting
	private ScoreKeeper scoreKeeper;		//	A link to the ScoreKeeper script

	//	Private properties
	private int timesHit;
	private LevelManager levelManager;
	private bool isBreakable;

	void Start()
	{
		//	We identify if the brick is breakable or not (using tags) and set the
		//	isBreakable flag accordingly
		isBreakable = (this.tag == "Food");

		//	We keep track of how many breakable bricks we haver created, increasing
		//	the static property breakableCount.
		if (isBreakable)
		{
			breakableCount++;
		}

		//	We set the number ot times the brick has been hit to 0
		timesHit = 0;

		//	We link the LevelManager and scorekeeper object to this script

		scoreKeeper = GameObject.Find("Score").GetComponent<ScoreKeeper>();

		levelManager = GameObject.FindObjectOfType<LevelManager>();
	}

	//	We use the OnCollisionEnter2D message to play the cracking sound whe the ball
	//	hits the brick, and to decide if we are going to update the brick's sprite.
	void OnCollisionEnter2D(Collision2D collision)
	{
		//	If the brick is a breakable one, we call the HandleHits() method
		if (isBreakable)
		{
			HandleHits();
		}
	}

	//	We use this method to react to a brick being hit
	void HandleHits()
	{
		//	We increase the number of hits the brick has received.
		timesHit++;

		//	Using this new number of hits received, we display the next, and the number
		//	of sprites assigned to this particular type of brick, we compute the max
		//	number of hits the brick can take.
		int maxHits = hitSprites.Length+1;

		//	If the times the brick has been hit is greater than or equals to the max
		//	number of hits it can take, we proceed to destroy it.  To do that,we need
		//	to decrease the number of breakable bricks in our scene, and call the
		//	BrickDestroyed() method within the level manager instance in our script.
		//	Then, we call the PuffSmoke() method to simulate the bricks destruction and
		//	then we call the Destroy() method for this game object.
		//	However, if the times the brick has been hit is less than the max number of
		//	hits it can take, then we call the LoadSprites() method.
		if (timesHit >= maxHits)
		{
			breakableCount--;
			levelManager.FoodDestroyed();

			Destroy(gameObject);
			scoreKeeper.Score(scoreValue);
		}

	}
		

}