using UnityEngine;

public class BattlePauseManager : MonoBehaviour {
    public Canvas pauseMenu;

    void Start() {
        if (pauseMenu != null) {
            pauseMenu.enabled = false;
        }
    }

    void Update() {
        InputPauseOrUnpause();
    }

    public void InputPauseOrUnpause() {
        if (Input.GetKeyDown(KeyCode.Escape)) {
            PauseOrUnpause();
        }
    }

    public void PauseOrUnpause() {
        if (pauseMenu != null) {
            pauseMenu.enabled = !pauseMenu.enabled;
            enabled = !enabled;
        }
    }
}
