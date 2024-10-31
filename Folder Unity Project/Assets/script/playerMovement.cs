using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class playerMovement : MonoBehaviour
{
    public Rigidbody2D rb;

    public TMP_InputField jumpForceInputField; 

    public TMP_InputField speedInputField; 
    
    public TMP_InputField gravityInputField; 

    public float currentSpeed = 0.1f;

    public float xSpeed;

    public float jumpForce;

    private float minJumpForce = 0f; 
    
    private float maxJumpForce = 1000f;
    
    private float minSpeed = 0f; 
    
    private float maxSpeed = 1000f;

    private float minGravity = 0f; 
    
    private float maxGravity = 1000f;

    public float gravity;

    public float score;

    public TextMeshProUGUI scoreText;

    public TextMeshProUGUI speedText;
    
    public TextMeshProUGUI jumpText;

    public TextMeshProUGUI gravityText;

    public TextMeshProUGUI scoreFinish;

    public TextMeshProUGUI speedFinish;
    
    public TextMeshProUGUI jumpFinish;

    public TextMeshProUGUI gravityFinish;

    public bool isStart;

    public Animator boardAnime;

    public AudioSource boardSfx;

    public AudioSource pointSfx;

    public AudioSource jumpSfx;


    void Start()
    {
        rb.gravityScale = 0f;
        jumpForce = 10f;
        SetJumpForce(jumpForce);
        jumpForceInputField.onEndEdit.AddListener(OnJumpForceChanged);
        speedInputField.onEndEdit.AddListener(OnSpeedChanged);
        gravityInputField.onEndEdit.AddListener(OnGravityChanged);
        boardAnime.SetBool("boardIdle", true);
        boardAnime.SetBool("boardSlide", false);
        boardSfx.Play();
    }

    // Update is called once per frame
    void Update()
    {
        if(isStart){

            rb.velocity = new Vector2(currentSpeed, rb.velocity.y);
            
            if(currentSpeed > xSpeed)
            {  
                currentSpeed -= xSpeed * Time.deltaTime;

                if(currentSpeed < xSpeed)
                {
                    currentSpeed = 0f;
                }

            } else {

                currentSpeed += xSpeed * Time.deltaTime;
                
                 currentSpeed = Mathf.Clamp(currentSpeed, 0f, xSpeed);

            }
            
            if(currentSpeed % 1 == 0){
                speedText.text = currentSpeed.ToString("");
                speedFinish.text = xSpeed.ToString("");
            }else {
                speedText.text = currentSpeed.ToString("F1");
                speedFinish.text = xSpeed.ToString("F1");
            }
            
            if(gravity % 1 == 0){
                gravityText.text = gravity.ToString("0");
                gravityFinish.text = gravity.ToString("");
            } else {
                gravityText.text = gravity.ToString("F1");
                gravityFinish.text = gravity.ToString("F1");
            }

            if(jumpForce % 1 == 0){
                jumpText.text = jumpForce.ToString("");
                jumpFinish.text = jumpForce.ToString("");
            }else {
                jumpText.text = jumpForce.ToString("F1");
                jumpFinish.text = jumpForce.ToString("F1");
            }

        }
        if(Input.GetKeyDown(KeyCode.Return))
        {
            boardAnime.SetBool("boardSlide", true);
        } 

        if(Input.GetKeyDown(KeyCode.E))
        {
            boardAnime.SetBool("boardSlide", true);
            isStart = true;
            rb.gravityScale = 0.5f * gravity;
            Jump();
            jumpSfx.Play();
        }

        
    }
        private void Jump(){
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }

        private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag=="point")
        {
            pointSfx.Play();
            score++;
            scoreText.text = score.ToString();
            scoreFinish.text = score.ToString();
            if(score % 10 == 0){
                xSpeed+=2;
            }
        }

    }

    void OnJumpForceChanged(string newValue)
    {
                if (float.TryParse(newValue, out float result))
        {
            // Mengatur nilai Jump Force sesuai dengan rentang yang ditentukan
            jumpForce = Mathf.Clamp(result, minJumpForce, maxJumpForce);
            SetJumpForce(jumpForce);
        }
        else
        {
            jumpForceInputField.text = jumpForce.ToString();
            Debug.LogWarning("Input tidak valid!"); // Pesan jika input tidak valid
        } 
    }

    void SetJumpForce(float force)
    {
        // Lakukan apa pun yang perlu dilakukan dengan nilai Jump Force, misalnya pada karakter pemain atau objek lain yang membutuhkan Jump Force
        Debug.Log("Jump Force: " + force);
        // Misalnya, Anda memiliki objek karakter dan ingin mengatur nilai Jump Force-nya
        // characterController.jumpForce = force;
    }

        void OnSpeedChanged(string newValue)
    {
                if (float.TryParse(newValue, out float result))
        {
            // Mengatur nilai Jump Force sesuai dengan rentang yang ditentukan
            xSpeed = Mathf.Clamp(result, minSpeed, maxSpeed);
            SetSpeed(xSpeed);
        }
        else
        {
            speedInputField.text = xSpeed.ToString();
            Debug.LogWarning("Input tidak valid!"); // Pesan jika input tidak valid
        }
    }

    void SetSpeed(float speed)
    {
        // Lakukan apa pun yang perlu dilakukan dengan nilai Jump Force, misalnya pada karakter pemain atau objek lain yang membutuhkan Jump Force
        Debug.Log("Jump Force: " + speed);
        // Misalnya, Anda memiliki objek karakter dan ingin mengatur nilai Jump Force-nya
        // characterController.jumpForce = force;
    }
        void OnGravityChanged(string newValue)
    {
                if (float.TryParse(newValue, out float result))
        {
            // Mengatur nilai Jump Force sesuai dengan rentang yang ditentukan
            gravity = Mathf.Clamp(result, minGravity, maxGravity);
            SetGravity(gravity);
        }
        else
        {
            gravityInputField.text = gravity.ToString();
            Debug.LogWarning("Input tidak valid!"); // Pesan jika input tidak valid
        }
    }

    void SetGravity(float Gravity)
    {
        // Lakukan apa pun yang perlu dilakukan dengan nilai Jump Force, misalnya pada karakter pemain atau objek lain yang membutuhkan Jump Force
        Debug.Log("Jump Force: " + Gravity);
        // Misalnya, Anda memiliki objek karakter dan ingin mengatur nilai Jump Force-nya
        // characterController.jumpForce = force;
    }

    

    private void OnCollisionEnter2D(Collision2D collision){
    if(collision.gameObject.tag=="Obstacle")
        {
            currentSpeed = 0;
            if(currentSpeed > xSpeed)
            {  
                currentSpeed -= xSpeed * Time.deltaTime;

                if(currentSpeed < xSpeed)
                {
                    currentSpeed = 0f;
                }

            } else {

                currentSpeed += xSpeed * Time.deltaTime;
                
                 currentSpeed = Mathf.Clamp(currentSpeed, 0f, xSpeed);

            }
            speedText.text = currentSpeed.ToString();
        } 
    }

}

