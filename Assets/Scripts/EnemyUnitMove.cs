using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyUnitMove : MonoBehaviour
{
    public float moveSpeed = 5f;   
    public float attackRange = 2f; 
    public float attackDamage = 10f;

    public float maxHealth = 50f;
    private float currentHealth;

    private Transform targetCastle; 
    private GameObject targetEnemy; 

    private void Start()
    {
        
        targetCastle = GameObject.FindWithTag("AlliedCastle").transform;
    }

    private void Update()
    {
        
        GameObject nearestEnemy = FindNearestEnemy();

        if (nearestEnemy != null)
        {
            
            Vector3 enemyPosition = nearestEnemy.transform.position;
            Vector3 moveDirection = (enemyPosition - transform.position).normalized;
            transform.Translate(moveDirection * moveSpeed * Time.deltaTime);

            
            float distanceToEnemy = Vector3.Distance(transform.position, enemyPosition);

            
            if (distanceToEnemy <= attackRange)
            {
                Attack(nearestEnemy);
            }
        }
        else
        {
            
            MoveToCastle();
        }
    }

    private GameObject FindNearestEnemy()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Ally"); 
        GameObject nearestEnemy = null;
        float nearestDistance = float.MaxValue;

        foreach (GameObject enemy in enemies)
        {
            float distance = Vector3.Distance(transform.position, enemy.transform.position);

            
            if (distance < nearestDistance)
            {
                nearestEnemy = enemy;
                nearestDistance = distance;
            }
        }

        return nearestEnemy;
    }

    private void Attack(GameObject targetEnemy)
    {
        
       
        EnemyUnitMove enemyUnit = targetEnemy.GetComponent<EnemyUnitMove>();

        if (enemyUnit != null)
        {
            enemyUnit.TakeDamage(attackDamage);
        }
    }

    public void TakeDamage(float attackDamage)
    {
        currentHealth -= attackDamage;
        if(currentHealth <= 0)
        {
            Die();
        }

    }

    private void Die()
    {
        Destroy(gameObject);
    }

    private void MoveToCastle()
    {
        
        Vector3 castlePosition = targetCastle.position;
        Vector3 moveDirection = (castlePosition - transform.position).normalized;
        transform.Translate(moveDirection * moveSpeed * Time.deltaTime);
    }
}
