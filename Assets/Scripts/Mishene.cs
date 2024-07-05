using UnityEngine;
using System.Collections;
using TMPro;
using UnityEngine.UI;

public class Mishenes : MonoBehaviour
{
    public static float totalCash = 3000f;
    public static float bet = 5f;

    public TextMeshProUGUI totalCashText;
    public TextMeshProUGUI winCashText;
    public GameObject winCashObj;

    public float greenKoef;
    public float yellowKoef;
    public float redKoef;

    private float winCash;
    private Image winCashImage;

    private void Start()
    {
        winCashImage = winCashObj.GetComponent<Image>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Green ball")
        {
            CashCalculating(greenKoef, new Color(0, 0.586f, 0));
            Destroy(collision.gameObject);
        }
        else
        if (collision.gameObject.tag == "Red ball")
        {
            CashCalculating(redKoef, new Color(255, 0, 0));
            Destroy(collision.gameObject);
        }
        else
        if (collision.gameObject.tag == "Yellow ball")
        {
            CashCalculating(yellowKoef, new Color(0.67f, 0.67f, 0));
            Destroy(collision.gameObject);
        }

        if(winCash > 0)
        {
            StopCoroutine(WinCashCoroutine());
            winCashObj.SetActive(true);
            StartCoroutine(WinCashCoroutine());
        }
    }

    private IEnumerator WinCashCoroutine()
    {
        yield return new WaitForSeconds(1f);
        winCashObj.SetActive(false);
    }

    public void CashCalculating(float koef, Color winColor)
    {
        winCash = bet * koef;
        totalCash += winCash;

        winCashText.text = "+" + CashString(winCash);
        totalCashText.text = CashString(totalCash);
        winCashImage.color = winColor;
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
