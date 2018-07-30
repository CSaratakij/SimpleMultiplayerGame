using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class DisableCamera : NetworkBehaviour {

    [SerializeField]
    GameObject[] cam;

	void Start() {
        if (!isLocalPlayer) {
            foreach (GameObject obj in cam) {
                obj.SetActive(false);
            }
        }
	}
}
