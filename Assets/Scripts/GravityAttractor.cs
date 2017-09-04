using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityAttractor : MonoBehaviour
{
    [SerializeField] private float gravity = -10f;
    [SerializeField] private float rotationSpeed = 10f;

    public void Attract(Transform entity)
    {
        // Emit a ray from the entity position to the center of the shaped planet and save where it hits.
        RaycastHit hit;
        Vector3 from = entity.position;
        Vector3 direction = (transform.position - entity.position).normalized;

        // When the ray hits add the gravity force to the entity in order to attract it towars the planet,
        // then set the new entity rotation.
        Ray ray = new Ray(from, direction);
        if (Physics.Raycast(ray, out hit))
        {
            // Attracts the entity towars the planet
            entity.GetComponent<Rigidbody>().AddForce(hit.normal * gravity);
            // Sets the new entity rotation with a smooth transition.
            Quaternion destRotation = Quaternion.FromToRotation(entity.up, hit.normal) * entity.rotation;
            entity.rotation = Quaternion.Slerp(entity.rotation, destRotation, rotationSpeed * Time.deltaTime);
        }

        Debug.DrawLine(entity.position, hit.point, Color.red);
    }
}
