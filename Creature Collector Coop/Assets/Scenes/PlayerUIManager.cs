using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PlayerUIManager : MonoBehaviour, IPointerClickHandler {
    private Player player;
    private PlayerUISidePanel sidePanel;

    // Start is called before the first frame update
    void Start() {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        sidePanel = GameObject.FindGameObjectWithTag("PlayerUISidePanel").GetComponent<PlayerUISidePanel>();
        sidePanel.gameObject.SetActive(!sidePanel.gameObject.activeSelf);
    }

    void Update() {
        UpdateButtonText();
    }

    public void OnPointerClick(PointerEventData eventData) {
        sidePanel.gameObject.SetActive(!sidePanel.gameObject.activeSelf);
        UpdateButtonText();
    }
    
    private void UpdateButtonText() {
        GameObject child = transform.GetChild(0).gameObject;
        if (child != null) {
            if (sidePanel.gameObject.activeSelf) {
                child.GetComponent<Text>().text = "<<";
            } else {
                child.GetComponent<Text>().text = ">>";
            
            }
        }
    }
}