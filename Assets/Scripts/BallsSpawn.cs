using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BallsSpawn : MonoBehaviour
{
    public TextMeshProUGUI totalCashText;
    public GameObject greenBallPrefab;
    public GameObject yellowBallPrefab;
    public GameObject redBallPrefab;
    public float ballSpawnPeriod;
    public int ballsCount;
    public int ballColorsCount;
    public int greenTurn;
    public int yellowTurn;
    public int redTurn;

    public void BallSpawn(GameObject ballPrefab)
    {
        Target.totalCash -= Target.bet;
        totalCashText.text = Target.MakeCashString(Target.totalCash) + " USD";

        float x = Random.Range(-0.2f, 0.2f);
        float y = Random.Range(3f, 3.2f);

        Instantiate(ballPrefab, new Vector3(x, y), Quaternion.identity, transform);
    }

    public void AutoPlay()
    {
        StartCoroutine(AutoPlayCoroutine());
    }

    public IEnumerator AutoPlayCoroutine()
    {
        for (int i = 0; i < ballsCount; i++)
        {
            if (greenTurn == 0 && (i % ballColorsCount == greenTurn))
            {
                BallSpawn(greenBallPrefab);
            }
            else if (yellowTurn >= 0 && (i % ballColorsCount == yellowTurn))
            {
                BallSpawn(yellowBallPrefab);
            }
            else if (redTurn >= 0 && (i % ballColorsCount == redTurn))
            {
                BallSpawn(redBallPrefab);
            }

            yield return new WaitForSeconds(ballSpawnPeriod);
        }
    }


}
