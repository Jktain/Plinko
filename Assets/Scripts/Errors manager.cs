using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ErrorsManager : MonoBehaviour
{
    public static void ShowErrorWindow(GameObject errorPanel, TextMeshProUGUI errorText, string error)
    {
        errorText.text = error;
        errorPanel.SetActive(true);
    }
}
