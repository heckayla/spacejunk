using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Controller : MonoBehaviour {

    public bool isP1 = true; //true if player is P1, false if P2
    public float movementModifier = 1; //the movement speed is divided by this
    float horiz = 0; //racoon's horizontal movement
    float vert = 0; //racoon's vertical movement
    Rigidbody2D rb; //the player's Rigidbody

	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
        if (isP1) { //sets horizontal and vertical comonents for P1 control
            horiz = rb.position.x + Input.GetAxis("Horizontal_P1")/movementModifier;
            vert = rb.position.y + Input.GetAxis("Vertical_P1")/movementModifier;
        }
        else { //sets horizontal and vertical components for P2 control
            horiz = rb.position.x + Input.GetAxis("Horizontal_P2")/movementModifier;
            vert = rb.position.y + Input.GetAxis("Vertical_P2")/movementModifier;
        }
        //move the racoon by the way it's pointed
        rb.MovePosition(new Vector2(horiz, vert));
        Debug.Log(horiz);
	}
}
