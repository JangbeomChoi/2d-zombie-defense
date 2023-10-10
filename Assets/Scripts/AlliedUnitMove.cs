
using UnityEngine;

public class AlliedUnitMove : MonoBehaviour
{
    public float moveSpeed = 3f;   
    public float attackRange = 2f; 

    private Transform targetCastle; 
    private GameObject targetEnemy; 

    private void Start()
    {
        // 공격 대상 적의 성을 설정합니다. (예: 게임 시작 시 설정)
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
        // 적군을 공격하는 코드를 추가합니다.
        // 예: 적군에게 데미지를 입히는 등의 작업을 수행합니다.
    }

    private void MoveToCastle()
    {
        
        Vector3 castlePosition = targetCastle.position;
        Vector3 moveDirection = (castlePosition - transform.position).normalized;
        transform.Translate(moveDirection * moveSpeed * Time.deltaTime);
    }
}
