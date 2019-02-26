using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerResources : MonoBehaviour
{
    public int crew;
    public int morale;
    public int food;

    public Text crewText;
    public Text moraleText;
    public Text foodText;

    void Start()
    {
        crewText.text = "x" + crew;
        moraleText.text = morale + "%";
        foodText.text = "x" + food;
    }
}
