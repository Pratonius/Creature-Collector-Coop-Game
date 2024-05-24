using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour, IPointerClickHandler {
    public string sceneName;
    void Start() {}

    void Update() {}

    public void OnPointerClick(PointerEventData eventData) {
        ChangeToScene();
    }

    public void ChangeToScene() {
        SceneManager.LoadScene(sceneName);
    }
}
