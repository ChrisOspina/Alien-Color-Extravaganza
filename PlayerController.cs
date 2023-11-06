using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 5f;
    public float timeLeft = 60;
    Rigidbody rb;

    public TMP_Text scoreText;
    //public TMP_Text livesText;
    public TMP_Text timeText;

    AudioSource src;
    public AudioClip bumpsound;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        src = GetComponent<AudioSource>();
        //livesText.text = "Lives : " + GameData.lives.ToString();
        scoreText.text = "Score : " + GameData.score.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.A)){
            transform.position += Vector3.left * speed * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.D)){
            transform.position += Vector3.right * speed * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.W))
        {
            transform.position += Vector3.forward * speed * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.S))
        {
            transform.position += Vector3.back * speed * Time.deltaTime;
        }

        timeLeft -= Time.deltaTime;
        if (timeLeft <= 0)
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene("GameOver");
        }
        timeText.text = "Time: " + timeLeft.ToString("0.0");


    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Wall"))
        {
            src.PlayOneShot(bumpsound);
        }
    }
}
