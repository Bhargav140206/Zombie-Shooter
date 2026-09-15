using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour {

    private Rigidbody2D myBody;
    private float moveForce_X = 1.5f, moveForce_Y = 1.5f;

    private PlayerAnimations playerAnimation;

	void Awake () {
        myBody = GetComponent<Rigidbody2D>();
        playerAnimation = GetComponent<PlayerAnimations>();
	}

	void FixedUpdate () {
        Move();
	}

    void Move()
    {

        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");

        if (h > 0)
        {
            myBody.linearVelocity = new Vector2(moveForce_X, myBody.linearVelocity.y);

        }
        else if (h < 0)
        {
            myBody.linearVelocity = new Vector2(-moveForce_X, myBody.linearVelocity.y);

        }
        else
        {
            myBody.linearVelocity = new Vector2(0f, myBody.linearVelocity.y);
        }

        if (v > 0)
        {
            myBody.linearVelocity = new Vector2(myBody.linearVelocity.x, moveForce_Y);

        }
        else if (v < 0)
        {
            myBody.linearVelocity = new Vector2(myBody.linearVelocity.x, -moveForce_Y);

        }
        else
        {
            myBody.linearVelocity = new Vector2(myBody.linearVelocity.x, 0f);
        }

        // ANIMATE
        if(myBody.linearVelocity.x != 0 || myBody.linearVelocity.y != 0) {
            playerAnimation.PlayerRunAnimation(true);

        } else if(myBody.linearVelocity.x == 0 && myBody.linearVelocity.y == 0) {
            playerAnimation.PlayerRunAnimation(false);
        }

        Vector3 tempScale = transform.localScale;

        if (h > 0) {
            tempScale.x = -1f;

        } else if (h < 0) {
            tempScale.x = 1f;

        }

        transform.localScale = tempScale;

    }

} // class










































