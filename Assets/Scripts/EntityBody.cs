using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityBody : MonoBehaviour {

    [SerializeField] GravityAttractor gAttractor;

    private Rigidbody rb;

	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody>();
        rb.constraints = RigidbodyConstraints.FreezeRotation;
        rb.useGravity = false;
        gAttractor = (GravityAttractor) GameObject.FindGameObjectWithTag("Planet").GetComponent<GravityAttractor>();
	}
	
	// Update is called once per frame
	void Update () {
        gAttractor.Attract(transform);
	}
}
