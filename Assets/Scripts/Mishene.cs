using UnityEngine;
using TMPro;

public class Mishenes : MonoBehaviour
{
    public static float cash = 3000f;
    public static float bet = 5f;

    public TextMeshProUGUI cashText;

    public float greenKoef;
    public float yellowKoef;
    public float redKoef;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Green ball")
        {
            CashWin(greenKoef);
            Destroy(collision.gameObject);
        }
        else
        if (collision.gameObject.tag == "Red ball")
        {
            CashWin(redKoef);
            Destroy(collision.gameObject);
        }
        else
        if (collision.gameObject.tag == "Yellow ball")
        {
            CashWin(yellowKoef);
            Destroy(collision.gameObject);
        }

        Debug.Log(cash);
    }

    public void CashWin(float koef)
    {
        cash += koef * bet;

        float cashInt = Mathf.Floor(cash);
        float cashFraction = (cash - cashInt) * 100;
        string cashFrcStr;

        if (cashFraction < 10) 
            cashFrcStr = "0" + cashFraction;
        else
            cashFrcStr = cashFraction.ToString();

        cashText.text = cashInt + "." + cashFrcStr + " USD"; 
    }
}
