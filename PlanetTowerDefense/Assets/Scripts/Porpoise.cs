using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Porpoise : Interactable
{

    [SerializeField]
    private int maxHealth = 500;
    [SerializeField]
    private int health;
    public static Porpoise Instance;
    [SerializeField]
    private ParticleSystem engine;
    [SerializeField]
    private AudioSource engineRumble;
    public Text healthView;
    [SerializeField]
    private Canvas lossCanvas;

    private void Awake()
    {
        Instance = this;
        health = maxHealth;
        healthView.text = "Ship Health " + health + "/" + maxHealth;
    }
    public override IEnumerator Interact()
    {
        FindObjectOfType<CameraManager>().SwapToStrat();
        FindObjectOfType<InteractionManager>().Exhaust();
        yield return null;
    }

    public void TakeDamage()
    {
        health--;
        healthView.text = "Ship Health " + health + "/" + maxHealth;

        if(health <= 0)
        {
            lossCanvas.enabled = true;
        }
    }

    public void Heal(){
        health+=50;
        if (health > maxHealth) { health = maxHealth; }

        healthView.text = "Ship Health " + health + "/" + maxHealth;
    }

    public void WinGame()
    {
        CameraManager.Instance.SwapToWin();
        StartCoroutine(BoldlyGo());
        engine.Play();
        engineRumble.Play();
    }

    private IEnumerator BoldlyGo()
    {
        while (true)
        {
            gameObject.transform.Translate(Vector3.up*50*Time.deltaTime);
            yield return null;
        }


    }
}
