using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeButton : MonoBehaviour
{
    private int cost = 100;
    private int counter = 0;
    public Text text;
    private Porpoise poro;
    private InventoryManager inventory;

    private void Start() {
        poro = Porpoise.Instance;
        inventory = InventoryManager.instance;
        text.text = "Upgrade Ship (" + cost +")";
    }

    public void Upgrade() {
        if (inventory.GetGold() < cost) {return;}
        inventory.updateGold(-cost);
        cost+=100;
        counter++;
        if (counter >= 3){
            poro.WinGame();
        }
        text.text = "Upgrade Ship (" + cost +")";
    }
}
