using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BallsSpawn : MonoBehaviour
{
    public GameObject ballPrefab;
    public TextMeshProUGUI totalCashText;

    public void BallSpawn()
    {
        Mishenes.totalCash -= Mishenes.bet;
        totalCashText.text = Mishenes.CashString(Mishenes.totalCash);

        float x = Random.Range(-0.2f, 0.2f);
        float y = Random.Range(3f, 3.2f);
        Instantiate(ballPrefab, new Vector3(x, y), Quaternion.identity, transform);
    }

}
