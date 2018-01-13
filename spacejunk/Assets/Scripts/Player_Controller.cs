using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Controller : MonoBehaviour {

    public bool isP1 = true; //true if player is P1, false if P2
    public float movementModifier = 1; //the movement speed is divided by this

    float horiz = 0; //racoon's horizontal movement
    float vert = 0; //racoon's vertical movement
    Rigidbody2D rb; //the player's Rigidbody
    //bool canPickup; //player can pickup garabage
    //GameObject heldItem; //the object player is holding

	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody2D>();
	}

    //private void OnCollisionEnter2D(Collision2D collision)
    //{
    //    if (collision.gameObject.tag == "Garbage") {
    //        if (isP1 && Input.GetAxis("Pickup_P1") > 0)
    //        {
    //            heldItem = collision.gameObject;
    //            Debug.Log("picked up garbage!");
    //        }

    //        else if (!isP1 && Input.GetAxis("Pickup_P2") > 0)
    //        {
    //            heldItem = collision.gameObject;
    //        }
    //    } //allows player to pickup garbage when on it
    //}

    // Update is called once per frame
    void Update () {
        if (isP1) { //for P1 control
            if (Input.GetAxis("Pickup_P1") > 0) { //tries to grab trash
                Trash_Scene_Controller.instance.grab(true, this.gameObject);
            }
            //below sets movement based on input and public modifier
            horiz = rb.position.x + Input.GetAxis("Horizontal_P1")/movementModifier;
            vert = rb.position.y + Input.GetAxis("Vertical_P1")/movementModifier;
        }
        else { //for P2 control
            if (Input.GetAxis("Pickup_P2") > 0) //tries to grab trash
            {
                Trash_Scene_Controller.instance.grab(false, this.gameObject);
            }
            //below sets movement based on input and public modifier
            horiz = rb.position.x + Input.GetAxis("Horizontal_P2")/movementModifier;
            vert = rb.position.y + Input.GetAxis("Vertical_P2")/movementModifier;
        }
        //move the racoon by the way it's pointed
        rb.MovePosition(new Vector2(horiz, vert));
	}
}
