using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerEcho : MonoBehaviour
{
    private float timeBetweenSpawn;
    public float startTimeBetweenSpawn;
    public GameObject echo;
    private Player player;


    private void Start()
    {
        player = GetComponent<Player>();
    }
    private void Update()
    {
        if (player.moveInput.x != 0 || player.moveInput.y != 0)
        {
            if (timeBetweenSpawn <= 0)
            {
                GameObject instance = (GameObject)Instantiate(echo, transform.position, Quaternion.identity);
                Destroy(instance, 1f);
                timeBetweenSpawn = startTimeBetweenSpawn;
            }
            else
            {
                timeBetweenSpawn -= Time.deltaTime;
            }
        }

        
    }
}
