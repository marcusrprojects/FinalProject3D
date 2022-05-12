using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Made using this tutorial: https://www.youtube.com/watch?v=_QajrabyTJc

public class PlayerMovement : MonoBehaviour
{
    public float speed = 1f;
    [Range(0.25f, 10.0f)]
    public float jumpHeight = 3f;

    public float groundDistance = 0.4f;
    [SerializeField] Transform groundCheck;
    [SerializeField] LayerMask groundMask;

    private const float GRAVITY = -9.8f;

    [Range(0.25f, 4.0f)]
    public float gravityScale;

    private Vector3 velocity;

    private bool isGrounded;

    private CharacterController controller;

    private Vector3 startPos;

    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
        startPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
        
        if(isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;

        if(move != Vector3.zero && !AudioManager.instance.IsPlaying("Footsteps"))
        {
            AudioManager.instance.Play("Footsteps");
        }

        if(move == Vector3.zero && AudioManager.instance.IsPlaying("Footsteps"))
        {
            AudioManager.instance.Stop("Footsteps");
        }

        controller.Move(move * speed * Time.deltaTime);

        if (Input.GetButtonDown("Jump") /*&& isGrounded*/)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * GRAVITY * gravityScale);
        }

        velocity.y += GRAVITY * gravityScale * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag.Equals("Death"))
        {
            Application.LoadLevel(Application.loadedLevel);
        }
    }
}
