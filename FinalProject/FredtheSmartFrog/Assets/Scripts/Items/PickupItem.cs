using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupItem : MonoBehaviour
{
    public GameObject barrier1;

    void OnTriggerEnter(Collider coll)
    {
        if (coll.gameObject.name == "FredTheFrog")
        {
            Destroy(barrier1);
            Destroy(this.gameObject);
        }
    }
}
