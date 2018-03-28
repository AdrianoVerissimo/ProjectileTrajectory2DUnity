using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileController : MonoBehaviour {

    public Vector2 velocity;

	// Use this for initialization
	void Start () {
        GetComponent<Rigidbody2D>().velocity = velocity;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("ground"))
        {
            GetComponent<Rigidbody2D>().drag = 1f;
        }
    }
}
