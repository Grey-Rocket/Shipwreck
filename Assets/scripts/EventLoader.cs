using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EventLoader : MonoBehaviour
{

    public Text eventText;
    public Canvas eventCanvas;

    // Start is called before the first frame update
    void Start()
    {
        eventText.text = "In the eye.In the eye.In the eye.In the eye.In the eye.In the eye." +
            "In the eye.In the eye.In the eye.In the eye.In the eye.In the eye.";
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
