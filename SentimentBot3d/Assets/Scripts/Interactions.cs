using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.XR.WSA.Input;

public class Interactions : GazeInput
{

    /// <summary>
    /// Allows input recognition with the HoloLens
    /// </summary>
    private GestureRecognizer _gestureRecognizer;
    
    /// <summary>
    /// Called on initialization, after Awake
    /// </summary>
    internal override void Start()
    {
        base.Start();

        //Register the application to recognize HoloLens user inputs
        _gestureRecognizer = new GestureRecognizer();
        _gestureRecognizer.SetRecognizableGestures(GestureSettings.Tap);
        _gestureRecognizer.Tapped += GestureRecognizer_Tapped;
        _gestureRecognizer.StartCapturingGestures();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

/// <summary>
    /// Detects the User Tap Input
    /// </summary>
    private void GestureRecognizer_Tapped(TappedEventArgs obj)
    {
        // Ensure the bot is being gazed upon.
        if(base.FocusedObject != null)
        {
            // If the user is tapping on Bot and the Bot is ready to listen
            if (base.FocusedObject.name == "Bot" && Bot.Instance.botState == Bot.BotState.ReadyToListen)
            {
                // If a conversation has not started yet, request one
                if(Bot.Instance.conversationStarted)
                {
                    Bot.Instance.SetBotResponseText("Listening...");
                    Bot.Instance.StartCapturingAudio();
                }
                else
                {
                    Bot.Instance.SetBotResponseText("Requesting Conversation...");
                    StartCoroutine(Bot.Instance.StartConversation());
                }                                  
            }
        }
    }
}
