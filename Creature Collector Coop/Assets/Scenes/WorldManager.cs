using UnityEngine;

public class WorldManager : MonoBehaviour {
    public Player player;
    public Canvas pauseMenu;


    void Start(){
        if (player != null) {
            player.enabled = true;
        }
        if (pauseMenu != null) {
            pauseMenu.enabled = false;
        }
    }

    // Update is called once per frame
    void Update() {
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
