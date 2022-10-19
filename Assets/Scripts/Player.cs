using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Rigidbody rb;
    public float bounceForce = 6;
    private AudioManager audioManager;
    // Start is called before the first frame update
    void Start()
    {
        audioManager = FindObjectOfType<AudioManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        audioManager.Play("bounce");
        rb.velocity = new Vector3(rb.velocity.x, bounceForce, rb.velocity.z);
        string materialName = collision.transform.GetComponent<MeshRenderer>().material.name;
        if(materialName == "safe (Instance)")
        {

        }else if(materialName == "unsafe (Instance)")
        {
            GameManager.gameOver= true;
            audioManager.Play("gameover");
        }
        else if (materialName == "lastRing (Instance)" && !GameManager.levelCompleted)
        {
            GameManager.levelCompleted = true;
            audioManager.Play("winlevel");
        }
    }
}
