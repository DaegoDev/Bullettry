using System;
using UnityEngine;
using UnityEngine.UI;

public class CurrentRoomCanvas : MonoBehaviour {
    public Text mapNumber;

    public void OnClickStartSync() {
		if (!PhotonNetwork.isMasterClient) return;
        
		PhotonNetwork.LoadLevel(Int32.Parse(mapNumber.text));
	}

	public void OnClickStartDelayed() {
		if (!PhotonNetwork.isMasterClient) return;

		PhotonNetwork.room.IsOpen = false;
		PhotonNetwork.room.IsVisible = false;
		PhotonNetwork.LoadLevel(Int32.Parse(mapNumber.text));
	}

}
