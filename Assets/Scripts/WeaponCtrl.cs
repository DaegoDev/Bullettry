using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponCtrl : MonoBehaviour {

    [SerializeField] Transform bulletSpawn;
    [SerializeField] GameObject bullet;
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            GameObject b = Instantiate(bullet, bulletSpawn.position, bulletSpawn.rotation);
        }
    }
}
