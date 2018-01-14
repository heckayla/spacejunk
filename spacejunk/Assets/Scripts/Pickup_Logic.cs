using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup_Logic : MonoBehaviour
{

    public string gbName = "fire_ext";
    SpriteRenderer spr_rend; //the SpriteRenderer for this piece of garbage. Holds its current sprite
    Sprite spr_orig; //the initial sprite of this piece of garbage
    Sprite spr_hl; //the highlighted sprite for this piece of garbage

    // Use this for initialization
    void Start()
    { //loads all the necessary sprites for the garbage. Only two of them tbh
        spr_rend = this.gameObject.GetComponent<SpriteRenderer>();
        spr_orig = spr_rend.sprite;
        spr_hl = Resources.Load<Sprite>("Garbage/" + gbName + "_hl");
        Debug.Log(gbName);
        Debug.Log(spr_hl);
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision) //note: other is guaranteed to be a player
    {
        if (collision.gameObject.tag == "P1")
        {
            Trash_Scene_Controller.instance.setPickupP1(true, this.gameObject);
            spr_rend.sprite = spr_hl; //highlights the garbage
        }
        else if (collision.gameObject.tag == "P2")
        {
            Trash_Scene_Controller.instance.setPickupP2(true, this.gameObject);
            spr_rend.sprite = spr_hl; //highlights the garbage
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "P1")
        {
            Trash_Scene_Controller.instance.setPickupP1(false, this.gameObject);
        }
        else if (collision.gameObject.tag == "P2")
        {
            Trash_Scene_Controller.instance.setPickupP2(false, this.gameObject);
        }
        spr_rend.sprite = spr_orig; //de-highlights the garbage
    }
}
