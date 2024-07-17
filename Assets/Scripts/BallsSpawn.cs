using System.Collections;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class BallsSpawn : MonoBehaviour
{
    public TextMeshProUGUI totalCashText;
    public GameObject greenBallPrefab;
    public GameObject yellowBallPrefab;
    public GameObject redBallPrefab;
    public GameObject autoPlayPanel;
    public float ballSpawnPeriod;
    public int ballsCount;
    private int ballColorsCount = 3;

    private int greenTurn = 0;
    private int yellowTurn = 1;
    private int redTurn = 2;

    public Toggle greenToggle;
    public Toggle yellowToggle;
    public Toggle redToggle;

    public static float minCashLimit;

    public float RangeMinX = 0.2f;
    public float RangeMinY = 3f;
    public float RangeMaxX = 0.2f;
    public float RangeMaxY = 3.2f;

    public void BallSpawn(GameObject ballPrefab)
    {
        Target.totalCash -= Target.bet;
        totalCashText.text = Target.MakeCashString(Target.totalCash) + " USD";

        float x = Random.Range(RangeMinX, RangeMaxX);
        float y = Random.Range(RangeMinY, RangeMaxY);

        Instantiate(ballPrefab, new Vector3(x, y), Quaternion.identity, transform);
    }

    public void AutoPlay()
    {
        ChooseColorTurn();
        if (ballColorsCount == 0)
        {
            Debug.Log("Choose at least 1 ball color");
        }
        else
        {
            autoPlayPanel.SetActive(false);
            StartCoroutine(AutoPlayCoroutine());
        }
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

            if(Target.totalCash < minCashLimit)
            {
                break;
            }
            
            yield return new WaitForSeconds(ballSpawnPeriod);
        }

        greenTurn = 0;
        yellowTurn = 1;
        redTurn = 2;
}
    
    public void ChooseColorTurn()
    {
        if (greenToggle.isOn)
        {
            greenTurn = -1;
            yellowTurn = 0;
            redTurn = 1;
            ballColorsCount--;
        }

        if (yellowToggle.isOn)
        {
            yellowTurn -= 2;
            redTurn--;
            ballColorsCount--;
        }

        if (redToggle.isOn)
        {
            redTurn -= 3;
            ballColorsCount--;
        }
    }
}
