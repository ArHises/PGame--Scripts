using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TypewrittingEffect : MonoBehaviour
{
    [SerializeField] private float delay = 0.1f;

    public TextMeshProUGUI nameText;
    public TextMeshProUGUI typpingText;

    private DialogueScene currentDialogueScene;
    private int currentSentenceIndex = 0;
    private string currentSentence = "";
    private bool status = false;

    public void PlayScene(DialogueScene scene) // START
    {
        currentDialogueScene = scene;
        currentSentenceIndex = 0;
        PlayNextScene();
    }
    public void PlayNextScene()
    {
        if (currentSentenceIndex < currentDialogueScene.sentences.Count)
        {
            ShowCurrentSentence();
        }
        else
        {
            Debug.Log("End of sentences.");
        }
        currentSentenceIndex++;
    }
    public bool IsLastSentence()
    {
        return currentSentenceIndex == currentDialogueScene.sentences.Count;
    }
    public bool IsCompleted()
    {
        return !status;
    }
    private void ShowCurrentSentence()
    {
        currentSentence = currentDialogueScene.sentences[currentSentenceIndex].text;
        StartCoroutine(TypeSentence(currentSentence));

        // Set speaker's name and text color
        nameText.text = currentDialogueScene.sentences[currentSentenceIndex].speaker.speakerName;
        nameText.color = currentDialogueScene.sentences[currentSentenceIndex].speaker.textColor;
    }
    
    private IEnumerator TypeSentence(string sentence)
    {
        status = true;
        typpingText.text = "";

        for (int i = 0; i <= sentence.Length; i++)
        {
            string currentText = sentence.Substring(0, i);
            typpingText.text = currentText;
            yield return new WaitForSeconds(delay / 2);
        }
        status = false;
    }
}
