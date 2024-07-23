using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class CountOfBallsManager : MonoBehaviour
{
    public ToggleGroup roundsToggleGroup;

    public void ApplySelections()
    {
        Toggle selectedToggle = roundsToggleGroup.ActiveToggles().FirstOrDefault();

        if (selectedToggle != null)
        {
            Debug.Log("Selected rounds: " + selectedToggle.GetComponentInChildren<Text>().text);
        }
    }
}
