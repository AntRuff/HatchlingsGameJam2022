using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyBehavoir : MonoBehaviour
{
    [SerializeField]
    public Transform target;
    private NavMeshAgent nav;
    [SerializeField]
    private int health = 20;

    // Start is called before the first frame update
    void Start()
    {
        nav = GetComponent<NavMeshAgent>();
        nav.destination = target.position;
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        if(health <= 0)
        {
            Destroy(gameObject);
        }
    }
}
