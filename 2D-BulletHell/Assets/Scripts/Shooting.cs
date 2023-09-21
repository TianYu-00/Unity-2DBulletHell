using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public GameObject shot;
    private Transform playerPos;
    Pause pause;

    private void Start()
    {
        playerPos = GetComponent<Transform>();
        pause = FindObjectOfType<Pause>();
    }

    private void Update()
    {
        if (pause.GetIsPaused()) { return; }
        if (Input.GetMouseButtonDown(0))
        {
            Instantiate(shot, playerPos.position, Quaternion.identity);
        }
    }
}
