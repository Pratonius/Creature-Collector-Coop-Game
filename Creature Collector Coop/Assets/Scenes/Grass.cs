using UnityEngine;
using System;

public class Grass : MonoBehaviour {
    private SceneChanger sceneChanger;

    void Start() {
        sceneChanger = FindObjectOfType<SceneChanger>();
    }

    void Update() {
    }

    public void OnTriggerWithPlayer(Player player) {
        if (sceneChanger != null) {
            Debug.Log("A wild Creature has appeared!");
            sceneChanger.sceneName = "BattleScene";
            sceneChanger.TransitionToScene();
        }
        //CreatureCaught(player);
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
}
