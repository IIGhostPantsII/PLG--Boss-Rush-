using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 10f;
    public float sprintMultiplier = 2f;
    public float jumpForce = 10f;
    public float mouseSensitivity = 100f;

    private Rigidbody rigidbody;
    private bool isSprinting;
    private bool isGrounded;
    public float groundCheckRadius = 1.0f;
    public LayerMask groundLayer;

    PlayerInput _input;
    private float _yaw;

    float xRotation = 0f;

    public Transform cameraTransform;

    bool _delay;

    private void Awake()
    {
        _input = new PlayerInput();
    }

    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
    }

    void Update()
    {
        bool jump = _input.Player.Jump.ReadValue<float>() > 0.1f;
        isSprinting = _input.Player.Sprint.ReadValue<float>() > 0.1f;;

        isGrounded = Physics.SphereCast(transform.position, groundCheckRadius, -Vector3.up, out RaycastHit hitInfo, 0.1f, groundLayer);

        if(jump && !_delay && isGrounded)
        {
            StartCoroutine(InputDelay());
            _delay = true;
            rigidbody.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }

        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        cameraTransform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        transform.Rotate(Vector3.up * mouseX);
    }

    void FixedUpdate()
    {
        float horizontal = _input.Player.Move.ReadValue<Vector2>().x;
        float vertical = _input.Player.Move.ReadValue<Vector2>().y;

        Vector3 movement = new Vector3(horizontal, 0, vertical);
        movement = transform.TransformDirection(movement);
        movement.y = 0;

        if (isSprinting)
        {
            movement *= sprintMultiplier;
        }

        if (!isGrounded)
        {
            movement.y -= 9.8f * Time.deltaTime;
        }

        rigidbody.velocity = movement * speed * Time.deltaTime;
    }

    private void OnEnable()
    {
        _input.Enable();
    }

    private void OnDisable()
    {
        _input.Disable();
    }

    IEnumerator InputDelay()
    {
        yield return new WaitForSeconds(0.15f);
        _delay = false;
    }
}
