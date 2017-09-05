using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponCtrl : MonoBehaviour {

    [SerializeField] private Transform bulletSpawn;
    [SerializeField] private GameObject bullet;
    [SerializeField] private float nextFire;
    [SerializeField] private float fireRate;


    // Use this for initialization
    void Start () {
	}
	
	// Update is called once per frame
	void Update () {
        if(Input.GetMouseButton(0) && Time.time > nextFire) 
        {
            nextFire = Time.time + fireRate;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if(Physics.Raycast(ray, out hit))
            {
                Debug.DrawLine(Camera.main.transform.position, hit.point, Color.green);
                GameObject b = Instantiate(bullet, bulletSpawn.position, bulletSpawn.rotation);
                b.transform.LookAt(hit.point);
            }
        }
    }
}
