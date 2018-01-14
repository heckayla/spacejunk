using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grid_Box : MonoBehaviour { //used by each Grid_Box prefab to handle item detection, etc

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        string colTag = collision.gameObject.tag;
        if (colTag == "P1" || colTag == "P2") //this handles players entering a trashless box
        {
            bool isP1 = false; //initially set to false, so if the statement below fails, we know it must be false
            if (colTag == "P1") { isP1 = true; }
            Trash_Scene_Controller.instance.gridBoxTrashable(this.gameObject, isP1);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        string colTag = collision.gameObject.tag;
        if (colTag == "P1" || colTag == "P2") //this handles players leaving a trashless box
        {
            bool isP1 = false;
            if (colTag == "P1") { isP1 = true; }
            Trash_Scene_Controller.instance.gridBoxTrashable(null, isP1);
        }
    }
    
}
