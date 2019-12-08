using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Winning : MonoBehaviour
{
    //public Animator anim;
    //public Image black;

    void Start()
    {
        //anim.SetBool("Fade", false);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            SceneManager.LoadScene("GameWon");

        }

    }
    //IEnumerator fade()
    //{
    //    anim.SetBool("Fade", true);
    //    yield return new WaitUntil(() => black.color.a == 1);
    //    SceneManager.LoadScene("GameWon");
    //}
}
