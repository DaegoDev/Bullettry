using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneShoot : MonoBehaviour {

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("Its a hit!");

        if (other.gameObject.tag == "YourTag")
        {
            Debug.Log("Its a hit! " + other.gameObject.tag);
        }
    }
}
