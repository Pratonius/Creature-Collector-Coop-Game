using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Player : MonoBehaviour {
    private float speed = 5f;
    public List<Creature> creatures = new List<Creature>();
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
        if (creatures.Count < 6) {
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
        Debug.Log("Before Creatures: " + creatures.Count);
        int amountOfObjects = 0;
        List<GameObject> creatureObjects = new List<GameObject>();
        foreach (Transform child in transform) {
            if (child.GetComponent<Creature>()) {
                creatureObjects.Add(child.gameObject);
                amountOfObjects++;
            }
        }

        if (creatures.Count > 1 && creatureObjects.Count > 1) {
            Creature creatureToRemove = creatures[0];
            string creatureNameToDelete = creatureToRemove.name;
            GameObject creatureToDelete = transform.Find(creatureNameToDelete).gameObject;

            // Destroy the GameObject
            if (creatureToDelete != null && creatureToRemove != null) {
                Debug.Log("Object: " + amountOfObjects);
                Debug.Log("Creatures: " + creatures.Count);
                bool removed = creatures.Remove(creatureToRemove);
                if (removed) {
                    Destroy(creatureToDelete); // Destroy the GameObject
                    AdjustCreatureIndices(); // Adjust the indices of remaining creatures
                } else {
                    Debug.LogError("Creature was not found in the list.");
                }
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

    void AdjustCreatureIndices() {
    for (int i = 1; i < creatures.Count; i++) {
        if (creatures[i] != null && creatures[i-1] == null) {
            creatures[i-1] = creatures[i];
            creatures.RemoveAt(i);
        }
    }
}

    public List<Creature> GetCreatures() { return creatures; }
}