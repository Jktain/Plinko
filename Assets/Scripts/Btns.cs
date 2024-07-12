using TMPro;
using UnityEngine;
using System.Globalization;
using System;

public class Btns : MonoBehaviour
{
    public TextMeshProUGUI hitCounterText;
    public TMP_InputField betInput;
    public void ResetCounter()
    {
        Target.hitCounter = 0;
        hitCounterText.text = "Number of hits: 0";
    }

    public void HelloWorld(string message)
    {
        Debug.Log(message);
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
            Target.bet = result;
            betInput.text = Target.MakeCashString(Target.bet);
        }
        else
        {
            Debug.LogError("Error while converting the value to the float type");
        }
    }
}
