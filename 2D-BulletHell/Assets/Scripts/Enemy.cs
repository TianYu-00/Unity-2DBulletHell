using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float moveSpeed;
    private Player player;
    private Transform playerPos;
    public GameObject bleedEffect;
    private CameraShakeScript camerShakeScript;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        playerPos = GameObject.FindGameObjectWithTag("Player").transform;
        camerShakeScript = GameObject.FindGameObjectWithTag("vcam").GetComponent<CameraShakeScript>();

    }

    // Update is called once per frame
    void Update()
    {
        if (!player.isInvincible || Vector2.Distance(transform.position, playerPos.position) > 1.5)
        {
            transform.position = Vector2.MoveTowards(transform.position, playerPos.position, moveSpeed * Time.deltaTime);
        }
        else if (player.isInvincible && Vector2.Distance(transform.position, playerPos.position) < 1.5)
        {
            transform.position = Vector2.MoveTowards(transform.position, playerPos.position, -1 * moveSpeed * Time.deltaTime);
        }
            

        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")) {
            if (!player.isInvincible)
            {
                Instantiate(bleedEffect, transform.position, Quaternion.identity);
                player.health--;
                //Debug.Log(player.health);
                Destroy(gameObject);
                player.InvincibleTime();
                camerShakeScript.StartShake(5, 0.3f);
            }

        }

        if (collision.CompareTag("Projectile")) {
            Instantiate(bleedEffect, transform.position, Quaternion.identity);
            player.score += 100;
            //Debug.Log(player.score);
            camerShakeScript.StartShake(5, 0.3f);
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }

        if (collision.CompareTag("Slash"))
        {
            Instantiate(bleedEffect, transform.position, Quaternion.identity);
            player.score += 100;
            //Debug.Log(player.score);
            camerShakeScript.StartShake(5, 0.3f);
            Destroy(gameObject);
        }

        if (collision.CompareTag("SkillAura"))
        {
            Instantiate(bleedEffect, transform.position, Quaternion.identity);
            player.score += 100;
            //Debug.Log(player.score);
            Destroy(gameObject);
        }
    }
}
