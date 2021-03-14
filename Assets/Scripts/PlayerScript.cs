using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerScript : MonoBehaviour
{
    public AudioSource musicSource;
    public AudioClip musicClipOne;
    public AudioClip musicClipTwo;
    private Rigidbody2D rd2d;
    public float speed;
    public Text score;
    public Text lives;
    public Text winText;
    public Text loseText;
    public GameObject Player;
    private int scoreValue = 0;
    private int livesValue = 3;

    // Start is called before the first frame update
    void Start()
    {
        rd2d = GetComponent<Rigidbody2D>(); 
        score.text = scoreValue.ToString();
        lives.text = livesValue.ToString();
        winText.text = ""; 
        loseText.text = "";
        musicSource.clip = musicClipOne;
        musicSource.Play();
        
    }

    // Update is called once per frame
    void Update()
    {
        float hozMovement = Input.GetAxis("Horizontal");
        float verMovement = Input.GetAxis("Vertical");

        rd2d.AddForce(new Vector2(hozMovement * speed, verMovement * speed));
        

    }
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.tag == "Coin")
        {
            scoreValue += 1;
            score.text = scoreValue.ToString();
            if (scoreValue == 4)
            {
            
                transform.position = new Vector3(28.4f, 1.8f, 0.0f);
                lives.text = "3";
            }
            
            if (scoreValue >=8)
            {
                winText.text = "You Win! Game created by Eric Kenney";
                musicSource.clip = musicClipTwo;
                musicSource.Play();
            }
            Destroy(collision.collider.gameObject);
           
        }
        
        if(collision.collider.tag == "Enemy")
        {
            livesValue -=1;
            lives.text = livesValue.ToString();
            if (livesValue <= 0)
            {
                loseText.text = "You Lose!";
                Destroy(Player.gameObject);
            }
            Destroy(collision.collider.gameObject);
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if(collision.collider.tag == "Ground")
        {
            if(Input.GetKey(KeyCode.W))
            {
                rd2d.AddForce(new Vector2(0, 3), ForceMode2D.Impulse);
            }
        }
    }

}
