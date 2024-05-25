using UnityEngine;
using UnityEngine.EventSystems;

public class ResumeGame : MonoBehaviour, IPointerClickHandler {
    public WorldManager world;
    // Start is called before the first frame update
    void Start() {
        
    }

    // Update is called once per frame
    void Update() {
        if (Input.GetKeyDown(KeyCode.Escape)) {
            PauseOrUnpauseWorld();
        }
    }

    public void OnPointerClick(PointerEventData eventData) {
        PauseOrUnpauseWorld();
    }

    void PauseOrUnpauseWorld() {
        if (world != null) {
                world.PauseOrUnpause();
            }
    }
}
