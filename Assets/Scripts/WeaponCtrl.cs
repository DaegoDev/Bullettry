using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class WeaponCtrl : Photon.MonoBehaviour {

    [SerializeField] private Transform bulletSpawn;
    [SerializeField] private GameObject bullet;
    [SerializeField] private float nextFire;
    [SerializeField] private float fireRate;

    private PhotonView photonView;

    private Ray ray;
    private RaycastHit hit;

    // Use this for initialization
    void Start () {
        photonView = GetComponent<PhotonView>();
	}
	
	// Update is called once per frame
	void Update () {
        if(!photonView.isMine)
        {
            return;
        }
        if (Input.GetMouseButton(0) && Time.time > nextFire)
        {
            Shoot();
        }

    }

    void Shoot ()
    {
        Debug.Log(photonView.ownerId);
        nextFire = Time.time + fireRate;
        ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit))
           {
             Debug.DrawLine(Camera.main.transform.position, hit.point, Color.green);
             GameObject b = PhotonNetwork.Instantiate(Path.Combine("", "Bullet"), bulletSpawn.position, bulletSpawn.rotation, 0);
             b.transform.LookAt(hit.point);
            b.GetComponent<BulletProperties>().isMine = true;
            // b.layer = LayerMask.NameToLayer("Player");
         }
    }

}
