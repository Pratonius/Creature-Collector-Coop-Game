using UnityEngine;

public class Creature{
    public string name;
    public int level;
    public bool sex;
    public int maxHealth;
    public int currentHealth;
    public int attack;
    public int defense;
    //private CreatureType type;
    //private Move move1;

    public Creature(string name, int level, int maxHealth, int attack, int defense, bool sex) {
        this.name = name;
        this.level = level;
        this.maxHealth = maxHealth;
        currentHealth = maxHealth;
        this.attack = attack;
        this.defense = defense;
        this.sex = sex;
    }

    // Start is called before the first frame update
    void Start() {
        
    }

    // Update is called once per frame
    void Update() {
        
    }

    public string GetName() { return name; }
    public int GetMaxHealth() { return maxHealth; }
    public int GetCurrentHealth() { return currentHealth; }
    public bool GetSex() { return sex; }
}
