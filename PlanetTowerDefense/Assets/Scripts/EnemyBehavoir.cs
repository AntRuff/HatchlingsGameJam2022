using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyBehavoir : MonoBehaviour
{
    [SerializeField]
    public Transform target;
    [SerializeField]
    private int health = 20;
    [SerializeField]
    private float moveEeed;

    public void TakeDamage(int damage)
    {
        health -= damage;
        if(health <= 0)
        {
            Destroy(gameObject);
        }
    }

    private void Update()
    {
        transform.LookAt(target);
        transform.position = Vector3.MoveTowards(transform.position, target.position, moveEeed*Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<Bulletscript>())
        {
            TakeDamage(1);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
       if(collision.gameObject.transform == target)
        {
            //PUT DAMAGE CODE HERE
            TakeDamage(999);
        }
    }
}
