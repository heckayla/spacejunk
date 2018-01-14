using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletManager : MonoBehaviour {
    
    public int BulletDelay;
    public GameObject bullet;

    private int delay;
    // Use this for initialization
    // Update is called once per frame
    void Update () {
		if(Input.GetAxis("Fire_weapon") > 0 && delay == 0)
        {
            CreateBullet();
        }
	}

    private void FixedUpdate()
    {
        if(delay > 0)
        {
            delay--;
        }
    }
    private void CreateBullet()
    {
        Instantiate(bullet, new Vector3(transform.position.x,transform.position.y,transform.position.z), this.gameObject.transform.rotation);
        delay = BulletDelay;
    }
}
