using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PhotonNetworkManager : Photon.MonoBehaviour {

    [SerializeField] private Text connectText;
    [SerializeField] private GameObject player;
    [SerializeField] private Transform spawnPoint;
    [SerializeField] private GameObject lobbyCamera;

	// Use this for initialization
	private void Start () {
        PhotonNetwork.ConnectUsingSettings("V0.0.0");
	}

    public virtual void OnJoinedLobby() {
        Debug.Log("We have now joined the lobby.");
        // Join room if exits or create one.
        PhotonNetwork.JoinOrCreateRoom("New", null, null); 
    }

    public virtual void OnJoinedRoom()
    {

    }
	
	// Update is called once per frame
	private void Update () {
        connectText.text = PhotonNetwork.connectionStateDetailed.ToString();
	}
}
