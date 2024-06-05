using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
    private float speed = 5f;
    public List<Creature> creatures = new();
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
                grass.OnTriggerWithPlayer(this);
            }
        }
    }

    void OnTriggerExit2D(Collider2D other) {
        if (other.gameObject.CompareTag("Grass")) {
            Grass grass = other.gameObject.GetComponent<Grass>();
            if (grass != null) {
                grass.CanEncounter(true);
            }
        }
    }

    void OnEnable() {
        Renderer renderer = GetComponent<Renderer>();
        if (renderer != null) {
            renderer.enabled = true;
        }
    }

    public void InitializeCreatures() {
        foreach (Transform child in transform) {
            Creature creature = child.GetComponent<Creature>();
            if (creature != null && !creatures.Contains(creature)) {
                creatures.Add(creature);
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

    public void AddCreature(Creature creatureToAdd) {
        if (creatureToAdd != null) {
            Debug.LogError("creatureToAdd is null.");
            return;
        }
        if (creatures.Count < 6) {
            GameObject childObject = Instantiate(creaturePrefab, transform);
            if (childObject != null) {
                Creature creature = childObject.GetComponent<Creature>();
                if (creature != null) {
                    creature.CatchCreature(creatureToAdd);
                    CleanUpCreaturesList();
                    creatures.Add(creature);  // Add the creature to the list
                    Debug.Log("Creature added successfully.");
                } else {
                    Debug.LogError("The instantiated object does not have a Creature component.");
                }
            } else {
                Debug.LogError("Failed to instantiate creaturePrefab.");
            }
        } else {
            Debug.Log("Maximum number of creatures reached.");
        }
    }

    void RemoveCreature() {
        if (creatures[creatures.Count-1] == null) {
            creatures.RemoveAt(creatures.Count-1);
        }
        if (creatures.Count > 1) {
            Creature creatureToRemove = creatures[0];
            string creatureNameToDelete = creatureToRemove.name;
            
            // Find the creature GameObject under the current GameObject
            Transform creatureTransform = transform.Find(creatureNameToDelete);
            
            if (creatureTransform != null) {
                // Get the GameObject reference
                GameObject creatureToDelete = creatureTransform.gameObject;
                
                if (creatureToDelete != null && creatureToRemove != null) {
                    bool removed = creatures.Remove(creatureToRemove);
                    if (removed) {
                        Destroy(creatureToDelete); // Destroy the GameObject
                        CleanUpCreaturesList();
                    } else {
                        Debug.LogError("Creature was not found in the list.");
                    }
                } else {
                    Debug.LogError("Creature GameObject reference is null.");
                }
            } else {
                Debug.LogError("Creature GameObject not found under this GameObject.");
            }
        } else {
            Debug.Log("Can't have 0 Creatures in party.");
        }
    }



    void TestCreatureHandler() {
        if (Input.GetKeyDown(KeyCode.E)) {
            AddCreature(new Creature("TEST", 30, 90, 30, 30, 30, false, false));
        }
        if (Input.GetKeyDown(KeyCode.R)) {
            RemoveCreature();
        }
    }
    
    void CleanUpCreaturesList() {
        for (int i = 0; i < creatures.Count; i++) {
            if (creatures[i] == null) {
                 creatures.RemoveAt(i);
            }
        }
    }

    public List<Creature> GetCreatures() { return creatures; }

    public void SavePlayerData() {
        PlayerData playerData = new PlayerData();
        playerData.creatures = creatures;

        string json = JsonUtility.ToJson(playerData);
        PlayerPrefs.SetString("PlayerData", json);
        PlayerPrefs.Save();
        Debug.Log("Player data saved.");
    }

    public void LoadPlayerData() {
        if (PlayerPrefs.HasKey("PlayerData")) {
            string json = PlayerPrefs.GetString("PlayerData");
            PlayerData playerData = JsonUtility.FromJson<PlayerData>(json);

            if (playerData.creatures.Count > 0 && playerData.creatures[0] != null) {
                creatures = playerData.creatures;
                Debug.Log(playerData.creatures[0].name);
                Debug.Log("CREATURES: " + creatures.Count + "  ||   PLAYERDATA CREATURES: " + playerData.creatures.Count);
                Debug.Log("Player data loaded.");

                // Re-instantiate creatures
                foreach (Creature creature in creatures) {
                    GameObject childObject = Instantiate(creaturePrefab, transform);
                    Creature newCreature = childObject.GetComponent<Creature>();
                    newCreature.CopyCreatureStats(creature); // Make sure Creature has a CopyFrom method to copy the data
                }
            } else {
                ResetAllPlayerPrefs();
            }
        } else {
            Debug.Log("No player data found.");
        }
    }

    public void ResetAllPlayerPrefs() {
        PlayerPrefs.DeleteAll();
        PlayerPrefs.Save(); // Ensure the changes are saved immediately
        Debug.Log("All PlayerPrefs have been reset.");
    }
}

[System.Serializable]
public class PlayerData {
    public List<Creature> creatures;
}