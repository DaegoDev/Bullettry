using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementScript : Photon.MonoBehaviour {

    private Rigidbody rb;
    public float moveSpeed = 20f;
    public float rotateSpeed = 100f;

    private Vector3 moveDirection;
    private Vector3 rotateDirection;

    public float netPositionSpeed;
    public float netRotationSpeed;

    private PhotonView photonView;

    private Vector3 transformPosition;
    private Quaternion transformRotation;

    private void Awake()
    {
        photonView = GetComponent<PhotonView>();
    }

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
  
    }

    void FixedUpdate()
    {        
        if (photonView.isMine)
        {
            moveDirection = new Vector3(0, 0, Input.GetAxisRaw("Vertical")).normalized;
            rotateDirection = Input.GetAxisRaw("Horizontal") * Vector3.up * rotateSpeed * Time.deltaTime;
            rb.MovePosition(rb.position + transform.TransformDirection(moveDirection) * moveSpeed * Time.deltaTime);
            transform.Rotate(rotateDirection);
        } else
        {
            transform.position = Vector3.Lerp(transform.position, transformPosition, netPositionSpeed * Time.deltaTime);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, transformRotation, netRotationSpeed * Time.deltaTime);
        }

    }

    private void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        if(stream.isWriting)
        {
            stream.SendNext(transform.position);
            stream.SendNext(transform.rotation);

        }
        else
        {
            transformPosition = (Vector3) stream.ReceiveNext();
            transformRotation = (Quaternion) stream.ReceiveNext();

        }
    }
}
