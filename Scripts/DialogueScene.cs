using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewDialogueScene", menuName = "Scriptable Objects/New Dialogue Scene")]
public class DialogueScene : ScriptableObject
{
    public List<Sentence> sentences;
    public Sprite background;
    public DialogueScene nextDialogueScene;

    [System.Serializable]
    public struct Sentence
    {
        public Speaker speaker;
        [SerializeField] [TextArea] public string text;
    }
}
