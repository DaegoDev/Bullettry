using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCtrl : MonoBehaviour {

    public GameObject plane;

    private PhotonView photonView;
    private Camera camera;
    private GameObject spawnPoint;
    private Color[] playerColor = { Color.yellow, Color.red, Color.green, Color.blue };

    public int lifePoints = 100;


	// Use this for initialization
	void Start () {
        photonView = GetComponent<PhotonView>();
        if (photonView.isMine)
        {
            camera = Camera.main;
            camera.GetComponent<CameraSmoothFollow>().target = transform;
            camera.GetComponent<CameraSmoothFollow>().enabled = true;
            plane.SetActive(true);
        } else
        {
            //gameObject.tag = "Enemy";
            //gameObject.layer = LayerMask.NameToLayer("Enemy");
            plane.SetActive(false);
        }

        Renderer renderer = GetComponent<Renderer>();
        Material mat = renderer.material;
        mat.SetColor("_EmissionColor", playerColor[photonView.ownerId - 1] * 30f);     
        //DynamicGI.SetEmissive(renderer, playerColor[photonView.ownerId - 1] * 100f);
    }

    private void Update()
    {
        if(lifePoints <= 0)
        {
            //Destroy(gameObject);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Player collision");
        Debug.Log(collision.collider.name);
        if(collision.collider.name == "Proyectile")
        {
            lifePoints -= 10;
            Debug.Log("La vida del jugador es: " + lifePoints);
        }
    }
}
