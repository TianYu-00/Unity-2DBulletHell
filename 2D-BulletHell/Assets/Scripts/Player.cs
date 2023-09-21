using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Player : MonoBehaviour
{
    Rigidbody2D rb;
    Pause pause;

    //Movements 
    public float moveSpeed;
    private Vector2 moveVelocity;
    [HideInInspector] public Vector2 moveInput;

    //Stats
    public int health = 10;
    public int score = 0;

    //UI
    public TextMeshProUGUI healthDisplayText;
    public TextMeshProUGUI scoreDisplayText;


    private void Awake()
    {
        pause = FindObjectOfType<Pause>();
    }

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();


    }

    private void Update()
    {
        if (pause.GetIsPaused()) { return; }

        moveInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        moveVelocity = moveInput.normalized * moveSpeed;
        healthDisplayText.text = "HEALTH:" + health;
        if (health <= 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
        scoreDisplayText.text = "SCORE:" + score;
    }

    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + moveVelocity * Time.fixedDeltaTime);
    }

}
