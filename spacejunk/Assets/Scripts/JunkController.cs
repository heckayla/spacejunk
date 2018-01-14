using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JunkController : MonoBehaviour {

    public Sprite[] JunkSprites;

    public SpaceJunk[] SpaceJunks;
	// Use this for initialization
	void Start () {
		foreach (SpaceJunk junk in SpaceJunks)
        {
            SpriteRenderer sr = junk.GetComponent<SpriteRenderer>();
            sr.sprite = JunkSprites[new System.Random().Next(0, JunkSprites.Length)];
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
