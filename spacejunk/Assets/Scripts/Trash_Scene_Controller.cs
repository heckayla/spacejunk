using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Trash_Scene_Controller : MonoBehaviour {

    public static Trash_Scene_Controller instance;

    bool pickupP1 = false; //if p1 can pickup trash
    bool pickupP2 = false; //if p2 can pickup trash

    GameObject p1Holdable = null; //the item p1 is currently on top of
    GameObject p2Holdable = null; //the item p2 is currently on top of
    GameObject p1Held = null; //the item p1 holds
    GameObject p2Held = null; //the object p2 holds

    GameObject trashableBoxP1 = null; //holds the box P1 can trash
    GameObject trashableBoxP2 = null; //holds the box P2 can trash

    int trashCollected = 0; //how much trash is placed into the rocket slots

    public void Awake()
    {
        if (instance != null)
        {
            Debug.LogError("Seems like there is more than one Trash Scene Controller in the scene");
        }
        instance = this;
    }
    //some comment
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
        if (isP1 && pickupP1 && p1Holdable != p2Held) { //players cannot grab items off of other players
            p1Held = p1Holdable;
            p1Holdable.transform.SetParent(player.transform, true);
            p1Holdable.transform.position = player.transform.position;
            p1Holdable.transform.Translate(0, 0, -2); //puts the garbage on top of raccoon
            if (trashableBoxP1 != null) { addTrash(false, 0); } //take away trashCount if grabbing from a gridbox
        }
        else if (!isP1 && pickupP2 && p2Holdable != p1Held)
        {
            p2Held = p2Holdable;
            p2Holdable.transform.SetParent(player.transform, true);
            p2Holdable.transform.Translate(0, 0, -2); //puts the garbage on top of raccoon
            if (trashableBoxP2 != null) { addTrash(false, 0); } //take away trashCount if grabbing from a gridbox
        }
    }

    public void drop(bool isP1, GameObject player)
    { //allows a player to drop an item they're holding
        if (isP1)
        {
            if (trashableBoxP1 == null)
                //this means you're just dropping trash in the gameworld, nowhere specific
            {
                p1Held.transform.SetParent(this.gameObject.transform.parent, true);
            }
            else
            { //this means you're dropping trash in the grid
                    p1Held.transform.SetParent(trashableBoxP1.transform, true);
                    addTrash(true, trashableBoxP1.transform.childCount);
            }
            p1Held.transform.Translate(0, 0, 2);
            p1Held = null;
        }
        else
        {
            if (trashableBoxP2 == null)
            {
                p2Held.transform.SetParent(this.gameObject.transform.parent, true);
            }
            else
            {
                p2Held.transform.SetParent(trashableBoxP2.transform, true);
                addTrash(true, trashableBoxP2.transform.childCount);
            }
            p2Held.transform.Translate(0, 0, 2);
            p2Held = null;
        }
    }

    public GameObject getHeldItem(bool isP1)
    {
        if (isP1) { return p1Held; }
        else { return p2Held; }
    }

    public void addTrash(bool add, int trashed) //used to add and subtract one trash, depending on bool
    {
        if (add) {
            trashCollected += 1;
            Debug.Log("Trash has been added. trashCollected is " + trashCollected);
            if (trashCollected >= 15) { finishScene(); } //this scene is over because collection is done!
        }
        else {
            trashCollected -= 1;
            Debug.Log("Trash has been removed. trashCollected is " + trashCollected);
        }
        if (trashCollected < 0) { Debug.Log("The trashCollected value is low. It's " + trashCollected); }

        if (trashed > 14) {
            Debug.Log("you won!");
            finishScene(); }
    }

    public void gridBoxTrashable(GameObject gridbox, bool isP1) //tells the manager that a gridbox is able to be trashed
    {
        if (isP1) { trashableBoxP1 = gridbox; }
        else { trashableBoxP2 = gridbox; }
    }

    public void finishScene()
    {
        SceneManager.LoadScene("Transition");
    }
}
