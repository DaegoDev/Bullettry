using UnityEngine;

public class CameraSmoothFollow : MonoBehaviour {
    [SerializeField] private Transform target;
    [SerializeField] private float smoothSpeed = 0.125f;
    [SerializeField] private Vector3 offset;
    [SerializeField] private Vector3 rotationOffset;
    private Vector3 nexPosition;
    private Vector3 lastPosition;

    private Quaternion nextRotation;
    private Quaternion lastRotation;

    private void LateUpdate()
    {
        //Vector3 desiredposition = target.position + offset;
        //Vector3 smoothedposition = Vector3.Lerp(transform.up, desiredposition, smoothSpeed * Time.deltaTime);
        //transform.position = smoothedposition;
        //transform.rotation = target.rotation;
        //transform.up = target.up;
        //transform.LookAt(target);

        transform.position = transform.TransformDirection(new Vector3(0f, 7f, -17.76f)* 50); ;

        //transform.position = Vector3.Lerp(transform.position, target.position + offset, time.deltatime * mathf.clamp((target.position - transform.position).sqrmagnitude * 8, .1f, 5));
        //transform.rotation = Quaternion.slerp(transform.rotation, target.rotation, time.deltatime * mathf.clamp(vector3.angle(target.forward, transform.forward) / 90 * 4, .1f, 5));

    }
}

