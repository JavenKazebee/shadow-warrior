using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {
	public float movementSpeed;
	public float jumpPower;
	bool isGrounded;
	bool isFacingRight;
	public KeyCode jumpKey;
	public KeyCode leftKey;
	public KeyCode rightKey;

	Rigidbody2D rbd;
	SpriteRenderer renderer;

	void Start() {
		rbd = GetComponent <Rigidbody2D>();
		renderer = GetComponent<SpriteRenderer> ();
	}

	void Update() {
		if (Input.GetKey(jumpKey)) {
			groundedCheck ();
			if(isGrounded) {
				jump ();
				isGrounded = false;
			}
		}

		if (Input.GetKey (rightKey)) {
			moveRight ();
		}

		if (Input.GetKey (leftKey)) {
			moveLeft ();
		}
	}

	void groundedCheck() {
		RaycastHit2D[] hits;
		Vector2 posToCheck = transform.position;
		hits = Physics2D.RaycastAll (posToCheck, Vector2.down, 1f);
		if (hits.Length > 1) {
			isGrounded = true;
		}
	}

	void jump() {
		rbd.velocity = Vector2.up * jumpPower * Time.deltaTime;
	}

	void moveRight() {
		transform.Translate (new Vector2(movementSpeed * Time.deltaTime, 0.0f));
		if (!isFacingRight) {
			flip ();
		}
	}

	void moveLeft() {
		transform.Translate (new Vector2(-movementSpeed * Time.deltaTime, 0.0f));
		if (isFacingRight) {
			flip ();
		}
	}

	void flip() {
		if (isFacingRight) {
			renderer.flipX = true;
		} else {
			renderer.flipX = false;
		}
		isFacingRight = !isFacingRight;
	}
}
