using UnityEngine;

public class Creature : MonoBehaviour {
    public string name;
    public int level;
    public bool sex;
    public int maxHealth;
    public int currentHealth;
    public int attack;
    public int defense;
    public bool isCaught;
    private SpriteRenderer spriteRenderer;
    //private CreatureType type;
    //private Move move1;

    public Creature(string name, int level, int maxHealth, int attack, int defense, bool sex, bool isCaught) {
        this.name = name;
        this.level = level;
        this.maxHealth = maxHealth;
        currentHealth = maxHealth;
        this.attack = attack;
        this.defense = defense;
        this.sex = sex;
        this.isCaught = isCaught;
    }

    // Start is called before the first frame update
    void Start() {
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        spriteRenderer.enabled = false;
    }

    // Update is called once per frame
    void Update() {
        
    }

    public string GetName() { return name; }
    public int GetMaxHealth() { return maxHealth; }
    public int GetCurrentHealth() { return currentHealth; }
    public bool GetSex() { return sex; }
    public void EnableSprite() {
        if (spriteRenderer.sprite != null) {
            spriteRenderer.enabled = true;
        }
    }

    public void DisableSprite() {
        if (spriteRenderer.sprite != null) {
            spriteRenderer.enabled = false;
        }
    }

    public void CopyCreatureStats(Creature creature) {
        name = creature.name;
        gameObject.name = creature.name;
        level = creature.level;
        maxHealth = creature.maxHealth;
        currentHealth = creature.maxHealth;
        attack = creature.attack;
        defense = creature.defense;
        sex = creature.sex;
        isCaught = creature.isCaught;
    }

    public void CatchCreature(Creature creature) {
        CopyCreatureStats(creature);
        isCaught = true;
    }
}
