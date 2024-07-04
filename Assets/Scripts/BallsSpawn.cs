using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallsSpawn : MonoBehaviour
{
    public GameObject ballPrefab;

    public void BallSpawn()
    {
        Instantiate(ballPrefab, transform);
    }

}
