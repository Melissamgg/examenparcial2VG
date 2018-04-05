using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class is_walking : MonoBehaviour
{
	public float maxVel = 5f;
	public float yJumForce = 300f; // que tan fuerte salta

	private Rigidbody2D rb;
	private Animator anim;
	private Vector2 jumpForce;
	private bool isJumping = false;
	private bool movingRigth = true;
	private LevelManager levelManager;


	// Use this for initialization
	void Start()

	{
		rb = GetComponent<Rigidbody2D>();
		anim = GetComponent<Animator>();

		jumpForce = new Vector2(0, 0);


	}

	// Update is called once per frame
	void FixedUpdate()
	{
		float v = Input.GetAxis("Horizontal");
		Vector2 vel = new Vector2(0, rb.velocity.y);

		v *= maxVel;
		vel.x = v;
		rb.velocity = vel;

		if (v != 0)
		{
			anim.SetBool("is_walking", true);
		}
		else { anim.SetBool("is_walking", false); }

		if (Input.GetAxis("Jump") > 0.01f)
		{
			if (!isJumping)
			{
				if (rb.velocity.y == 0f)
				{
					isJumping = true;
					jumpForce.x = 0f;
					jumpForce.y = yJumForce;
					rb.AddForce(jumpForce);
				}
			}
		}
		else { isJumping = false; }
		if (movingRigth && v < 0)
		{
			movingRigth = false;
			Flip();
		}
		else if (!movingRigth && v > 0)
		{
			movingRigth = true;
			Flip();
		}
	}

	private void Flip()
	{
		var s = transform.localScale;
		s.x *= -1;// realiza el cambio o giro del mono
		transform.localScale = s;
	}

	void OnTriggerEnter2D(Collider2D collider)
	{
		//	We try to identify the object that collided with us as a projectile (laser beam).
		Enemy alien = collider.gameObject.GetComponent<Enemy>();

		//	If our ship collided with a laser beam, we decrease our ship's health in the amount
		//	of damage set by the projectile.  If the ship's health is zero or less, then we destroy
		//	our ship.
		if (alien)
		{
				Die();
		}
	}

	void Die()
	{
		LevelManager levelManager = GameObject.Find("LevelManager").GetComponent<LevelManager>();
		levelManager.LoadLevel("Lose");
		Destroy(gameObject);
	}
}

