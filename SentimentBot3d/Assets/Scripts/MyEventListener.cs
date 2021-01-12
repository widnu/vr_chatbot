using UnityEngine;
using UnityEngine.EventSystems;
using Debug = UnityEngine.Debug;

public class MyEventListener : MonoBehaviour, IPointerClickHandler
{
    private float clickTime;            // time of last click
    private int clickCount=0;         // current click count
    public bool onClick = true;            // is click allowed on button?
    public bool onDoubleClick = false;    // is double-click allowed on button?
   
    public void OnPointerClick(PointerEventData data)
    {        
        // get interval between this click and the previous one (check for double click)
        float interval = data.clickTime - clickTime;
 
        // if this is double click, change click count
        if (interval < 0.5 && interval > 0 && clickCount != 2)
            clickCount = 2;
        else
            clickCount = 1;
 
        // reset click time
        clickTime = data.clickTime;
           
        // single click
        if (onClick && clickCount == 1)
        {
            Debug.Log("test onclick");

            Bot.Instance.SetBotResponseText("Requesting Conversation...");
            StartCoroutine(Bot.Instance.StartConversation());
        }
   
        // double click
        if (onDoubleClick && clickCount == 2)
        {
            Debug.Log("test ondoubleclick");
        }
    }
}