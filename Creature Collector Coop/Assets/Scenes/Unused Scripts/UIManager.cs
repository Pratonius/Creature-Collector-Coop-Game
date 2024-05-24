using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UIManager : MonoBehaviour, IPointerClickHandler {
    
    public TicTacToeManager ticTacToeManager;

    public Canvas uiPanel;
    public TextMeshProUGUI text;
    bool CanContinue;

    // Start is called before the first frame update
    void Start() {
        if (uiPanel != null) {
            CanContinue = true;
            uiPanel.enabled = false;
            if (text != null) {
                text.enabled = false;
            }
        }
    }

    // Update is called once per frame
    void Update() {
        if (ticTacToeManager.IsGameOver()) {
            gameObject.SetActive(false);
            text.enabled = true;
            if (ticTacToeManager.GameHasBeenWon()) {
                text.text = $"Game Over! \nPlayer {ticTacToeManager.GetCurrentPlayer()} Wins";
            } else {
                text.text = $"Game Over! \nDraw Nobody Wins";
            }
            uiPanel.enabled = true;
            CanContinue = false;
        }
        if (Input.GetKeyDown(KeyCode.Escape)){
            ResumeGame();
        }
    }

    public void OnPointerClick(PointerEventData eventData) {
        ResumeGame();
    }

    void ResumeGame() {
        if (uiPanel != null && CanContinue) {
            uiPanel.enabled = !uiPanel.enabled;
            ticTacToeManager.enabled = !ticTacToeManager.enabled;
        }
    }
}
