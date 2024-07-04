using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PiramideSpawner : MonoBehaviour
{
    public GameObject obstaclePrefab; 
    public int pins; 
    public float spacing; 
   

    void Start()
    {
        for (int row = 2; row < pins + 2; row++)
        {
            for (int col = 0; col <= row; col++)
            {
                float xPos = col * spacing - (row * spacing / 2);
                float yPos = -row * spacing;
                Vector3 spawnPosition = new Vector3(xPos, yPos, 0);

                Instantiate(obstaclePrefab, spawnPosition, Quaternion.identity, transform);
            }
        }
        transform.position = new Vector3(0f, 3.4f); 
        transform.localScale = new Vector3(0.8f, 0.8f);
    }
}
