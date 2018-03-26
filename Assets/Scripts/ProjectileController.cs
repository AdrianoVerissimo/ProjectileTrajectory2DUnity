using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileController : MonoBehaviour {

    public Vector2 velocity;
    public float bounce_damping = 1f;
    public LayerMask layerHit;

    private Vector2 gravity;
    private Vector2 last_pos;

	// Use this for initialization
	void Start () {
        gravity = Physics2D.gravity;
        last_pos = Vector2.zero;
	}
	
	// Update is called once per frame
	void Update () {
        float play_speed = Time.deltaTime;
        velocity += gravity * play_speed;
        RaycastHit2D hit;
        last_pos = transform.position;
        hit = Physics2D.Linecast(last_pos, (last_pos + (velocity * play_speed)), layerHit);
        if (hit)
        {
            velocity = Vector2.Reflect(velocity * bounce_damping, hit.normal);
            transform.position = hit.point;
        }
        transform.position += (Vector3)(velocity * play_speed);
    }
}
