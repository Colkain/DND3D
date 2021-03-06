﻿using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class Buff {
    [SerializeField] private int id;
    [SerializeField] private string name;
    [SerializeField] private string description;
    [SerializeField] private int duration;
    [SerializeField] private Sprite icon;
    [SerializeField] private int[] effects;
    public Buff (int i, int l, int d, Sprite ic) {
        effects = new int[12]; //0:mouvement 1:maxHealth 2:health 3:strength 4:agility 5:intelligence 6:wisdom 7:damage 8:range 9:immune 10:action 11:whenEntering 12:exploring 13:vampire 14:leech 15:investigator
        id = i;
        effects[id] = l;
        duration = d;
        icon = ic;
        if (i == 0) {
            name = "Movement";
            description = "+" + effects[id] + " Movement.";
        } else if (i == 1) {
            name = "Max Health";
            description = "+" + effects[id] + " Max Health.";
        } else if (i == 2) {
            name = "Heal";
            description = "+" + effects[id] + " Health.";
        } else if (i == 3) {
            name = "Strength";
            description = "+" + effects[id] + " Strength.";
        } else if (i == 4) {
            name = "Agility";
            description = "+" + effects[id] + " Agility.";
        } else if (i == 5) {
            name = "Intelligence";
            description = "+" + effects[id] + " Intelligence.";
        } else if (i == 6) {
            name = "Wisdom";
            description = "+" + effects[id] + " Wisdom.";
        } else if (i == 7) {
            name = "Bonus Damage";
            description = "+" + effects[id] + " Bonus Damage.";
        } else if (i == 8) {
            name = "Range";
            description = "+" + effects[id] + " Range.";
        } else if (i == 9) {
            name = "Immune";
            description = "Prevent damage for " + effects[id] + " turns.";
        } else if (i == 10) {
            name = "Bonus Action";
            description = "+" + effects[id] + " Bonus Action.";
        }
        description += "\nDuration:" + duration;
    }
    public int GetEffect (int i) => effects[i];
    public int GetId () => id;
    public string GetName () => name;
    public string GetDescription () => description;
    public void SetDescription () {
        if (id == 0) {
            description = "+" + effects[id] + " Movement.";
        } else if (id == 1) {
            description = "+" + effects[id] + " Max Health.";
        } else if (id == 2) {
            description = "+" + effects[id] + " Health.";
        } else if (id == 3) {
            description = "+" + effects[id] + " Strength.";
        } else if (id == 4) {
            description = "+" + effects[id] + " Agility.";
        } else if (id == 5) {
            description = "+" + effects[id] + " Intelligence.";
        } else if (id == 6) {
            description = "+" + effects[id] + " Wisdom.";
        } else if (id == 7) {
            description = "+" + effects[id] + " Bonus Damage.";
        } else if (id == 8) {
            description = "+" + effects[id] + " Range.";
        } else if (id == 9) {
            description = "Prevent damage for " + effects[id] + " turns.";
        } else if (id == 10) {
            description = "+" + effects[id] + " Bonus Action.";
        }
        description += "\nDuration:" + duration;
    }
    public int GetDuration () => duration;
    public void SetDuration (int i) {
        duration += i;
    }
    public void SetLevel (int i) {
        effects[id] += i;
        SetDescription ();
    }
    public Sprite GetIcon () => icon;
}