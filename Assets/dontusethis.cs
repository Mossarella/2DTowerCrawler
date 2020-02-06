using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{ 
    enum State { Alive,Dying,Transcend};
    Rigidbody rigidBody;
    AudioSource audiosource;

     [SerializeField] float rThrust = 100f;
    [SerializeField] float accelerateThrust = 100f;

    State state = State.Alive;

    bool DeadlyTouch = true;



    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        Invoke("Spawn", 1f);
        if (Debug.isDebugBuild)
            Cheatcodes();
    }

    private void Cheatcodes()
    {
        //TODO write something
    }
    private void Spawn()
    {
        if (state == State.Alive)
        {
            Movement();
            Jumping();
        }
    }

    private void Jumping()
    {
       
    }

    private void Movement()
    {
        float thrustThisFrame = accelerateThrust * Time.deltaTime;
        if (Input.GetKey(KeyCode.D))
        {
            rigidBody.AddRelativeForce(Vector3.forward * thrustThisFrame);
            if (!audiosource.isPlaying) // so it doesn't layer
            {

            }
        }

        else
        {
            audiosource.Stop();
        }
    }


    void OnCollisionEnter(Collision collision)
    {
        if (state != State.Alive || !DeadlyTouch)
        {
            return;
        }
        switch (collision.gameObject.tag)
        {
            case "Friendly":
                break;
            case "Finish":             
                state = State.Transcend;
                break;

            case "Deadly":
                state = State.Dying;
                print("Ded");
                break;
        }
    }
}
