using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Frog : MonoBehaviour
{
    private Animator _anim;

    // Start is called before the first frame update
    void Start()
    {
        _anim = GetComponent<Animator>();
    }

    public void Move()
    {
        _anim.SetTrigger("move");
    }

    public void Leap()
    {
        _anim.SetTrigger("leap");
    }
}
