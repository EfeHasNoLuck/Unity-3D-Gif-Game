using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController controller;
    
    AudioSource source;
    public AudioClip[] stepsounds;

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

            if(timer < 0)
            {
                timer = timeBetweenSteps;
                
                source.clip = stepsounds[Random.Range(0, stepsounds.Length)];
                
                source.Play();
                Debug.Log("selam");
            }
        }
        else
        {
            timer = timeBetweenSteps;
        }
    }
}
