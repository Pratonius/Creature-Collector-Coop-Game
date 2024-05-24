using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class SceneTransition : MonoBehaviour, IPointerClickHandler {
    public string sceneName;
    public GameObject playerPrefab;
    
    public void StartBattle() {
        SceneManager.LoadScene("BattleScene");
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode) {
        if (scene.name == sceneName) {
            // Instantiate a new player GameObject from the prefab
            GameObject newPlayer = Instantiate(playerPrefab);

            // Optionally, you can set its position, rotation, and scale as needed
            // For example:
            // newPlayer.transform.position = new Vector3(0, 0, 0); // Set position to (0, 0, 0)
            // newPlayer.transform.rotation = Quaternion.identity; // Set rotation to identity
            // newPlayer.transform.localScale = Vector3.one; // Set scale to (1, 1, 1)

            // Disable the renderer of the new player GameObject if needed
            Renderer renderer = newPlayer.GetComponent<Renderer>();
            if (renderer != null) {
                renderer.enabled = false;
            }
        }
    }
    
    void Start() {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnDestroy() {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    public void TransitionToScene() {
        // Load the new scene
        SceneManager.LoadScene(sceneName, LoadSceneMode.Single);
    }

    public void OnPointerClick(PointerEventData eventData) {
        TransitionToScene();
    }
}