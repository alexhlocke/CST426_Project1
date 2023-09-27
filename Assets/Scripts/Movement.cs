using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Movement : MonoBehaviour
{
    public string enemyTag = "Enemies";
    private List<Transform> enemies = new List<Transform>();
    private NavMeshAgent agent;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        FindEnemies();
        SetDestinationToClosestEnemy();
    }

    void Update()
    {
        if (Time.frameCount % 60 == 0)
        {
            UpdateLivingEnemiesList();
            SetDestinationToClosestEnemy();
        }
    }

    public void FindEnemies()
    {
        GameObject[] enemyArray = GameObject.FindGameObjectsWithTag(enemyTag);
        foreach (GameObject enemy in enemyArray)
        {
            if (!enemy.GetComponent<life>().isDead()) {
                enemies.Add(enemy.transform);
            }
        }
    }
    
    void UpdateLivingEnemiesList()
    {
        enemies.RemoveAll(enemy => enemy == null);
    }

    void SetDestinationToClosestEnemy()
    {
        if (enemies == null || enemies.Count == 0)
        {
            return;
        }
        
        Transform closestEnemy = null;
        float closestDistance = Mathf.Infinity;

        foreach (Transform enemy in enemies)
        {
            if (enemy.GetComponent<life>().isDead()) {
                continue;
            }

            float distance = Vector3.Distance(transform.position, enemy.position);
            
            if (distance < closestDistance)
            {
                closestDistance = distance;
                closestEnemy = enemy;
            }
        }

        if (closestEnemy != null) {
            agent.SetDestination(closestEnemy.position);
        } else {
            agent.SetDestination(Vector3.zero);
        }
    }
}
