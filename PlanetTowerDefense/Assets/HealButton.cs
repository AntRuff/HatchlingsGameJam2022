using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealButton : MonoBehaviour
{
    private int cost = 50;
    public Text text;
    private Porpoise poro;
    private InventoryManager inventory;

    private void Start() {
        poro = Porpoise.Instance;
        inventory = InventoryManager.instance;
        text.text = "Heal (" +cost+ ")";
    }

    public void Healing() {
        if (inventory.GetGold() < cost){ return; }
        inventory.updateGold(-cost);
        cost += 5;
        poro.Heal();
        text.text = "Heal (" +cost+ ")";
    }
}
