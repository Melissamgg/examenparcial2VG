using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
	//Speed when moving
	public float speed = 2;
	//Direction of Movement
	Vector2 dir = Vector2.right;
	// Push force if we can kill it
	public float upForce = 800;
	public float damage = 100f;
	private LevelManager levelManager;

	void FixedUpdate()
	{
		//Speed to move
		GetComponent<Rigidbody2D>().velocity = dir * speed;
	}

	void OnTriggerEnter2D(Collider2D coll)
	{
		//If the object collides with our pivot, it changes direction
		transform.localScale = new Vector2(-1 * transform.localScale.x,
			transform.localScale.y);

		// And mirror it
		dir = new Vector2(-1 * dir.x, dir.y);


	}


	//	Getter for the damage property.
	public float getDamage()
	{
		return damage;
	}


}
