using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AnswerText : MonoBehaviour
{
    [SerializeField]
    private Text _answerText;

    private const string correctText = "ПРАВИЛЬНО!";
    private const string wrongText = "НЕПРАВИЛЬНО!";

    
    public void SetText(bool isCorrect = false)
    {
        _answerText.enabled = true;
        if (isCorrect)
        {
            _answerText.color = Color.green;
            _answerText.text = correctText;
        }
        else
        {
            _answerText.color = Color.red;
            _answerText.text = wrongText;
        }
    }


    public void DisableText()
    {
        _answerText.enabled = false;
    }
}
