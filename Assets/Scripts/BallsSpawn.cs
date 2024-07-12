using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class BallsSpawn : MonoBehaviour
{
    public TextMeshProUGUI totalCashText;
    public GameObject ballSpawner;
    public GameObject greenBallPrefab;
    public GameObject yellowBallPrefab;
    public GameObject redBallPrefab;
    public float ballSpawnPeriod;
    public int ballsCount;
    public int ballColorsCount;
    public int green;
    public int yellow;
    public int red;

    public static void BallSpawn(GameObject ballPrefab, TextMeshProUGUI totalCashText, GameObject spawner)
    {
        Target.totalCash -= Target.bet;
        totalCashText.text = Target.MakeCashString(Target.totalCash) + " USD";

        float x = UnityEngine.Random.Range(-0.2f, 0.2f);
        float y = UnityEngine.Random.Range(3f, 3.2f);

        Instantiate(ballPrefab, new Vector3(x, y), Quaternion.identity, spawner.gameObject.transform);
    }

    public void AutoPlay()
    {
        StartCoroutine(AutoPlayCoroutine());
    }

    public IEnumerator AutoPlayCoroutine()
    {
        for (int i = 0; i < ballsCount; i++)
        {
            if (green == 0 && (i % ballColorsCount == green))
            {
                BallSpawn(greenBallPrefab, totalCashText, ballSpawner);
            }
            else if (yellow >= 0 && (i % ballColorsCount == yellow))
            {
                BallSpawn(yellowBallPrefab, totalCashText, ballSpawner);
            }
            else if (red >= 0 && (i % ballColorsCount == red))
            {
                BallSpawn(redBallPrefab, totalCashText, ballSpawner);
            }
            yield return new WaitForSeconds(ballSpawnPeriod);
        }
    }
}
