using UnityEngine;
using UnityEngine.EventSystems;

public class MenuButton : MonoBehaviour, IPointerClickHandler {
    public string sceneName;
    private SceneChanger sceneChanger;
    
    void Start() {
        sceneChanger = FindObjectOfType<SceneChanger>();
    }

    public void OnPointerClick(PointerEventData eventData) {
        if (sceneChanger != null) {
            sceneChanger.sceneName = sceneName;
            sceneChanger.TransitionToScene();
        }
    }
}
