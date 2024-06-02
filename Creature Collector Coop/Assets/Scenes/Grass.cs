using UnityEngine;
using System;

public class Grass : MonoBehaviour {
    public SceneTransition sceneTransition;
    // Start is called before the first frame update
    void Start() {
        
    }

    // Update is called once per frame
    void Update() {
        
    }

    public void OnTriggerWithPlayer(Player player) {
        // Your custom method to run on trigger
        /*
        if (sceneTransition != null) {
            Debug.Log("A wild Creature has appeared!");
            sceneTransition.sceneName = "BattleScene";
            sceneTransition.TransitionToScene();
        }
        */
        CreatureCaught(player);
    }

    public void CreatureCaught(Player player) {
        if (player != null) {
            System.Random random = new();
            int randomNumber = random.Next();
            int level = random.Next(1, 100);
            int maxHealth = random.Next(52, 312);
            int attack = random.Next(25, 75);
            int defense = random.Next(25, 75);
            string[] names = {"Agron", "Felix", "Monique", "Malinka", "Sadish", "Lalando"};
            int name = random.Next(0, 5);
            player.AddCreature(new Creature(names[name], level, maxHealth, attack, defense, true, true));
        }
    }
}
