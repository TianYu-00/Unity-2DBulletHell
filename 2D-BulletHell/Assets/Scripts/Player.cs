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

    //Dash
    public float dashSpeed;
    private float activeMoveSpeed;
    public float dashLength = 0.5f;
    public float dashCD = 1f;
    private float dashCounter;
    private float dashCoolCounter;

    //Invincible Time frame
    public bool isInvincible = false;
    public float invincibleTimeDuration;
    private float invincibleCDTimer;





    //Stats
    public int health = 10;
    public int score = 0;

    //UI
    public TextMeshProUGUI healthDisplayText;
    public TextMeshProUGUI scoreDisplayText;
    public TextMeshProUGUI timeDisplayText;
    private float timeSinceStart;
    


    private void Awake()
    {
        pause = FindObjectOfType<Pause>();
    }

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        timeSinceStart = Time.time;
        activeMoveSpeed = moveSpeed;
        invincibleCDTimer = invincibleTimeDuration;



    }

    private void Update()
    {
        if (pause.GetIsPaused()) { return; }


        invincibleCDTimer -= Time.deltaTime;
        if (invincibleCDTimer <= 0)
        {
            isInvincible = false;
        }


        moveInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        moveVelocity = moveInput.normalized * activeMoveSpeed;

        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            if (dashCoolCounter <= 0 && dashCounter <= 0)
            {
                activeMoveSpeed = dashSpeed;
                dashCounter = dashLength;
            }
        }

        if (dashCounter > 0)
        {
            dashCounter -= Time.deltaTime;
            if (dashCounter <= 0)
            {
                activeMoveSpeed = moveSpeed;
                dashCoolCounter = dashCD;
            }
        }

        if (dashCoolCounter > 0)
        {
            dashCoolCounter -= Time.deltaTime;
        }



        healthDisplayText.text = "HEALTH:" + health;
        if (health <= 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
        scoreDisplayText.text = "SCORE:" + score;
        TimeDisplay();
    }

    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + moveVelocity * Time.fixedDeltaTime);
    }


    private void TimeDisplay()
    {
        float elapsedTime = Time.time - timeSinceStart;
        int minutes = Mathf.FloorToInt(elapsedTime / 60);
        int seconds = Mathf.FloorToInt(elapsedTime % 60);

        // Format the time as a string
        string timeString = string.Format("{0:00}:{1:00}", minutes, seconds);

        // Display the time in the Text element
        timeDisplayText.text = "TIME:" + timeString;
    }

    public void InvincibleTime()
    {
        isInvincible = true;
        invincibleCDTimer = invincibleTimeDuration;
    }

}
