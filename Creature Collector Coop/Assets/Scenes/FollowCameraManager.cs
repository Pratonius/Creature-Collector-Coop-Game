using TMPro.Examples;
using UnityEngine;

public class FollowCameraManager : MonoBehaviour {
    private new CameraController camera;

    // Start is called before the first frame update
    void Start() {
        camera = gameObject.GetComponent<CameraController>();
        FollowPlayer();
    }

    void FollowPlayer() {
        if (camera == null) {
            Debug.LogError("CameraController component is missing!");
            return;
        }

        Player player = FindObjectOfType<Player>();
        if (player != null) {
            camera.CameraTarget = player.transform;
            Debug.Log("Camera is now following the player.");
        } else {
            Debug.LogWarning("Player not found in the scene.");
        }
    }
}
