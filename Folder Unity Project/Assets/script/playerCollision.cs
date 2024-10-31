using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerCollision : MonoBehaviour
{
    public Rigidbody2D rb;
    public playerMovement movementScript;
    public GameManager gameManager;
    public GameObject playAgain;
    public Animator anime;
    public AudioClip SoundtoPlay;
    public float Volume;
    AudioSource dieSfx;
    public bool alreadyPlayed = false;
    public AudioSource gameOverSfx;
    public AudioSource hitSfx;


    void Start()
    {
        dieSfx = GetComponent<AudioSource>();
    }
    private void OnCollisionEnter2D(Collision2D collision){
    if(collision.gameObject.tag=="Obstacle")
        {
            movementScript.enabled = false;
            print("test");
            anime.SetBool("die", true);
            gameManager.EndGame();
            hitSfx.Play();
            // die audio settings
            if(!alreadyPlayed)
            {
               dieSfx.PlayOneShot(SoundtoPlay, Volume);
               Invoke("PlayAudio", .45f);
               alreadyPlayed = true; 
            }
            
        } else {
            anime.SetBool("die", false);
        }
    }

    public void PlayAudio()
    {
        gameOverSfx.Play();
    }

    



    

}
