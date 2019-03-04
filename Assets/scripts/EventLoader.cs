using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EventLoader : MonoBehaviour
{

    public Text eventText;
    public Canvas eventCanvas;
    public Event currentEvent;

    public Button button1;
    public Button button2;
    public Button button3;

    // Start is called before the first frame update
    void Start()
    {
        eventText.text = currentEvent.text;
    
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
