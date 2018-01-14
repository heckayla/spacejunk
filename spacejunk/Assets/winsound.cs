using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class winsound : MonoBehaviour {

    private AudioSource audio;
    private BoxCollider2D bc;
	// Use this for initialization
	void Start () {
        audio = GetComponent<AudioSource>();
        bc = GetComponent<BoxCollider2D>();
	}

    // Update is called once per frame
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            audio.PlayOneShot(audio.clip);
            bc.gameObject.SetActive(false);
        }
    }
}
