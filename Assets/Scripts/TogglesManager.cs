using UnityEngine;
using UnityEngine.UI;

public class TogglesManager : MonoBehaviour
{
    public Toggle[] togles = new Toggle[6];

    public void ChooseToggle(bool numberOfToggle)
    {
        for(int i = 0; i < togles.Length; i++)
        {
            togles[i].isOn = true;
        }

        //togles[numberOfToggle].isOn = false;
    }
}
