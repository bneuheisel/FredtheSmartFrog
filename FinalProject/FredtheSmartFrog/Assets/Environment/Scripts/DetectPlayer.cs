using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectPlayer : MonoBehaviour
{
    [Header("Modify these")]
    public float fieldOfViewAngle = 120f;
    public LayerMask thingsItCanSee;

    [Header("Set dynamically")]
    public bool playerInSight;
    public Vector3 playerLastKnownPos;

    private SphereCollider _sCol;
    private GameObject _player;

    // Start is called before the first frame update
    void Start()
    {
        _sCol = GetComponent<SphereCollider>();
        _player = GameObject.FindGameObjectWithTag("Player");
    }

    void OnTriggerStay(Collider other)
    {
        // If player is within radius
        if (other.gameObject == _player)
        {
            playerInSight = false;
            print(other.name);
            // Get direction from scientist to player
            Vector3 direction = other.transform.position - transform.position;
            // Get angle from direction of player to scientist's forward vector
            float angle = Vector3.Angle(direction, transform.forward);

            // if player is within field of view
            if (angle < fieldOfViewAngle * 0.5f)
            {
                // Shoot raycast to see if nothing is blocking view
                RaycastHit hit;
                if (Physics.Raycast(transform.position + transform.up, direction.normalized, out hit, _sCol.radius, thingsItCanSee))
                {
                    if (hit.collider.gameObject == _player)
                    {
                        playerInSight = true;
                        playerLastKnownPos = _player.transform.position;
                    }
                }
            }
        }
    }
}
