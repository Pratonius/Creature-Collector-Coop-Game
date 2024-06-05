using UnityEngine;

public class WorldManager : MonoBehaviour {
    private Player player;
    private Canvas pauseMenu;


    void Start(){
        player = FindObjectOfType<Player>();
        pauseMenu = GameObject.FindGameObjectWithTag("MenuUI").GetComponent<Canvas>();
        if (player != null && pauseMenu != null) {
            player.enabled = true;
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
            player.enabled = !player.enabled;
        }
    }
}
