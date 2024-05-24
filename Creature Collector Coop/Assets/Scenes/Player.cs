using UnityEngine;

public class Player : MonoBehaviour {
    private float speed = 5f;
    private Creature[] creatures;
    private int credits;
    //private Item[] bag;

    void Start() {
        credits = 0;
        creatures = new Creature[6];
    }

    void Update() {
        Move();
    }

    //void Awake() { DontDestroyOnLoad(gameObject); }

    void Move() {
        if (enabled) {
            float moveHorizontal = Input.GetAxis("Horizontal");
            float moveVertical = Input.GetAxis("Vertical");

            Vector2 movement = new Vector2(moveHorizontal, moveVertical);
            transform.Translate(movement * speed * Time.deltaTime);
        }
    }
    
    void OnTriggerEnter2D(Collider2D other) {
        // Check what the player has triggered
        if (other.gameObject.CompareTag("Grass")) {
            Grass grass = other.gameObject.GetComponent<Grass>();
            if (grass != null) {
                grass.OnTriggerWithPlayer();
            }
        }
    }

    void OnEnable() {
        Renderer renderer = GetComponent<Renderer>();
        if (renderer != null) {
            renderer.enabled = true;
        }
    }
}