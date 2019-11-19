using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.AI;

public class Scientist : MonoBehaviour
{
    const int PLAYER_LAYER = 1 << 9, WALL_LAYER = 1 << 10;

    public float maxSpeed = 3;

    //public float detectionRadius = 10;  // old

    public float Speed
    {
        get { return _speed; }
        set { _speed = value; _anim.SetFloat("speed", value); }
    }

    private float _speed;
    private Animator _anim;
    private Rigidbody _rb;
    private DetectPlayer _detection;
    private NavMeshAgent _agent;
    //private bool _playerFound = false;  // old

    // Start is called before the first frame update
    void Start()
    {
        _anim = GetComponent<Animator>();
        _rb = GetComponent<Rigidbody>();
        _detection = GetComponent<DetectPlayer>();
        _agent = GetComponent<NavMeshAgent>();
        _speed = maxSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        _anim.SetFloat("speed", _agent.velocity.normalized.magnitude);
        updateDetection();
    }

    void updateDetection()
    {
        if (_detection.playerInSight)
        {
            _agent.SetDestination(_detection.playerLastKnownPos);
        }
    }

    //void HandleDetectionOld()
    //{
    //    // Get objects within radius (only detects player layered objects)
    //    Collider[] objects = Physics.OverlapSphere(transform.position, detectionRadius, PLAYER_LAYER);

    //    // If player found
    //    if (objects.Length > 0)
    //    {
    //        // Shoot raycast to check if player is within line of sight
    //        RaycastHit hit;
    //        bool somethingInSight = Physics.Raycast(transform.position, objects[0].transform.position - transform.position, out hit, detectionRadius);
    //        if (!_playerFound && somethingInSight && hit.collider.gameObject.tag == "Player")
    //        {
    //            print(gameObject.name + " found " + hit.collider.name + "!");
    //            _playerFound = true;
    //        }
    //    }
    //    else _playerFound = false;
    //}

    void HandleMovement()
    {
        
    }
}
