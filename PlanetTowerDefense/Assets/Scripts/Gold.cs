using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gold : Interactable
{
    private InventoryManager inventory;
    public int mineAmount = 25;
    private int minesRemaining;
    public int maxMines = 3;
    private string textCopy;

    private void Start()
    {
        minesRemaining = maxMines;
        textCopy = interactText;
        inventory = InventoryManager.instance;
    }

    public override IEnumerator Interact()
    {

        if (minesRemaining > 0)
        {
            inventory.updateGold(mineAmount);
            FindObjectOfType<InteractionManager>().Mine();
            minesRemaining--;
            if (minesRemaining == 0)
            {
                gameObject.GetComponentInChildren<MeshRenderer>().enabled = false;
                gameObject.GetComponent<BoxCollider>().enabled = false;
                gameObject.GetComponentInChildren<ParticleSystem>().Stop();
                interactText = "";

                FindObjectOfType<InteractionManager>().Exhaust();

            }
            yield return new WaitForSeconds(1f);

            if (minesRemaining > 0)
            {
                FindObjectOfType<InteractionManager>().Refresh();
            }
            FindObjectOfType<InteractionManager>().StopMine();
        }
    }

    public void Replish()
    {
        if (minesRemaining == 0)
        {
            minesRemaining++;
            gameObject.GetComponentInParent<MeshRenderer>().enabled = true;
            gameObject.GetComponent<BoxCollider>().enabled = true;
            gameObject.GetComponentInChildren<ParticleSystem>().Play();
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
