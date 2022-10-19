using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public GameObject[] target;
    private Vector3 offset;
    public float smootSpeed = 0.04f;
    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindGameObjectsWithTag("Player");
        for (int i = 0; i < target.Length; i++)
        {
            offset = transform.position - target[i].transform.position;
        }
        
    }

    // Update is called once per frame
    void LateUpdate()
    {
        for (int i = 0; i < target.Length; i++)
        {
            Vector3 newPos = Vector3.Lerp(transform.position, target[i].transform.position + offset, smootSpeed);
            transform.position = newPos;
        }
        
    }
}
