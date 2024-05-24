using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ResumeGame : MonoBehaviour, IPointerClickHandler {
    public WorldManager world;
    // Start is called before the first frame update
    void Start() {
        
    }

    // Update is called once per frame
    void Update() {
        if (Input.GetKeyDown(KeyCode.Escape)){
            world.ResumeGame();
        }
    }

    public void OnPointerClick(PointerEventData eventData) {
        world.ResumeGame();
    }
}
