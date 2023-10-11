using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Archeor : MonoBehaviour
{
    public Transform arrowSpawnPoint;
    public GameObject arrowPrefab;
    public float arrowSpeed = 10f;
    public float fireRate = 2f; 

    private float nextFireTime = 0f;

    private void Start()
    {
        
        nextFireTime = Time.time + 1f / fireRate;
    }

    private void Update()
    {
        if (Time.time >= nextFireTime)
        {
            FireArrow(); 
            nextFireTime = Time.time + 1f / fireRate; 
        }
    }

    private void FireArrow()
    {
        if (arrowPrefab != null && arrowSpawnPoint != null)
        {
            GameObject arrow = Instantiate(arrowPrefab, arrowSpawnPoint.position, arrowSpawnPoint.rotation);
            Rigidbody2D rb = arrow.GetComponent<Rigidbody2D>();

            if (rb != null)
            {
                Vector2 arrowDirection = transform.right;
                rb.velocity = arrowDirection * arrowSpeed;
            }
        }
    }
}
