using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(menuName ="Questions")]
public class Question : ScriptableObject
{
    public string contentText;
    public string[] answers;
    public int correctAnswer;
}
