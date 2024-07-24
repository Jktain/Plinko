using UnityEngine;
using UnityEngine.UI;

public class TogglesManager : MonoBehaviour
{
    public Toggle[] toggles = new Toggle[6];

    public static int ballsCount;

    //public void ChooseToggle(bool numberOfToggle)
    //{
    //    for(int i = 0; i < togles.Length; i++)
    //    {
    //        togles[i].isOn = true;
    //    }

    //    //togles[numberOfToggle].isOn = false;
    //}

    public void ChooseToggle(int numberOfToggle)
    {
        for (int i = 0; i < toggles.Length; i++)
        {
            if(i == numberOfToggle)
                toggles[i].isOn = false;
            else
                toggles[i].isOn = true;
        }

        switch (numberOfToggle)
        {
            case 0:
                ballsCount = 3; 
                break;
            case 1:
                ballsCount = 5;
                break;
            case 2: 
                ballsCount = 10; 
                break;
            case 3:
                ballsCount = 25;
                break;
            case 4:
                ballsCount = 50;
                break;
            case 5:
                ballsCount = 100;
                break;
        }
    }
}
