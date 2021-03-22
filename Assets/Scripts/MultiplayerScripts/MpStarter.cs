using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Mirror;

namespace Scripts.MultiplayerScripts {

    public class MpStarter : MonoBehaviour {

        public NetworkManager networkManager;
        public kcp2k.KcpTransport transport;
        public GameObject connectionTimedOutScreen;

        void Start() {
            StartNetwork();
        }

        void update() {
            if (MpLoadingValues.timedOut) {
                connectionTimedOutScreen.SetActive(true);
                MpLoadingValues.timedOut = false;
            }
        }

        public void StartNetwork() {
            Debug.Log(MpLoadingValues.ConnectionType);
            if (MpLoadingValues.ConnectionType == 0) {
                networkManager.StartClient();
                networkManager.networkAddress = MpLoadingValues.Address;
                transport.Port = (ushort) MpLoadingValues.Port;
                Debug.Log("Connection started!");
                return;
            } else {
                if (Application.platform != RuntimePlatform.WebGLPlayer) {
                    networkManager.StartHost();
                    Debug.Log("Local game Started!");
                }
            }
        }

        public void StopNetwork() {
            networkManager.StopAllCoroutines();
            SceneManager.LoadScene(2);
        }
    }
}