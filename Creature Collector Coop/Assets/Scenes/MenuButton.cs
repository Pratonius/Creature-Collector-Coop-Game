using UnityEngine;
using UnityEngine.EventSystems;

public class MenuButton : MonoBehaviour, IPointerClickHandler {
    public string sceneName;
    public SceneTransition sceneTransition;
    // Start is called before the first frame update
    void Start() {
        
    }

    // Update is called once per frame
    void Update() {
        
    }

    public void OnPointerClick(PointerEventData eventData) {
        // Your custom method to run on trigger
        if (sceneTransition != null) {
            sceneTransition.sceneName = sceneName;
            sceneTransition.TransitionToScene();
        }
    }
}
