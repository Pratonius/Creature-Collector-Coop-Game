using UnityEngine;

public class Grass : MonoBehaviour {
    public SceneTransition sceneTransition;
    // Start is called before the first frame update
    void Start() {
        
    }

    // Update is called once per frame
    void Update() {
        
    }

    public void OnTriggerWithPlayer() {
        // Your custom method to run on trigger
        if (sceneTransition != null) {
            Debug.Log("A wild Creature has appeared!");
            sceneTransition.sceneName = "BattleScene";
            sceneTransition.TransitionToScene();
        }
    }
}
