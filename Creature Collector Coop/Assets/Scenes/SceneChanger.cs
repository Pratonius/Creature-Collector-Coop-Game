using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour {
    public string sceneName;
    public GameObject playerPrefab;
    public GameObject spawnPosition;

    private void OnEnable() {
        Debug.Log("Subscribing to sceneLoaded event");
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnDisable() {
        Debug.Log("Unsubscribing from sceneLoaded event");
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
    }
}
