using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Audio;

public class GGMove : MonoBehaviour
{
    [SerializeField]

    private Rigidbody2D rigidbody;
    public float jumpForce;
    private bool isGrounded = true;
    public float playery;
    public int health;
    public int numberOfLifes;
    public int points;

    public Text scoredisp;
    public Text scoreprosr;

    public GameObject Enemy1;
    public GameObject Enemy2;
    public GameObject Point;
    public GameObject heartenms;

    public GameObject prosrav;

    public Image[] lives;

    public Sprite fulllife;
    public Sprite emptylife;

    private Animator anim;

    public AudioSource minlife;
    public AudioSource pointplus;
    public AudioSource death;
    public AudioSource button;
    public AudioSource jumpsnd;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy1"))
        {
            health = health - 2;
            minlife.Play();
        }

        if (other.CompareTag("Enemy2"))
        {
            health--;
            minlife.Play();
        }

        if (other.CompareTag("Point"))
        {
            points++;
            pointplus.Play();
        }
        if (other.CompareTag("heartenms"))
        {
            health++;
            pointplus.Play();
        }
    }



    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        prosrav.SetActive(false);
        anim = GetComponent<Animator>();
    }

    private void prrosrav()
    {
        prosrav.SetActive(true);
        Time.timeScale = 0;
        scoreprosr.text = points.ToString();
    }

    public void Restart()
    {
        SceneManager.LoadScene(1);
        prosrav.SetActive(false);
        Time.timeScale = 1;
        button.Play();
    }

    public void Menu()
    {
        SceneManager.LoadScene(0);
        Time.timeScale = 1;
        button.Play();
    }

    void FixedUpdate()
    {

        scoredisp.text = points.ToString(); 

        for (int i = 0; i < lives.Length; i++)
        {
            if (i < health)
            {
                lives[i].sprite = fulllife;
            }
            else
            {
                lives[i].sprite = emptylife;
            }

            if (i < numberOfLifes)
            {
                lives[i].enabled = true;
            }
            else
            {
                lives[i].enabled = false;
            }
        }

        if (health <= 0)
        {
            prrosrav();
            death.Play();
        }


        playery = transform.position.y;

        if (playery < -16f)
        {
            isGrounded = true;
        }
        else
        {
            isGrounded = false;
        }

        if (isGrounded == true && Input.GetKey(KeyCode.Space))
        { 
            rigidbody.AddForce(transform.up * jumpForce, ForceMode2D.Impulse);
            jumpsnd.Play();
        }
    }
    
}
