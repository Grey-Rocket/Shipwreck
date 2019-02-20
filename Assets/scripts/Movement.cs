using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public Rigidbody2D rb2D;
    int speed; 
    public Transform startingLocation;

    // Start is called before the first frame update
    void Start()
    {
        rb2D = this.GetComponent<Rigidbody2D>();
        speed = 0;
        rb2D.AddForce(new Vector2(10, 10));
        //startingLocation = this.transform;
    }

    // Update is called once per frame
    void Update()
    {
        //
        if (Input.GetAxisRaw("Horizontal") != 0)
        {
            Debug.Log("It works");
        }

        if (Input.GetKeyDown("up") || Input.GetKeyDown("w"))
        {
            if (speed < 2)
            {
                speed++;
            }
            Debug.Log(speed);
        }
        else if (Input.GetKeyDown("down") || Input.GetKeyDown("s"))
        {
            if (speed > -2)
            {
                speed--;
            }
            Debug.Log(speed);
        }

    }

    void FixedUpdate()
    {
        rb2D.AddForce(new Vector2(10,10));

    }
}
