using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class SceneTransition : MonoBehaviour {
    public string sceneName;
    public GameObject playerPrefab;

     void OnSceneLoaded(Scene scene, LoadSceneMode mode) {
        Debug.Log("Scene Loaded: " + scene.name);
        Debug.Log("Instantiating player...");
        GameObject newPlayer = Instantiate(playerPrefab);
        Debug.Log("Player instantiated: " + newPlayer.name);

        // Optionally, set its position, rotation, and scale as needed
        newPlayer.transform.position = new Vector3(0, 0, 0); // Example position
        newPlayer.transform.rotation = Quaternion.identity; // Example rotation
        newPlayer.transform.localScale = Vector3.one; // Example scale

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
        Debug.Log("TEST");
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
