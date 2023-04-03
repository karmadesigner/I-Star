using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CelestialObject : MonoBehaviour
{

    public Vector2 direction;
    public float speed = 0f;
   
    public Rigidbody2D myRigidBody;
    public float G = 50f;

    private Entity myEntity;

    public CelestialSystem mySystem;

    // Start is called before the first frame update
    void Start()
    {
        float random = UnityEngine.Random.Range(0f, 260f);

        //direction = new Vector2(Mathf.Cos(random), Mathf.Sin(random));
       
         myRigidBody.velocity = new Vector2(Mathf.Cos(random) * speed, Mathf.Sin(random) * speed);
    }

    // Update is called once per frame
    void Update()
    {
       // Move();

    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        
        

        if (this.gameObject.name.Equals("I,Star"))
        {         
            
            mySystem.Annihilate(this.gameObject, collision.gameObject);
        }
            
    }

    private void Move()
    {
        //transform.Translate(direction * speed * Time.deltaTime);
    }

    public void Attract(List<CelestialObject> targets)
    {
        foreach (CelestialObject target in targets)
        {
            if (target != this)
            {
                Vector2 direction = transform.position - target.transform.position;
                float distance = direction.magnitude;

                if (distance > 1)
                {
                    float forceMagnitude = G * (myRigidBody.mass * target.myRigidBody.mass) / Mathf.Pow(distance, 2);

                    Vector2 force = direction.normalized * forceMagnitude;

                    target.myRigidBody.AddForce(force);
                }
            }
        }
    }
}
