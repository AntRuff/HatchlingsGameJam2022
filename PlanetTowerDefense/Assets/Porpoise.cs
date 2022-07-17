using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Porpoise : Interactable
{
    private int health = 500;
    public static Porpoise Instance;
    [SerializeField]
    private ParticleSystem engine;
    [SerializeField]
    private AudioSource engineRumble;

    private void Awake()
    {
        Instance = this;
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

        if(health <= 0)
        {
            //YOU LOse
        }
    }

    public void WinGame()
    {
        gameObject.transform.Translate(Vector3.up * 100);
        engine.Play();
        engineRumble.Play();
    }
}
