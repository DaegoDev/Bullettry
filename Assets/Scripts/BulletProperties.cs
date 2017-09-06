using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletProperties : MonoBehaviour {
    [SerializeField] private float lifeTime = 5f;
    public bool isMine = false;
	// Use this for initialization
	void Start () {
        Destroy(gameObject, lifeTime);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Bullet collision");
        Debug.Log(collision.collider.name.ToString());
        if (collision.collider.tag == "Player" && !isMine)
        {
            collision.gameObject.GetComponent<PlayerCtrl>().lifePoints -= 10;
            //Destroy(gameObject);
        }
      
    }
}
