using UnityEngine;
using TMPro;

public class Mishenes : MonoBehaviour
{
    public static float totalCash = 3000f;
    public static float bet = 5f;

    public TextMeshProUGUI totalCashText;
    public TextMeshProUGUI winCashText;

    private float winCash;

    public float greenKoef;
    public float yellowKoef;
    public float redKoef;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Green ball")
        {
            CashCalculating(greenKoef);
            Destroy(collision.gameObject);
        }
        //else
        //if (collision.gameObject.tag == "Red ball")
        //{
        //    CashWin(redKoef);
        //    Destroy(collision.gameObject);
        //}
        //else
        //if (collision.gameObject.tag == "Yellow ball")
        //{
        //    CashWin(yellowKoef);
        //    Destroy(collision.gameObject);
        //}

    }

    public void CashCalculating(float koef)
    {
        winCash = bet * koef;
        totalCash += winCash;

        winCashText.text = "+" + CashString(winCash);
        totalCashText.text = CashString(totalCash);
    }

    public static string CashString(float cash)
    {
        float cashInt = Mathf.Floor(cash);
        float cashFraction = (cash - cashInt) * 100;
        string cashFrcStr;

        if (cashFraction < 10) 
            cashFrcStr = "0" + cashFraction;
        else
            cashFrcStr = cashFraction.ToString();

        return cashInt + "." + cashFrcStr + " USD"; 
    }
}
