using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Controller : MonoBehaviour {

    public bool isP1 = true; //true if player is P1, false if P2
    float horiz = 0; //racoon's horizontal movement
    float vert = 0; //racoon's vertical movement

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (isP1) { //sets horizontal and vertical comonents for P1 control
            horiz = Input.GetAxis("Horizontal_P1");
            vert = Input.GetAxis("Vertical_P1");
        }
        else { //sets horizontal and vertical components for P2 control
            horiz = Input.GetAxis("Horizontal_P2");
            vert = Input.GetAxis("Horizontal_P2");
        }
        //move the racoon by the way it's pointed
        this.transform.Translate(horiz, vert, 0);
	}
}
