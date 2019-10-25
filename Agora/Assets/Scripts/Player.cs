using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("General")]
    public Rigidbody rigidBody;
    public Transform groundingPosition;
    public Animator animator;

    [Header("Camera")]
    public GameObject mainCamera;
    public Transform cameraTransform;

    [Header("Controls")]
    public float speed;
    public float jumpHeight;
    float jumpNumber, jumpNumberMax;

    // Start is called before the first frame update
    void Start()
    {
        Init();
    }

    // Update is called once per frame
    void Update()
    {
        Grounding();
        Movement();
        Rotate();
        Jump();
    }

    void Init() {
        // Camera
        mainCamera.transform.position = cameraTransform.position;
        mainCamera.transform.rotation = cameraTransform.rotation;

        // Jumps
        jumpNumber = 0;
        jumpNumberMax = 2;
    }

    void Movement() {
        if(Input.GetKey(KeyCode.W)){
            transform.Translate(Vector3.forward * speed);
        }

        if(Input.GetKey(KeyCode.S)){
            transform.Translate(Vector3.forward * -speed);
        }

        if(Input.GetKey(KeyCode.A)){
            transform.Translate(Vector3.left * speed);
        }

        if(Input.GetKey(KeyCode.D)){
            transform.Translate(Vector3.right * speed);
        }
    }

    void Rotate() {
        transform.Rotate(0, Input.GetAxis("Mouse X"), 0);
        mainCamera.transform.Rotate(-Input.GetAxis("Mouse Y"), 0, 0);
    }

    void Jump() {
        if(Input.GetKeyDown(KeyCode.Space) && jumpNumber < jumpNumberMax)
        {
            animator.SetTrigger("Jump");
            jumpNumber++;
            rigidBody.AddForce(Vector3.up * jumpHeight);
        }
    }

    void Grounding() {
        RaycastHit hit;
        if(Physics.Raycast(groundingPosition.position, Vector3.down, out hit, .1f)) {
            Debug.DrawRay(groundingPosition.position, Vector3.down * .02f, Color.red);
            if(hit.collider.tag == "Ground")
            {
                jumpNumber = 0;
            }
        }
    }
}
