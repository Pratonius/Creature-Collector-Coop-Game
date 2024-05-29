using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class SceneTransition : MonoBehaviour {
    public string sceneName;
    public static GameObject playerPrefab;
    public GameObject spawnPosition;

    void OnSceneLoaded(Scene scene, LoadSceneMode mode) {
        Debug.Log("Scene Loaded: " + scene.name);
        Debug.Log("Instantiating player...");
        GameObject newPlayer = Instantiate(playerPrefab);
        Debug.Log("Player instantiated: " + newPlayer.name);

        // Optionally, set its position, rotation, and scale as needed
        newPlayer.transform.position = playerPrefab.transform.position; // Example position
        newPlayer.transform.rotation = playerPrefab.transform.rotation;  // Example rotation

        // Optional: Disable the renderer if needed
        DisablePlayerInCombat(newPlayer, scene);
    }

    void Start() {
        Debug.Log("Start method called.");
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnDestroy() {
        Debug.Log("Destroy method called.");
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    public void TransitionToScene() {
        SceneManager.LoadScene(sceneName, LoadSceneMode.Single);
    }

    void DisablePlayerInCombat(GameObject newPlayer, Scene scene) {
        if (scene.name == "BattleScene" || scene.name == "MainMenu") {
            Renderer renderer = newPlayer.GetComponent<Renderer>();
            if (renderer != null) {
                renderer.enabled = false; // Disable the renderer if needed
            }
        }
    }
}
