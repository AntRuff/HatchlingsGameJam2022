using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gold : Interactable
{
    [SerializeField] private InventoryManager inventory;
    public int mineAmount = 25;
    private int minesRemaining;
    public int maxMines = 3;
    private string textCopy;

    private void Start()
    {
        minesRemaining = maxMines;
        textCopy = interactText;
    }

    public override IEnumerator Interact()
    {

        if (minesRemaining > 0)
        {
            inventory.updateGold(mineAmount);
            minesRemaining--;
            if (minesRemaining == 0)
            {
                gameObject.GetComponentInParent<MeshRenderer>().enabled = false;
                gameObject.GetComponent<BoxCollider>().enabled = false;
                interactText = "";

                FindObjectOfType<InteractionManager>().Exhaust();

            }
            yield return new WaitForSeconds(1f);

            if (minesRemaining > 0)
            {
                FindObjectOfType<InteractionManager>().Refresh();
            }
        }
    }

    public void Replish()
    {
        if (minesRemaining == 0)
        {
            minesRemaining++;
            gameObject.GetComponentInParent<MeshRenderer>().enabled = true;
            gameObject.GetComponent<BoxCollider>().enabled = true;
            interactText = textCopy;
        }
        else
        {
            minesRemaining += maxMines / 2;
            if (minesRemaining > maxMines)
            {
                minesRemaining = maxMines;
            }
        }
    }
}
