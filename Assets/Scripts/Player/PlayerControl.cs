using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerControl : MonoBehaviour
{
    public UIManagerScript uiManagerScript;
    
    public AudioSource deadSound;
    public AudioSource levelCompledSound;
    
    public GameObject dirt;
    public Rigidbody2D rb;
    
    public float movementSpeed = 10;
    public float jumpHeight = 5;
    
    public bool grounded = true;
    
    void Start()
    {
        grounded = true;
    }

    void Update()
    {
        rb.velocity = new Vector2(movementSpeed, rb.velocity.y);

        if (Input.GetKey(KeyCode.Space))
        {
            if (grounded)
            {
                float jumpForce = Mathf.Sqrt(jumpHeight * -2 * (Physics2D.gravity.y * rb.gravityScale));
                
                rb.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
                
                grounded = false;
                
                dirt.SetActive(false);
            }
        }
    }
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Floor")
        {
            grounded = true;
            dirt.SetActive(true);
        }
        
        if (collision.collider.tag == "Obstacle")
        {
            StartCoroutine(DelayedGameOver());
        }

        if (collision.collider.tag == "GameOver")
        {
            gameObject.SetActive(false);
            levelCompledSound.Play();
            uiManagerScript.GameOver();
        }
    }

    IEnumerator DelayedGameOver()
    {
        //Play dead sounds
        deadSound.Play();
        
        //Wait 0.10 seconds
        yield return new WaitForSeconds(0.10f);
        
        //Disable player object to hide and stop running for prevent bugs
        gameObject.SetActive(false);

        //Display GameOver screen
        uiManagerScript.GameOver();
    }
}