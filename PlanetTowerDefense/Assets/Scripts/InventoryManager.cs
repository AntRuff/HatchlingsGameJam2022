using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour
{
    private int silverCount = 0;
    private int goldCount = 0;

    public int silverMax = 300;
    public int goldMax = 300;

    [SerializeField] private Text silver;
    [SerializeField] private Text gold;

    public void updateSilver(int value){
        silverCount += value;
        if (silverCount > silverMax){ silverCount = silverMax; }
        else if (silverCount < 0) { silverCount = 0; }

        silver.text = "Silver " + silverCount + "/" + silverMax;
    }

    public void updateGold(int value){
        goldCount += value;
        if (goldCount > goldMax) { goldCount = goldMax; }
        else if (goldCount < 0) { goldCount = 0 ;}

        gold.text = "Gold " + goldCount + "/" + goldMax;
    }

    public void IncrementSilver() {
        updateSilver(75);
    }

    public void IncrementGold() {
        updateGold(75);
    }

    public void DecrementGold() {
        updateGold(-75);
    }
}
