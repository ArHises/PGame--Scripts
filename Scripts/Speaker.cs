using UnityEngine;

[CreateAssetMenu(fileName = "NewSpeaker", menuName = "Scriptable Objects/New Speaker")]
[System.Serializable]
public class Speaker : ScriptableObject
{
    public string speakerName;
    public Color textColor;
}
