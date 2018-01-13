using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup_Logic : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {

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
        }
        else if (collision.gameObject.tag == "P2")
        {
            Trash_Scene_Controller.instance.setPickupP2(true, this.gameObject);
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
    }
}
