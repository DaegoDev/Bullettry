using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetCtrl : MonoBehaviour {
    public GameObject[] spawnPoints;
    [SerializeField] Gradient gradient;
    [SerializeField] float colorSpeed;
    public float t = 0f;

    private void Update()
    {
        if(t >= 0.99f)
        {
            t = 0f;
        }
        t += colorSpeed;
        Color color = gradient.Evaluate(t);

        Renderer renderer = GetComponent<Renderer>();
        Material mat = renderer.material;
        mat.SetColor("_EmissionColor", color * 100f);
    }
}
