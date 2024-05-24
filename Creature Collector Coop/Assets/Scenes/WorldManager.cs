using UnityEngine;

public class WorldManager : MonoBehaviour {
    public Player player;
    public Canvas uiPanel;


    void Start(){
        if (uiPanel != null) {
            uiPanel.enabled = false;
        }
    }

    // Update is called once per frame
    void Update() {
    }

    public void ResumeGame() {
        if (uiPanel != null) {
            uiPanel.enabled = !uiPanel.enabled;
            enabled = !enabled;
            player.enabled = !player.enabled;
        }
    }
}
