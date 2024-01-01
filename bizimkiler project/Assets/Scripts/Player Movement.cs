using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController controller;
    
    AudioSource source;
    public AudioClip[] stepsounds;
    public AudioClip[] woodsounds;
    public AudioClip[] grasssounds;

    int soundControl;

    // 0 = Default

    // 1 = Grass

    // 2 = Wood

    public float speed = 20f;
    public float gravity = -9.81f;
    public float jumpheight = 3f;
    
    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;

    public float timeBetweenSteps;
    float timer;

    Vector3 velocity;
    bool isGrounded;
    bool isMoving;

    private void Start()
    {
        source = GetComponent<AudioSource>();
    }

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        switch (hit.transform.tag)
        {
            case "Metal":
                soundControl = 0;
                break;
            case "Wood":
                soundControl = 1;
                break;
            case "Grass":
                soundControl = 2;
                break;
        }
    }


    void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;

        controller.Move(move * speed * Time.deltaTime);

        if(Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpheight * -2f * gravity);
        }

        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);

        if(isGrounded)
        {
            if(x != 0 || z !=0)
            {
                isMoving = true;
            }
            else
            {
                isMoving = false;
            }
        }  
        else
        {
            isMoving = false;
        }

        if(isMoving)
        {
            timer -= Time.deltaTime;

            if(timer <= 0)
            {
                switch(soundControl)
                {
                    case 0: source.clip = stepsounds[Random.Range(0, stepsounds.Length)]; break;
                    case 1: source.clip = woodsounds[Random.Range(0, woodsounds.Length)]; break;
                    case 2: source.clip = grasssounds[Random.Range(0, grasssounds.Length)]; break;
                }


                //source.clip = stepsounds[Random.Range(0, stepsounds.Length)];
                timer = timeBetweenSteps;
                source.Play();
            }
        }
        else
        {
            timer = timeBetweenSteps;
        }
    }
}
