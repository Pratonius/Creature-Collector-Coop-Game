using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Build.Player;
using UnityEngine;

public class Player : MonoBehaviour {
    private float speed = 5f;
    private List<Creature> creatures = new List<Creature>(6);
    private PlayerUIManager playerUI;

    //private int credits;
    //private Item[] bag;

    void Start() {
        playerUI = GameObject.FindGameObjectWithTag("PlayerUI").GetComponent<PlayerUIManager>();
        TestInitializeCreatures();
    }

    void Update() {
        Move();
        PlayerInterface();
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

    public  void TestInitializeCreatures() {
        // Example initialization, replace with your actual logic
        for (int i = 0; i < 6; i++) {
            creatures.Add(new Creature("Creature" + (i + 1), i+1, 100+(10*i), 10*3-i, 10, false));
            Debug.Log(creatures.Count);
        }
    }

    void PlayerInterface() {
        if (playerUI != null) {
            if (Input.GetKeyDown(KeyCode.Q)) {
                playerUI.gameObject.SetActive(!playerUI.gameObject.activeSelf);
            }
        } 
    }

    public List<Creature> GetCreatures() { return creatures; }
}