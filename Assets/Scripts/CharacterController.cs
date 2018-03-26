using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour {

    public GameObject fireball;
    public Transform fireSpawn;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	
        if (Input.GetKeyDown(KeyCode.X))
        {
            Instantiate(fireball, fireSpawn.position, Quaternion.identity);
        }

	}

    public void DrawTrajectory(Vector2 startPos, Vector2 startVelocity)
    {
        int verts = 20;
        LineRenderer line = GetComponent<LineRenderer>();
        line.SetVertexCount(verts);
 
        Vector2 pos = startPos;
        Vector2 vel = startVelocity;
        Vector2 grav = new Vector2(Physics2D.gravity.x, Physics2D.gravity.y);
        for(var i = 0; i<verts; i++)
        {
            line.SetPosition(i, new Vector3(pos.x, pos.y, 0f));
            vel = vel + grav* Time.fixedDeltaTime;
        pos = pos + vel* Time.fixedDeltaTime;
        }
    }
}
