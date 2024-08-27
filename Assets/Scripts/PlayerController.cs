using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PlayerController : MonoBehaviour
{
    public float speed;
    Rigidbody rb;
    float xInput;
    float yInput;
    int score = 0;
    public int winScore;
    public GameObject WinText;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

     void Update()
    {
        if(transform.position.y < -5f)
        {
            SceneManager.LoadScene("Game");//if ball falls down then reload scene
        }
    }

    private void FixedUpdate() //smooths the movements as called after fixed intervals
    {
        xInput = Input.GetAxis("Horizontal");
        yInput = Input.GetAxis("Vertical");

        rb.AddForce(xInput*speed,0,yInput*speed); //ball moves left/right and forward/backward

    }
    private void OnTriggerEnter(Collider other)//other object with which we have collided
    {
        if (other.gameObject.CompareTag("Coin"))
        {
            other.gameObject.SetActive(false);
            score++;
            if(score>=winScore)
            {
                WinText.SetActive(true);
            }
        }
    }
}
