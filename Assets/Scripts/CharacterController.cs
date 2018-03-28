using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour {

    public GameObject fireball;
    public Transform fireSpawn;
    public int lineVertices = 100;
    public float intervalPower = 1f;

    public Vector2 projectileVelocity;

    private float velX = 0f, velY = 0f;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        //direcionais
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            velY += intervalPower;
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            velY -= intervalPower;
        }

        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            velX += intervalPower;
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            velX -= intervalPower;
        }
        projectileVelocity = new Vector2(velX, velY);

        DrawTrajectory(fireSpawn.position, projectileVelocity);

        if (Input.GetKeyDown(KeyCode.X))
        {
            GameObject obj = Instantiate(fireball, fireSpawn.position, Quaternion.identity);
            obj.GetComponent<ProjectileController>().velocity = projectileVelocity;
        }
        if (Input.GetKeyDown(KeyCode.Z))
        {

        }

    }

    public void DrawTrajectory(Vector2 startPos, Vector2 startVelocity)
    {
        int verts = lineVertices;
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
