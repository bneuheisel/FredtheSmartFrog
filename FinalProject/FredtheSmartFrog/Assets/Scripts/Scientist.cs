using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using System.Linq;

public class Scientist : MonoBehaviour
{
    public float maxSpeed = 3;
    public Transform[] paths;
    public Transform rightHand;

    public float Speed
    {
        get { return _speed; }
        set 
        { 
            _speed = value;
            //_anim.SetFloat("speed", Mathf.Abs(value), 0.1f, Time.deltaTime); 
            _anim.SetFloat("speed", value);
        }
    }

    private float _speed;
    private Animator _anim;
    private Rigidbody _rb;
    private DetectPlayer _detection;
    private NavMeshAgent _agent;
    private bool _waiting = false;

    void Awake()
    {
        _anim = GetComponent<Animator>();
        _rb = GetComponent<Rigidbody>();
        _detection = GetComponentInChildren<DetectPlayer>();
        _agent = GetComponent<NavMeshAgent>();
        _speed = maxSpeed;

        if (paths.Length == 1)
        {
            var ps = paths[0].GetComponentsInChildren<Transform>().ToList();
            ps.Remove(ps.First());
            paths = ps.ToArray();
        }
    }

    private void Start()
    {
        StartCoroutine(WaitForNewPath(0));
    }

    // Update is called once per frame
    void Update()
    {
        //_anim.SetFloat("speed", _agent.velocity.normalized.magnitude);
        //_anim.SetFloat("speed", Mathf.Abs(_agent.velocity.z), 0.1f, Time.deltaTime);
        updatePath();
    }

    void updatePath()
    {
        if (_detection.playerInSight)
        {
            _agent.SetDestination(_detection.playerLastKnownPos);
            _agent.speed = maxSpeed * 2;
            Speed = 1;
        }
        else if (_agent.remainingDistance < 0.1f && !_waiting)
        {
            StartCoroutine(WaitForNewPath(5f));
        }
    }

    IEnumerator WaitForNewPath(float sec)
    {
        _waiting = true;
        Speed = 0;
        yield return new WaitForSeconds(sec);
        _agent.SetDestination(GetNewPath());
        _agent.speed = maxSpeed * 0.5f;
        Speed = 0.5f;
        yield return new WaitForSeconds(0.5f);
        _waiting = false;
    }

    Vector3 GetNewPath()
    {
        return paths[Random.Range(0, paths.Length)].position;
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

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.gameObject.tag == "Player")
        {
            _agent.isStopped = true;
            collision.collider.GetComponent<PlayerController>().dead = true;
            _anim.SetTrigger("pickup");
            StartCoroutine(PickUpFrog(collision.transform));
            Destroy(collision.gameObject.GetComponent<Rigidbody>());
            _rb.constraints = RigidbodyConstraints.FreezeAll;
        }
    }

    IEnumerator PickUpFrog(Transform frog)
    {
        yield return new WaitForSeconds(1.25f);
        frog.SetParent(rightHand);
        frog.localPosition = new Vector3(0,0,-0.005f);
        frog.rotation = new Quaternion();
        frog.Rotate(Vector3.up, 80);
    }
}
