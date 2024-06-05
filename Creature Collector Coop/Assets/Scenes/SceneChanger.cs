using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour {
    public string sceneName;
    public GameObject playerPrefab;
    public GameObject spawnPosition;
    private FollowCameraManager camera;

    void Start() {
        SceneManager.sceneLoaded += OnSceneLoaded;
        //LoadPlayerPrefab();
    }

    void OnDestroy() {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    public void TransitionToScene() {
        Player player = FindObjectOfType<Player>();
        if (player != null) {
            player.SavePlayerData();
        }
        SceneManager.LoadScene(sceneName);
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode) {
        Player player = FindObjectOfType<Player>();
        Debug.Log("ONSCENELOADED");
        if (player != null) {
            Debug.Log("TEST PLAYER EXISTS");
            if (scene.name == "MainWorldScene") {
                if (player != null) {
                    player.LoadPlayerData();
                    if (spawnPosition != null) {
                        player.transform.position = spawnPosition.transform.position;
                    }
                } else {
                    camera = FindAnyObjectByType<FollowCameraManager>();
                    Instantiate(playerPrefab, spawnPosition.transform.position, Quaternion.identity);
                    if (camera != null) {
                        camera.FollowPlayer();
                    }
                }
            }
            if (scene.name == "MainMenu") {
                Debug.Log("DESTROY PLAYER");
                Destroy(player);
            }
        }



        /*
        PlayerManager playerManager = FindObjectOfType<PlayerManager>();
        if (playerManager != null) {
            GameObject player = playerManager.gameObject;
            if (spawnPosition != null) {
                player.transform.position = spawnPosition.transform.position;
            }
        } else {
            if (spawnPosition != null && playerPrefab != null) {
                Instantiate(playerPrefab, spawnPosition.transform.position, spawnPosition.transform.rotation);
            }
        }
        */
    }

    void LoadPlayerPrefab() {
        playerPrefab = Resources.Load<GameObject>("Player");
        if (playerPrefab == null) {
            Debug.LogError("Player prefab not found in Resources folder. Please check the prefab name and ensure it is placed in the Resources folder.");
        }
    }
}
