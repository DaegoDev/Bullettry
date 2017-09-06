using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;

public class PlayerNetwork : MonoBehaviour {

	public static PlayerNetwork Instance;
	public string PlayerName { get; private set; }

	private PhotonView PhotonView;
	private int PlayerInGame = 0;

    private GameObject planet;

    private int numberMap = 0;


    private void Awake () {
		Instance = this;
		PhotonView = GetComponent<PhotonView>();
		PlayerName = "Player#" + Random.Range(1000, 9999);
		SceneManager.sceneLoaded += OnSceneFinishedLoading;
	}

	private void OnSceneFinishedLoading(Scene scene, LoadSceneMode mode) {
        if(scene.name == "SphereMap")
        {
            numberMap = 1;
        }
        else if(scene.name == "RoundedCilinderMap")
        {
            numberMap = 2;

        }
        else if (scene.name == "SquareRoundedMap")
        {
            numberMap = 3;

        }

        if ( numberMap != 0) {
            planet = GameObject.FindGameObjectWithTag("Planet");
            if (PhotonNetwork.isMasterClient)
            {
                MasterLoadingGame();
            }

            else {
                NonMasterLoadingGame();
            }
        }
	}

	private void MasterLoadingGame() {
		PhotonView.RPC("RPC_LoadedGameScene", PhotonTargets.MasterClient);
		PhotonView.RPC("RPC_LoadGameOthers", PhotonTargets.Others);
	}

	private void NonMasterLoadingGame() {
		PhotonView.RPC("RPC_LoadedGameScene", PhotonTargets.MasterClient);
	}

	[PunRPC]
	private void RPC_LoadGameOthers() {
		PhotonNetwork.LoadLevel(numberMap);
	}

	[PunRPC]
	private void RPC_LoadedGameScene() {
		PlayerInGame++;

		if (PlayerInGame == PhotonNetwork.playerList.Length) {
			print("All players are in the game scene.");
            PhotonView.RPC("RPC_CreatePlayer", PhotonTargets.All);
		}
	}

    [PunRPC]
    private void RPC_CreatePlayer()
    {
        GameObject[] spawnPoints = planet.GetComponent<PlanetCtrl>().spawnPoints;
        GameObject spawn = spawnPoints[PhotonNetwork.player.ID - 1];
        GameObject player = PhotonNetwork.Instantiate(Path.Combine("","Player"), spawn.transform.position, spawn.transform.rotation, 0);
    }
}
