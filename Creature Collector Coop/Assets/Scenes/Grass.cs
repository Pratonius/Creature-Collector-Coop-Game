using UnityEngine;
using System.Collections.Generic;
using System;

public class Grass : MonoBehaviour {
    private List<Creature> creaturesInGrass = new List<Creature>();
    private SceneChanger sceneChanger;

    public bool canEncounter {get; private set;}

    void Start() {
        creaturesInGrass.Add(GenerateCreature("Wukong"));
        creaturesInGrass.Add(GenerateCreature("Oni"));
        creaturesInGrass.Add(GenerateCreature("Dokaebi"));
        creaturesInGrass.Add(GenerateCreature("Phoenix"));
        sceneChanger = FindObjectOfType<SceneChanger>();
        canEncounter = true;
    }

    public void CanEncounter(bool canEncounter) {
        this.canEncounter = canEncounter;
    }

    public void OnTriggerWithPlayer(Player player) {
        System.Random random = new();
        int rng = random.Next(1, 11);
        Debug.Log("RNG: " + rng);
        if (rng != 10) {
            canEncounter = false;
        } else {
            if (sceneChanger != null) {
                Debug.Log("A wild Creature has appeared!");
                sceneChanger.sceneName = "BattleScene";
                sceneChanger.TransitionToScene();
            }
        }
    }

    public void CreatureCaught(Player player) {
        if (player != null) {
            System.Random random = new();
            int level = random.Next(1, 100);
            int maxHealth = random.Next(52, 312);
            int attack = random.Next(25, 75);
            int defense = random.Next(25, 75);
            int speed = random.Next(25, 75);
            string[] names = {"Agron", "Felix", "Monique", "Malinka", "Sadish", "Lalando"};
            int name = random.Next(0, 5);
            player.AddCreature(new Creature(names[name], level, maxHealth, attack, defense, speed, true, true));
        }
    }
    
    Creature GenerateCreature(string name) {
        System.Random random = new();
        int level = random.Next(1, 8);
        int maxHealth = random.Next(20, 40);
        int attack = random.Next(15, 20);
        int defense = random.Next(10, 30);
        int speed = random.Next(5, 15);
        return new Creature(name, level, maxHealth, attack, defense, speed, true, true);
    }
}
