using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerUIManager : MonoBehaviour {
    private Player player;
    private List<Text> names = new List<Text>(6);

    // Start is called before the first frame update
    void Start() {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        PopulateNamesList();
        SetSidePanel();
    }

    void PopulateNamesList() {
        foreach (Transform child in transform) {
            Text textComponent = child.GetComponent<Text>();
            if (textComponent != null) {
                names.Add(textComponent);
            }
            Debug.Log("TEXT ADDED, SUM OF " + names.Count);
        }
    }

    void SetSidePanel() {
        List<Creature> playerCreatures = player.GetCreatures();
        for (int i = 0; i < playerCreatures.Count; i++) {
            Debug.Log("Creature: " + playerCreatures[i].name);
            names[i].text = $"{i+1}: {playerCreatures[i].name}\nLVL: {playerCreatures[i].level}\nHP: {playerCreatures[1].currentHealth}/{playerCreatures[1].maxHealth}";
        }
    }
}
