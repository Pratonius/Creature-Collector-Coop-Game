using System.Xml.Serialization;
using TMPro.Examples;
using UnityEngine;

public class FollowCameraManager : MonoBehaviour {
    private CameraController camera;
    // Start is called before the first frame update
    void Start() {
        camera = gameObject.GetComponent<CameraController>();
        //FollowPlayer();
    }

    // Update is called once per frame
    void Update() {
        
    }

    public void FollowPlayer() {
        if (camera != null) {
            Player player = FindAnyObjectByType<Player>();
            if (player != null) {
                camera.CameraTarget = player.transform;
            }
        } else {
            camera = gameObject.GetComponent<CameraController>();
            FollowPlayer();
        }
    }
}
