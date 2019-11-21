using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class PlayerController : MonoBehaviour
{
    public float maxSpeed = 3;
    public float jumpPower = 10;
    public Transform cm_cam;
    public Transform body;
    public bool dead = false;

    private FixedJoystick _jstick;
    public FixedButton _jumpbtn;
    private Rigidbody _rb;
    private Collider _col;

    private bool _jumping = false;

    // Start is called before the first frame update
    void Start()
    {
        if (!cm_cam) cm_cam = GameObject.Find("ThirdPersonCamera").transform;   // this assumes such a camera exists
        if (!body) body = transform.Find("frog");                               // this pertains to frog prefab

        _jstick = FindObjectOfType<FixedJoystick>();
        //_jumpbtn = FindObjectOfType<FixedButton>();
        _rb = GetComponent<Rigidbody>();
        _col = GetComponent<Collider>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!dead)
        {
            HandleMovement();
            HandleJump();
        }
        else
        {
            _col.enabled = false;
        }
    }

    void HandleMovement()
    {
/*#if UNITY_EDITOR_WIN
        _jstick.inputVector = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        _jumpbtn.Pressed = Input.GetButtonDown("Jump");
#endif*/

        // Incremental movement
        float movePerSec = maxSpeed * Time.deltaTime;

        // Set values for converting joystick movement in direction of camera
        Vector3 camForward = cm_cam.forward;
        Vector3 camRight = cm_cam.right;
        camForward.y = camRight.y = 0;
        camForward = camForward.normalized;
        camRight = camRight.normalized;

        // Apply next position in worldspace to move to
        Vector3 nextPos = transform.position + (camForward * _jstick.inputVector.y + camRight * _jstick.inputVector.x) * movePerSec;
        
        // Animate frog moving
        if (!_jumping && _jstick.inputVector.sqrMagnitude > 0)
        {
            body.GetComponent<Frog>().Move();
        }

        // Rotate body towards direction
        body.LookAt(nextPos);

        // Use rigidbody to move
        _rb.MovePosition(nextPos);

        
    }

    void HandleJump()
    {
        if (_jumpbtn.Pressed && !_jumping)
        {
            _jumping = true;
            _rb.AddForce(Vector3.up * jumpPower, ForceMode.Impulse);
            body.GetComponent<Frog>().Leap();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.gameObject.layer != LayerMask.NameToLayer("Wall"))
        {
            _jumping = false;
        }
    }
}
