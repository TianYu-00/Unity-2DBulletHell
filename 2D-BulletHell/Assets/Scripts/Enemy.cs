using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float moveSpeed;
    private Player player;
    private Transform playerPos;
    public GameObject bleedEffect;
    

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        playerPos = GameObject.FindGameObjectWithTag("Player").transform;
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, playerPos.position, moveSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")) {
            if (!player.isInvincible)
            {
                Instantiate(bleedEffect, transform.position, Quaternion.identity);
                player.health--;
                Debug.Log(player.health);
                Destroy(gameObject);
                player.InvincibleTime();
            }
        }

        if (collision.CompareTag("Projectile")) {
            Instantiate(bleedEffect, transform.position, Quaternion.identity);
            player.score += 100;
            Debug.Log(player.score);
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }

        if (collision.CompareTag("SkillAura"))
        {
            Instantiate(bleedEffect, transform.position, Quaternion.identity);
            player.score += 100;
            Debug.Log(player.score);
            Destroy(gameObject);
        }
    }
}
