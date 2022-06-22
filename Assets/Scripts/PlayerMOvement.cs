using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMOvement : MonoBehaviour
{
    [SerializeField] CharacterController controller;
    [SerializeField] float speed;
    [SerializeField] Transform GroundCheck;
    [SerializeField] bool isGrounded;
    [SerializeField] float groundDistance;
    [SerializeField] LayerMask layermask;
   
    float horizontal;
    float vertical;
    float gravity;
    float jumpHeight;
    Vector3 move, velocity;
    // Start is called before the first frame update
    void Start()
    {
        horizontal = 0f;
        vertical = 0f;
        move = Vector3.zero;
        velocity = Vector3.zero;
        speed = 5f;
        gravity = -9.81f;
        groundDistance = 0.4f;
        jumpHeight = 0.7f;
    }

    // Update is called once per frame
    void Update()
    {
        isGrounded = Physics.CheckSphere(GroundCheck.position, groundDistance, layermask);
        if (isGrounded && velocity.y < 0f)
        {
            velocity.y = -2f;
        }
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");
        move = transform.right * horizontal + transform.forward * vertical;
        controller.Move(move*speed*Time.deltaTime);
        if(Input.GetKeyDown(KeyCode.Space)&&isGrounded)
        {
        Debug.Log("Pressed");
        velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }
        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }
   
}
