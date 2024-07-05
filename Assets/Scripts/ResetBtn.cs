using TMPro;
using UnityEngine;
using System.Globalization; 

public class Btns : MonoBehaviour
{
    public TextMeshProUGUI hitCounterText;
    public TMP_InputField betInput;
    public void ResetCounter()
    {
        Mishenes.hitCounter = 0;
        hitCounterText.text = "Number of hits: 0";
    }

    public void BetAcept()
    {
        if (float.TryParse(betInput.text, NumberStyles.Float, CultureInfo.InvariantCulture, out float result))
        {
            if (result < 0.10f)
                result = 0.10f;
            else
            if (result > 100f)
                result = 100f;
            Mishenes.bet = result;
            betInput.text = Mishenes.CashString(Mishenes.bet);
        }
        else
        {
            Debug.LogError("Не вдалося перетворити введене значення у float.");
        }
    }
}
