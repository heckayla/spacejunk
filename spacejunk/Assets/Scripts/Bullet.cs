using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Bullet : MonoBehaviour {

    public float BulletSpeed;
    public int destroyTime;
    public Sprite[] BulletArray;

    private SpriteRenderer spriteRenderer;
    private Rigidbody2D rb;
    private BulletManager bm;
	// Use this for initialization
	void Start () {
        bm = FindObjectOfType<BulletManager>();
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = BulletArray[new System.Random().Next(0, BulletArray.Length)]; //Randomly chooses a bullet sprite from the bullet manager
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        rb.MovePosition(new Vector2(rb.position.x + BulletSpeed, rb.position.y));
        if (destroyTime == 0) Destroy(this.gameObject);
        else destroyTime--;
    }

    public void DestroyBullet()
    {

    }
}
