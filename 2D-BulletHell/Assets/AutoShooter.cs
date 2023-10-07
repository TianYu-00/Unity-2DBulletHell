using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoShooter : MonoBehaviour
{
    [Header("Private")]
    private Transform playerPos;
    private GameObject enemyTarget;
    [Header("Public")]
    public GameObject bulletToSpawn;
    public float abilityCD = 1f;
    private float currentCD = 0f;



    // Start is called before the first frame update
    void Start()
    {
        playerPos = GameObject.FindGameObjectWithTag("Player").transform;
        
    }

    // Update is called once per frame
    void Update()
    {
        //bulletToSpawn

        // Increment the elapsed time by deltaTime
        currentCD += Time.deltaTime;

        if (currentCD >= abilityCD)
        {
            enemyTarget = GameObject.FindGameObjectWithTag("Enemy");
            if (enemyTarget != null)
            {
                //
                GameObject tempBullet = Instantiate(bulletToSpawn, playerPos.position, Quaternion.identity);
            }

            currentCD = 0f;
        }
        
        

    }

    public void Spawn(Transform playerPos)
    {
        Vector3 spawnPosition = playerPos.position + new Vector3(0f, 0f, 0f);
        GameObject autoShooter = Instantiate(gameObject, spawnPosition, Quaternion.identity);
        autoShooter.transform.SetParent(playerPos);
    }
}
