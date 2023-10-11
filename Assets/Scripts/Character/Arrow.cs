using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    public float damage = 10f; 

    private void OnTriggerEnter2D(Collider2D other)
    {
        
        EnemyUnitMove enemy = other.GetComponent<EnemyUnitMove>();
        if (enemy != null)
        {
            
            enemy.TakeDamage(damage);
            Destroy(gameObject);
        }
    }
}
