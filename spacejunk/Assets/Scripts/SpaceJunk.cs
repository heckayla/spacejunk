using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceJunk : MonoBehaviour {

    public Sprite[] junkSprites;

    private SpriteRenderer sr;

	// Use this for initialization
	void Start () {
        sr = GetComponent<SpriteRenderer>();
        sr.sprite = junkSprites[new System.Random().Next(0, junkSprites.Length)];
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
