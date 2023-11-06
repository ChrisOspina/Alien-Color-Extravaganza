using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public string ballColor;
    Rigidbody rb;
    Vector3 velocity;

    AudioSource src;
    public AudioClip bumpsound;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        src = GetComponent<AudioSource>();

        rb.AddForce(Vector3.forward * 3.0f, ForceMode.VelocityChange);
    }

    void Update()
    {
        velocity = rb.velocity;
    }
    private void OnCollisionEnter(Collision collision)
    {
            float speed = velocity.magnitude;
            Vector3 direction = Vector3.Reflect(velocity.normalized, collision.contacts[0].normal);
            rb.velocity = direction * speed;
        if(collision.gameObject.CompareTag("Player"))
            src.PlayOneShot(bumpsound);
    }


}
