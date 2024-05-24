using UnityEngine;

public class Creature : MonoBehaviour {
    private int maxHealth;
    private int currentHealth;
    private bool sex;
    //private CreatureType type;
    //private Move move1;

    public Creature(int maxHealth, bool sex) {
        this.maxHealth = maxHealth;
        this.currentHealth = maxHealth;
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
