using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    public float fuel;
    public float movespeed = 1f;
    public Transform forwardDir;
    public UIManager UIManage;
    private bool isFuelUse;
    public bool inMove;
    public bool isFinish;
    private bool inAttraced;
    public Rigidbody2D rb;
    public GravityAtractor atrator;
	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody2D>();
        UIManage = FindObjectOfType<UIManager>();
        isFuelUse = false;
        inAttraced = false;
        inMove = false;
        isFinish = false;
	}
	
	// Update is called once per frame
	void Update () {


        if (inMove)
            transform.position = Vector2.MoveTowards(transform.position, forwardDir.position, movespeed * Time.deltaTime);
        if (Input.GetMouseButtonDown(0) && fuel > 0 && !isFinish)
        {
            inMove = true;
            isFuelUse = true;
        }
        else if (Input.GetMouseButtonUp(0))
        {
            //rb.velocity = new Vector2(0, rb.velocity.y);
            inMove = false;
            isFuelUse = false;
        }
        if (isFuelUse && fuel > 0)
        {
            fuel-= 1f;
            if (inAttraced)
                inAttraced = false;
        }
        if (inAttraced)
        {
            atrator.Attract(transform);
        }

	}
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(transform.position, forwardDir.position);
    }
    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.tag == "Planet")
        {
            atrator = other.GetComponent<GravityAtractor>();
            inAttraced = true;
        }
        if (other.tag == "Stasiun")
        {
            isFinish = true;
            if (UIManage != null)
                UIManage.EndGameLevel();
        }
            
            
    }
}
