using System.Collections;
using System.Collections.Generic;
using Ultimate.AI;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    [SerializeField] public int damage;
    [SerializeField] private float torque;
    [SerializeField] private Rigidbody rb;
    private string enemyTag;
    private bool didHit;
    [SerializeField] private PlayerHealth attacker;

    public void SetEnemyTag(string enemyTag)
    {
        this.enemyTag = enemyTag;
    }

    public void Fly(Vector3 force)
    {
        rb.isKinematic = false;
        rb.AddForce(force, ForceMode.Impulse);
        rb.AddTorque(transform.right * torque);
        transform.SetParent(null);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(didHit) 
        {
            var health = other.GetComponent<UltimateAI>();
            Debug.Log(health.health);
            return;
        }
        else
        {
            didHit = true;
        }

        if(other.CompareTag(enemyTag))
        {
            var health = other.GetComponent<UltimateAI>();
            health.TakeDamage(damage, attacker);
        }

        rb.velocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;
        rb.isKinematic = true;
        transform.SetParent(other.transform);

    }
}
