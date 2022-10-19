using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ring : MonoBehaviour
{
    private GameObject[] player;
    private AudioManager audioManager;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectsWithTag("Player");
        audioManager = FindObjectOfType<AudioManager>();
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < player.Length; i++)
        {
            if (transform.position.y > player[i].transform.position.y)
            {
                audioManager.Play("whoosh");
                GameManager.numberOfPassedRing++;
                GameManager.score++;
                Destroy(gameObject);
            }
        }
    }
}
