﻿using UnityEngine;

[System.Serializable]
public class Power {
    [SerializeField] private bool set = false;
    [SerializeField] private int id;
    [SerializeField] private string name;
    [SerializeField] private string description;
    [SerializeField] private int cooldown;
    [SerializeField] private int cooldownUI;

    public Power (int i) {
        set = true;
        id = i;
        cooldownUI = 0;
        if (id == 0) {
            name = "Berserk";
            description = "+1 Action";
            cooldown = 3;
        } else if (id == 1) {
            name = "Backstab";
            description = "+2 Mouvement";
            cooldown = 3;
        } else if (id == 2) {
            name = "Sniper";
            description = "Range +1";
            cooldown = 3;
        } else if (id == 3) {
            name = "Heal";
            description = "Can Heal : 1;5";
            cooldown = 3;
        } else if (id == 4) {
            name = "Dice";
            description = "+2 for all dice rolls this turn";
            cooldown = 3;
        } else if (id == 5) {
            name = "Reroll";
            description = "Can reroll once this turn";
            cooldown = 3;
        } else if (id == 6) {
            name = "Damage";
            description = "+3 damage this turn";
            cooldown = 3;
        } else if (id == 7) {
            name = "Block";
            description = "Prevent damage until next turn";
            cooldown = 3;
        } else
            Debug.Log ("Power Error " + id);
    }
    public bool GetSet () => set;
    public string GetName () => name;
    public string GetDescription () => description;
    public int GetId () => id;
    public int GetCooldown () => cooldown;
    public void SetCooldownUI (int i) {
        cooldownUI += i;
    }
    public int GetCooldownUI () => cooldownUI;

}