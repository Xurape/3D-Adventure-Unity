using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArtifactController : MonoBehaviour
{
    public SceneLoaderController _sceneLoaderController;

    public void OnTriggerEnter(Collider other) {
        if(other.gameObject.CompareTag("Player")) {
            _sceneLoaderController.EndGame();
        }
    }
}
