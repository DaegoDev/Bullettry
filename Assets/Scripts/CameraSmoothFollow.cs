using UnityEngine;

public class CameraSmoothFollow : MonoBehaviour {
    [SerializeField] private Transform target;    
    [SerializeField] private Vector3 offsetPosition;
    [SerializeField] private bool lookAt = true;
    [SerializeField] private Space offsetPositionSpace = Space.Self;
    [SerializeField] private float positionSpeed = 10f;
    [SerializeField] private float rotationSpeed = 10f;



    private void LateUpdate()
    {
        // compute position
        if (offsetPositionSpace == Space.Self)
        {
            transform.position = Vector3.Lerp(
                transform.position, 
                target.TransformPoint(offsetPosition), 
                Time.deltaTime * positionSpeed);
        }
        else
        {
            transform.position = Vector3.Lerp(
                transform.position, 
                target.position + offsetPosition, 
                Time.deltaTime * positionSpeed);
        }

        // compute rotation
        if (lookAt)
        {
            //transform.LookAt(target);
            var targetRotation = Quaternion.LookRotation(target.position - transform.position);
            // Smoothly rotate towards the target point.
            transform.rotation = Quaternion.Slerp(
                transform.rotation, targetRotation,
                rotationSpeed * Time.deltaTime);

        }
        else
        {
            transform.rotation = target.rotation;
        }
    }
}

