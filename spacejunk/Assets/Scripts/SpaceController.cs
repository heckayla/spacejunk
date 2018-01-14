using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceController : MonoBehaviour {

    public float scrollRate;
    public Sprite debugSprite;
    SpriteRenderer spriteRender;

    private Rigidbody2D rb;
	// Use this for initialization
	void Start () {
        spriteRender = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        rb.MovePosition(new Vector2(rb.position.x + scrollRate, rb.position.y));
	}

    public void AddSprite(Sprite sprite)
    {
        spriteRender.sprite = sprite;
    }
}
