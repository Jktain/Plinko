using TMPro;
using UnityEngine;

public class Btns : MonoBehaviour
{
    public TextMeshProUGUI errorText;
    public TextMeshProUGUI hitCounterText;
    public TMP_InputField betInput;
    public TMP_InputField minCashLimitInput;
    public GameObject errorPanel;

    private void Start()
    {
        betInput.text = Target.MakeCashString(Target.bet);    
        minCashLimitInput.text = Target.MakeCashString(BallsSpawn.minCashLimit);
    }

    public void ResetCounter()
    {
        Target.hitCounter = 0;
        hitCounterText.text = "Number of hits: 0";
    }

    public void BetAcept(string bet)
    {
        if (float.TryParse(bet, out float result))
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
            ErrorsManager.ShowErrorWindow(errorPanel, errorText, "Error while converting the value to the float type");
        }
    }

    public void SetCashLimit(string enteredData)
    {
        if (float.TryParse(enteredData, out float limit))
        {
            if (limit < 0)
                ErrorsManager.ShowErrorWindow(errorPanel, errorText, "limit can`t be lower than 0");
            else
            if (limit > Target.totalCash)
                ErrorsManager.ShowErrorWindow(errorPanel, errorText, "limit can`t be higher than your current cash");
            else
                BallsSpawn.minCashLimit = limit;

            minCashLimitInput.text = Target.MakeCashString(BallsSpawn.minCashLimit);
        }
        else
        {
            ErrorsManager.ShowErrorWindow(errorPanel, errorText, "Error while converting the value to the float type");
        }
    }
}
