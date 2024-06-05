using UnityEngine;

[System.Serializable]
public class Creature : MonoBehaviour {
    public new string name;
    public int level;
    public bool sex;
    public int maxHealth;
    public int currentHealth;
    public int attack;
    public int defense;
    public int speed;
    public bool isCaught;
    private SpriteRenderer spriteRenderer;
    //private CreatureType type1;
    //private CreatureType type2;
    //private int evasion;
    //private Move move1;
    //private Move move2;
    //private Move move3;
    //private Move move4;
    //private Ability ability;

    public Creature(string name, int level, int maxHealth, int attack, int defense, int speed, bool sex, bool isCaught) {
        this.name = name;
        this.level = level;
        this.maxHealth = maxHealth;
        currentHealth = maxHealth;
        this.attack = attack;
        this.defense = defense;
        this.speed = speed;
        this.sex = sex;
        this.isCaught = isCaught;
    }

    void Start() {
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        spriteRenderer.enabled = false;
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
        speed = creature.speed;
        sex = creature.sex;
        isCaught = creature.isCaught;
    }

    public void CatchCreature(Creature creature) {
        CopyCreatureStats(creature);
        isCaught = true;
    }
}
