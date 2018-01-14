using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Controller : MonoBehaviour {

    public bool isP1 = true; //true if player is P1, false if P2
    public float movementModifier = 1; //the movement speed is divided by this

    float horiz = 0; //racoon's horizontal movement
    float vert = 0; //racoon's vertical movement
    Rigidbody2D rb; //the player's Rigidbody
    bool canInteractP1 = true; //true if the player can interact with garbage, false if they JUST did
    bool canInteractP2 = true; //same as above for P2
    public float P1InteractTimer = 0; //P1 can interact when it hits .75
    public float P2InteractTimer = 0; //P2 can interact when it hits .75
    //GameObject heldItem; //the object player is holding

	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody2D>(); //can't be set before runtime
	}

    // Update is called once per frame
    void Update () { //the two if statements below cover control timers for fluid interaction with objects
        if (!canInteractP1)
        {
            P1InteractTimer += Time.deltaTime;
            if (P1InteractTimer > .75)
            {
                P1InteractTimer = 0;
                canInteractP1 = true;
            }
        }
        if (!canInteractP2)
        {
            P2InteractTimer += Time.deltaTime;
            if (P2InteractTimer > .75)
            {
                P2InteractTimer = 0;
                canInteractP2 = true;
            }
        }
        if (isP1) { //for P1 control
            if (Input.GetAxis("Pickup_P1") > 0 && canInteractP1) { //tries to grab or drop trash
                canInteractP1 = false;
                if (Trash_Scene_Controller.instance.getHeldItem(true) == null)
                { //if no item held, pick one up
                    Trash_Scene_Controller.instance.grab(true, this.gameObject);
                } //if a held item, drop it
                else { Trash_Scene_Controller.instance.drop(true, this.gameObject); }
            }
            //below sets movement based on input and public modifier
            horiz = rb.position.x + Input.GetAxis("Horizontal_P1")/movementModifier;
            vert = rb.position.y + Input.GetAxis("Vertical_P1")/movementModifier;
            if (Input.GetAxis("Horizontal_P1") < 0)
                this.gameObject.transform.eulerAngles = new Vector3(0, 0, 90f);
            else if (Input.GetAxis("Horizontal_P1") > 0)
                this.gameObject.transform.eulerAngles = new Vector3(0, 0, -90f);
            else if (Input.GetAxis("Vertical_P1") < 0)
                this.gameObject.transform.eulerAngles = new Vector3(180f , 0, 0);
            else if (Input.GetAxis("Vertical_P1") > 0)
                this.gameObject.transform.eulerAngles = new Vector3(0 , 0, 0);
        }
        else { //for P2 control
            if (Input.GetAxis("Pickup_P2") > 0 && canInteractP2) { //tries to grab or drop trash
                canInteractP2 = false;
                if (Trash_Scene_Controller.instance.getHeldItem(false) == null)
                { //if no item held, pick one up
                    Trash_Scene_Controller.instance.grab(false, this.gameObject);
                } //if a held item, drop it
                else { Trash_Scene_Controller.instance.drop(false, this.gameObject); }
            }
            //below sets movement based on input and public modifier
            horiz = rb.position.x + Input.GetAxis("Horizontal_P2")/movementModifier;
            vert = rb.position.y + Input.GetAxis("Vertical_P2")/movementModifier;
            if (Input.GetAxis("Horizontal_P2") < 0)
                this.gameObject.transform.eulerAngles = new Vector3(0, 0, 90f);
            else if (Input.GetAxis("Horizontal_P2") > 0)
                this.gameObject.transform.eulerAngles = new Vector3(0, 0, -90f);
            else if (Input.GetAxis("Vertical_P2") < 0)
                this.gameObject.transform.eulerAngles = new Vector3(180f, 0, 0);
            else if (Input.GetAxis("Vertical_P2") > 0)
                this.gameObject.transform.eulerAngles = new Vector3(0, 0, 0);
        }
        //move the racoon by the way it's pointed
        rb.MovePosition(new Vector2(horiz, vert));

    }
}
