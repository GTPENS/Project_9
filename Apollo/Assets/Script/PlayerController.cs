using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    public float fuel;
    private bool isFuelUse;
    public Rigidbody2D rb;
	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody2D>();
        isFuelUse = false;
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButtonDown(0) && fuel > 0)
        {
            rb.velocity = new Vector2(3, rb.velocity.y);
            isFuelUse = true;
        }
        else if (Input.GetMouseButtonUp(0))
        {
            rb.velocity = new Vector2(0, rb.velocity.y);
            isFuelUse = false;
        }
        if (isFuelUse && fuel > 0)
        {
            fuel-= 1f;
        }
	}
}
