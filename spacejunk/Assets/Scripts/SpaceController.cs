using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceController : MonoBehaviour {

    public float scrollRate;
    public Sprite debugSprite;
    public float movementMod;

    SpriteRenderer spriteRender;
    private Camera camera;
    private Rigidbody2D rb;
    private float steerShip;


	void Start () {
        spriteRender = GetComponent<SpriteRenderer>();
        //spriteRender.size.Set(2f, 1f);
        rb = GetComponent<Rigidbody2D>();
        spriteRender.sprite = debugSprite;
	}

    private void Update()
    {
        if(Input.GetAxis("Steer_ship") != 0)
        {
            steerShip = Input.GetAxis("Steer_ship") / movementMod;
        }
        else steerShip = 0f;
    }

    void FixedUpdate () {
        rb.MovePosition(new Vector2(rb.position.x + scrollRate, rb.position.y + steerShip));
	}

    public void AddSprite(Sprite sprite) //This method will change the rocket body to any sprite passed into it
    {
        spriteRender.sprite = debugSprite;
    }
}
