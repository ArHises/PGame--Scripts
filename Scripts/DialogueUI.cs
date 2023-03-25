using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueUI : MonoBehaviour
{

    public DialogueScene currentDialogueScene;
    public TypewrittingEffect typewrittingEffect;
    public BackgroundController backgroundController;

    void Start() //START
    {
        typewrittingEffect.PlayScene(currentDialogueScene);
        backgroundController.SetImage(currentDialogueScene.background);
    }
    void Update() //UPDATE
    {
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0)) // Next Sentence by Pressing SPACE KEY
        {
            if (typewrittingEffect.IsCompleted())
            {
                if(typewrittingEffect.IsLastSentence())
                {
                    currentDialogueScene = currentDialogueScene.nextDialogueScene;
                    typewrittingEffect.PlayScene(currentDialogueScene);
                    backgroundController.SwitchImage(currentDialogueScene.background);
                }
                typewrittingEffect.PlayNextScene();
            }
            else
            {
                Debug.Log("End of sentences.");
            }
        }
    }
}
