using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController charaCon;
    public float speed;
    public float jumpHeight = 3f;
    public float gravity = -9.81f;
    Vector3 velocity;
    bool isGrounded;
    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;
    public ParticleSystem snow;

    void Update()
    {
        //checking if the player is on the ground
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
        
        if(isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;

        charaCon.Move(move * speed * Time.deltaTime);

        if(Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }

        velocity.y += gravity * Time.deltaTime;
        charaCon.Move(velocity * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        //stop snow when under water
        if (other.CompareTag("WaterVolume"))
        {
            snow.Stop();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        //resume snow when leaving water
        if (other.CompareTag("WaterVolume"))
        {
            snow.Play();
        }
    }
}
