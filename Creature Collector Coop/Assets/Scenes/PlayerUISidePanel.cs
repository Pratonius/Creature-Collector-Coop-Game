using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerUISidePanel : MonoBehaviour {
    private Player player;
    private List<Text> names = new List<Text>(6);

    // Start is called before the first frame update
    void Start() {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        PopulateNamesList();
        SetSidePanel();
    }

    void Update() {
        UpdateSidePanel();
    }

    void PopulateNamesList() {
        foreach (Transform child in transform) {
            Text textComponent = child.GetComponent<Text>();
            if (textComponent != null) {
                names.Add(textComponent);
            }
        }
    }

    void SetSidePanel() {
        List<Creature> playerCreatures = player.GetCreatures();
        for (int i = 0; i < playerCreatures.Count; i++) {
            names[i].text = $"{i+1}: {playerCreatures[i].name}\nLVL: {playerCreatures[i].level}\nHP: {playerCreatures[i].currentHealth}/{playerCreatures[i].maxHealth}";
        }
    }

    void UpdateSidePanel() {
        player.InitializeCreatures();
        SetSidePanel();
    }
}
