using System.ComponentModel.Design;
using UnityEngine;
using UnityEngine.EventSystems;

public class HighlightOnHover : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler {
    public GameObject objectToHighlight;
    private SpriteRenderer spriteRenderer;
    private Color originalColor;
    public Color highlightColor = Color.yellow;
    public TicTacToeManager ticTacToeManager;
    public AIManager aiManager;

    public int row;
    public int column;

    public Player player;

    public Sprite xSprite; // Reference to the X sprite
    public Sprite oSprite; // Reference to the O sprite

    void Start() {
        player = Player.EMPTY;
        if (objectToHighlight != null) {
            spriteRenderer = objectToHighlight.GetComponent<SpriteRenderer>();
            if (spriteRenderer != null) {
                originalColor = spriteRenderer.color;
            }
        }
    }

    void Update() {
    }

    public void OnPointerEnter(PointerEventData eventData) {
        if (spriteRenderer != null && ticTacToeManager.enabled && player == Player.EMPTY) {
            spriteRenderer.color = highlightColor;
        }
    }

    public void OnPointerExit(PointerEventData eventData) {
        if (spriteRenderer != null && ticTacToeManager.enabled && player == Player.EMPTY) {
            spriteRenderer.color = originalColor;
        }
    }

    public void OnPointerClick(PointerEventData eventData) {
        if (player == Player.EMPTY && ticTacToeManager != null && ticTacToeManager.enabled) {
            bool moveWorked = ticTacToeManager.PlayerMove(row, column);
            if (moveWorked && spriteRenderer != null) {
                player = ticTacToeManager.GetCurrentPlayer();
                CheckIfOccupiedAndNotAssigned();
                //if (player == Player.X && xSprite != null) {
                //    SetSprite(xSprite);
                //} else if (player == Player.O && oSprite != null) {
                //    SetSprite(oSprite);
                //}
                ticTacToeManager.SwitchPlayer();
            }
        }
    }

    public void SetSprite(Sprite newSprite) {
        if (newSprite != null) {
            gameObject.GetComponent<SpriteRenderer>().sprite = newSprite;

            // Adjust the scale if needed
            Vector2 originalSize = spriteRenderer.sprite.bounds.size;
            Vector2 newSize = newSprite.bounds.size;
            Vector3 scale = transform.localScale;
            scale.x *= originalSize.x / newSize.x;
            scale.y *= originalSize.y / newSize.y;
            transform.localScale = scale;
        }
    }
    void CheckIfOccupiedAndNotAssigned() {
        if (player != Player.EMPTY) {
            if (xSprite != null && oSprite != null) {
                if (player == Player.X) {
                    SetSprite(xSprite);
                } else if (player == Player.O) {
                    SetSprite(oSprite);
                }
            }
         }
    }
}
