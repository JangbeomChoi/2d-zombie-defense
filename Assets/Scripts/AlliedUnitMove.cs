
using UnityEngine;

public class AlliedUnitMove : MonoBehaviour
{
    public float moveSpeed = 3f;   
    public float attackRange = 2f; 

    private Transform targetCastle; 
    private GameObject targetEnemy; 

    private void Start()
    {
        // ���� ��� ���� ���� �����մϴ�. (��: ���� ���� �� ����)
        targetCastle = GameObject.FindWithTag("EnemyCastle").transform;
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
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy"); 
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

    private void Attack(GameObject enemy)
    {
        // ������ �����ϴ� �ڵ带 �߰��մϴ�.
        // ��: �������� �������� ������ ���� �۾��� �����մϴ�.
    }

    private void MoveToCastle()
    {
        
        Vector3 castlePosition = targetCastle.position;
        Vector3 moveDirection = (castlePosition - transform.position).normalized;
        transform.Translate(moveDirection * moveSpeed * Time.deltaTime);
    }
}
