using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class ResumeGame : MonoBehaviour, IPointerClickHandler {
    private GameObject game;
    
    void Start() {
        game = FindObjectOfType<WorldManager>().GameObject();
        if (game == null) {
            game = FindObjectOfType<BattlePauseManager>().GameObject();
        }
    }

    void Update() {
        if (Input.GetKeyDown(KeyCode.Escape)) {
            PauseOrUnpauseWorld();
        }
    }

    public void OnPointerClick(PointerEventData eventData) {
        PauseOrUnpauseWorld();
    }

    void PauseOrUnpauseWorld() {
        if (game != null) {
            WorldManager world = game.GetComponent<WorldManager>();
            if (world != null) {
                world.PauseOrUnpause();
            } else {
                BattlePauseManager pauseManager = game.GetComponent<BattlePauseManager>();
                if (pauseManager != null) {
                    pauseManager.PauseOrUnpause();
                }
            }
        }
    }
}
