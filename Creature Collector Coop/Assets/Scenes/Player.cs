using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
    private float speed = 5f;
    private List<Creature> creatures = new List<Creature>(6);
    private PlayerUISidePanel playerUISidePanel;
    private GameObject creaturePrefab;

    //private int credits;
    //private Item[] bag;

    void Start() {
        playerUISidePanel = GameObject.FindGameObjectWithTag("PlayerUISidePanel").GetComponent<PlayerUISidePanel>();
        creaturePrefab = Resources.Load<GameObject>("CreaturePrefab");
        
        if (creaturePrefab == null) {
            Debug.LogError("Failed to find CreaturePrefab in the scene.");
            return;
        }
        InitializeCreatures();
    }

    void Update() {
        Move();
        PlayerInterface();
        TestCreatureHandler();
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

    public  void InitializeCreatures() {
        // Example initialization, replace with your actual logic
        foreach (Transform child in transform) {
            Creature creature = child.GetComponent<Creature>();
            if (creature != null) {
                if (!creatures.Contains(creature)) { 
                    creatures.Add(creature);
                }
            }
        }
    }

    void PlayerInterface() {
        if (playerUISidePanel != null) {
            if (Input.GetKeyDown(KeyCode.Q)) {
                playerUISidePanel.gameObject.SetActive(!playerUISidePanel.gameObject.activeSelf);
            }
        } 
    }


    //NOT TESTED
    //NEED TO ADD CREATURE AND GameObject
    void AddCreature(Creature creature) {
        if (creatures.Count >= 6) {
            GameObject childObject = Instantiate(creaturePrefab);
            childObject.transform.SetParent(transform);
        }
    }

    void AddCreature() {
        if (creatures.Count < 6) {
            GameObject childObject = Instantiate(creaturePrefab, transform);
            Creature creatureComponent = childObject.GetComponent<Creature>();

            if (creatureComponent != null) {
                creatures.Add(creatureComponent);  // Add the creature to the list
            }
            else {
                Debug.LogError("The instantiated object does not have a Creature component.");
            }
        } else {
            Debug.Log("Maximum number of creatures reached.");
        }
    }

    void RemoveCreature() {
        if (creatures.Count > 1) {
            Creature creatureToRemove = creatures[0];
            string creatureNameToDelete = creatures[0].name;
            GameObject creatureToDelete = transform.Find(creatureNameToDelete).gameObject;
            creatures.RemoveAt(0);

            // Destroy the GameObject
            if (creatureToDelete != null) {
                Destroy(creatureToDelete);
                creatures.Remove(creatureToRemove);
            } else {
                Debug.LogError("Creature GameObject reference is null.");
            }
        } else {
            Debug.Log("Can't have 0 Creatures in party.");
        }
    }

    void TestCreatureHandler() {
        if (Input.GetKeyDown(KeyCode.E)) {
            //AddCreature(new Creature("TEST", 30, 90, 30, 30, false));
            AddCreature();
        }
        if (Input.GetKeyDown(KeyCode.R)) {
            RemoveCreature();
        }
    }

    public List<Creature> GetCreatures() { return creatures; }
}