using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerManager : MonoBehaviour {
    private static PlayerManager instance;
    private GameObject playerPrefab; 
    public GameObject spawnPosition;
    private GameObject playerInstance;

    private void Awake() {
        if (instance == null) {
            instance = this;
            LoadPlayerPrefab();
            DontDestroyOnLoad(gameObject);
            SceneManager.sceneLoaded += OnSceneLoaded;
        } else {
            Destroy(gameObject);
        }
    }

    private void OnDestroy() {
        if (instance == this) {
            SceneManager.sceneLoaded -= OnSceneLoaded;
        }
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode) {
        if (scene.name == "MainMenu") {
            DestroyPlayer();
        } else {
            switch (scene.name) {
                case "MainWorldScene": {
                    SpawnPlayer(false);
                    break;
                }
                case "BattleScene": {
                    SpawnPlayer(true);
                    break;
                }
            }
        }
    }

    private void SpawnPlayer(bool disablePlayerVisual) {
        if (playerInstance == null) {
            playerInstance = Instantiate(playerPrefab);
            Player player = FindObjectOfType<Player>();
            if (player != null) {
                player.LoadPlayerData();
                if (spawnPosition != null) {
                    player.transform.position = spawnPosition.transform.position;
                }
            } else {
                Instantiate(playerPrefab, spawnPosition.transform.position, Quaternion.identity);
                player = FindObjectOfType<Player>();
                if (player != null) {
                    player.LoadPlayerData();
                }
            }
            if (disablePlayerVisual) {
                player.gameObject.GetComponent<SpriteRenderer>().enabled = false;
            }
        }
    }

    private void DestroyPlayer() {
        if (playerInstance != null) {
            Destroy(playerInstance);
            playerInstance = null;
        }
    }

    void LoadPlayerPrefab() {
        if (playerPrefab == null) {
            playerPrefab = Resources.Load<GameObject>("Player");
            if (playerPrefab == null) {
                Debug.LogError("Player prefab not found in Resources folder. Please check the prefab name and ensure it is placed in the Resources folder.");
            }
        }
    }
}
