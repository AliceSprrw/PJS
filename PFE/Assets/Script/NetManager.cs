using Photon.Pun;
using Photon.Realtime;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NetManager : MonoBehaviourPunCallbacks
{

    public Transform spawnPointArtiste;
    public Transform spawnPointSpectateur;
    public GameObject playerPrefabArtiste;
    public GameObject playerPrefabSpectateur;

    void Start()
    {
        Debug.Log("ConnectAndJoinRandom.ConnectNow() will now call: PhotonNetwork.ConnectUsingSettings().");
        PhotonNetwork.ConnectUsingSettings();
        PhotonNetwork.GameVersion = "1." + SceneManagerHelper.ActiveSceneBuildIndex;
        
    }

    public override void OnConnectedToMaster()
    {
        Debug.Log("OnConnectedToMaster() was called by PUN. Now this client is connected and could join a room. Calling: PhotonNetwork.JoinRandomRoom();");
        PhotonNetwork.JoinRandomRoom();
    }

    public override void OnJoinedLobby()
    {
        Debug.Log("OnJoinedLobby(). This client is connected. This script now calls: PhotonNetwork.JoinRandomRoom();");
        PhotonNetwork.JoinRandomRoom();
    }

    public override void OnJoinRandomFailed(short returnCode, string message)
    {
        Debug.Log("OnJoinRandomFailed() was called by PUN. No random room available, so we create one. Calling: PhotonNetwork.CreateRoom(null, new RoomOptions() {maxPlayers = 4}, null);");
        PhotonNetwork.CreateRoom(null, new RoomOptions() { MaxPlayers = 4 }, null);
    }

    // the following methods are implemented to give you some context. re-implement them as needed.
    public override void OnDisconnected(DisconnectCause cause)
    {
        Debug.Log("OnDisconnected("+cause+")");
    }

    public override void OnJoinedRoom()
    {

        
        Debug.Log("OnJoinedRoom() called by PUN. Now this client is in a room. From here on, your game would be running.");

        // Si il s'agit d'un spectateur qui entre dans la scène
        if(StaticClass.CrossSceneInformation == "spectateur"){
            PhotonNetwork.Instantiate(playerPrefabSpectateur.name, spawnPointSpectateur.position, Quaternion.identity, 0);
        }
        else if(StaticClass.CrossSceneInformation == "artiste"){
            PhotonNetwork.Instantiate(playerPrefabArtiste.name, spawnPointArtiste.position, Quaternion.identity, 0);
        }
    }
}
