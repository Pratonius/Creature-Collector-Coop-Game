using UnityEngine;
using UnityEngine.EventSystems;

public class NewBehaviourScript : MonoBehaviour , IPointerClickHandler {
    // Start is called before the first frame update
    void Start(){}

    // Update is called once per frame
    void Update(){}

    public void OnPointerClick(PointerEventData eventData) {
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #else
            Application.Quit();
        #endif
    }
}
