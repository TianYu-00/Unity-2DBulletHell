using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageAura : MonoBehaviour
{
    public float rotationSpeed = 30f;
    public float distanceOffset = 5f;
    private Transform playerPos;

    private void Start()
    {

        playerPos = GameObject.FindGameObjectWithTag("Player").transform;
    }

    private void Update()
    {
        // Rotate the Orbiting GameObject around the player.
        transform.RotateAround(playerPos.position, Vector3.forward, rotationSpeed * Time.deltaTime);
    }

    public void Spawn(Transform playerPos)
    {
        Vector3 spawnPosition = playerPos.position + new Vector3(distanceOffset, 0f, 0f);
        GameObject damageAura = Instantiate(gameObject, spawnPosition, Quaternion.identity);
        damageAura.transform.SetParent(playerPos);
    }

}
