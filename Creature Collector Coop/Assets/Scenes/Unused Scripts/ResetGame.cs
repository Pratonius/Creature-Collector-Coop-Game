using UnityEngine.EventSystems;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ResetGame : MonoBehaviour, IPointerClickHandler {

    // Start is called before the first frame update
    void Start() {}

    // Update is called once per frame
    void Update() {}

    public void OnPointerClick(PointerEventData eventData) {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
