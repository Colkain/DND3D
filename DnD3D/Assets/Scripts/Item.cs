using UnityEngine;

public class Item : MonoBehaviour {
    protected int type;
    protected string nameI;
    protected int[] requirements;
    protected int[] effects;

    public Item (int t, string n, int reqstat1, int reqstat2, int reqvalue1, int reqvalue2, int effstat, int effvalue) {
        requirements = new int[4]; //0:strength 1:agility 2:intelligence 3:wisdom
        effects = new int[7]; //0:mouvement 1:maxHealth 2:health 3:strength 4:agility 5:intelligence 6:wisdom
        type = t;
        nameI = n;
        requirements[reqstat1] = reqvalue1;
        requirements[reqstat2] = reqvalue2;
        effects[effstat] = effvalue;
    }
}