using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimateDoor : MonoBehaviour
{
    [SerializeField]
    private Animator myAnimationController;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Scientist"))
        {
            myAnimationController.SetBool("character_nearby", true);
        }
        else if (other.CompareTag("Player"))
        {
            myAnimationController.SetBool("character_nearby", true);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Scientist"))
        {
            myAnimationController.SetBool("character_nearby", false);
        }
        else if (other.CompareTag("Player"))
        {
            myAnimationController.SetBool("character_nearby", false);
        }
    }
}
