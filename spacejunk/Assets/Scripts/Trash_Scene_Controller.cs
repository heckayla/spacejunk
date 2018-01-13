using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trash_Scene_Controller : MonoBehaviour {

    public static Trash_Scene_Controller instance;

    bool pickupP1 = false; //if p1 can pickup trash
    bool pickupP2 = false; //if p2 can pickup trash
    GameObject p1Holdable = null; //the item p1 is currently on top of
    GameObject p2Holdable = null; //the item p2 is currently on top of
    GameObject p1Held = null; //the item p1 holds
    GameObject p2Held = null; //the object p2 holds

    public void Awake()
    {
        if (instance != null)
        {
            Debug.LogError("Seems like there is more than one Trash Scene Controller in the scene");
        }
        instance = this;
    }

    // Update is called once per frame
    void Update () {
	}

    public void setPickupP1(bool status, GameObject item) { //same as below but for p1
        pickupP1 = status;
        if (status == true) { p1Holdable = item; }
        else { p1Holdable = null; }
    }
    public void setPickupP2(bool status, GameObject item) { //changes whether or not p2 can hold an item
        pickupP2 = status;
        if (status == true) { p2Holdable = item; }
        else { p2Holdable = null; }
    }

    public void grab(bool isP1, GameObject player) //allows a player to grab an item if they are capable of it
    {
        if (isP1 && pickupP1) {
            p1Held = p1Holdable;
            p1Holdable.transform.SetParent(player.transform, true);
        }
        else if (!isP1 && pickupP2)
        {
            p2Held = p2Holdable;
            p2Holdable.transform.SetParent(player.transform, true);
        }
    }
}
