using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoShooter_Bullet : MonoBehaviour
{
    public float bulletSpeed = 25f;
    private Transform playerPos;
    private Transform closestEnemy;
    // Start is called before the first frame update
    void Start()
    {
        playerPos = transform;
        FindClosestEnemy();
    }

    // Update is called once per frame
    void Update()
    {
        if (closestEnemy != null)
        {
            // Calculate the direction towards the closest enemy
            Vector3 moveDirection = (closestEnemy.position - playerPos.position).normalized;

            // Update the position of the GameObject
            playerPos.position += moveDirection * bulletSpeed * Time.deltaTime;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void FindClosestEnemy()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");

        if (enemies.Length > 0)
        {
            closestEnemy = enemies[0].transform;
            float closestDistance = Vector3.Distance(playerPos.position, closestEnemy.position);

            foreach (GameObject enemy in enemies)
            {
                float distance = Vector3.Distance(playerPos.position, enemy.transform.position);
                if (distance < closestDistance)
                {
                    closestDistance = distance;
                    closestEnemy = enemy.transform;
                }
            }
        }
        else
        {
            closestEnemy = null;
        }
    }
}
