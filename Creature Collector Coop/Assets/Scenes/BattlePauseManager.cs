using UnityEngine;

public class BattlePauseManager : MonoBehaviour {
    private Canvas pauseMenu;

    void Start() {
        pauseMenu = GameObject.FindGameObjectWithTag("MenuUI").GetComponent<Canvas>();
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
