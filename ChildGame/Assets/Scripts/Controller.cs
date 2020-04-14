using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public enum Colors { Red = 1, Green = 2, Blue = 3, Yellow = 4 };   
public class Controller : MonoBehaviour
{
    [SerializeField]
    private Answer _question;

    private Card _prevQuestion;

    [SerializeField] 
    private AnswerText _answerUI;

    [SerializeField]
    private Card[] _questions;
    [SerializeField]
    private Card[] _answersOptions;
    [SerializeField]
    private Answer[] _answers;

    private bool _isChosen;

    [SerializeField]
    private int _answersAmount;
    [SerializeField]
    private int _correctAnswersCount;
    private int _currentAnswerNumber;
    
    


    private void Start()
    {
        _currentAnswerNumber = 0;
        _correctAnswersCount = 0;
        _isChosen = false;
        GenerateQuestion();
    }

    private void GenerateQuestion()
    {
        _currentAnswerNumber++;
        _question.SetCard(GetRandomQuestion());
        GenerateAnswers();
    }
    
    private Card GetRandomQuestion()
    {
        Card result;
        do
        {
            result = _questions[Random.Range(0, _questions.Length)];
        } while (_prevQuestion == result);

        _prevQuestion = result;
   
        return result;
    }

    private void GenerateAnswers()
    {
        var addedQuestions = new LinkedList<Card>();
        int answerIndex = Random.Range(0, _answers.Length);
        
        foreach (var currentAnswer in _answers)
        {
            var generateAnswer = _answersOptions[Random.Range(0, _answersOptions.Length)];
            while (addedQuestions.Contains(generateAnswer))
            {
                generateAnswer = _answersOptions[Random.Range(0, _answersOptions.Length)];
            }
            currentAnswer.SetCard(generateAnswer);
            addedQuestions.AddLast(generateAnswer);
        }
    }

    public void ChooseAnswer(Answer answer)
    {
        if (answer == null || _isChosen)
        {
            return;
        }

        _isChosen = true;
        if (_question.GetCard().Color == answer.GetCard().Color)
        {
            _correctAnswersCount++;
        } 
        StartCoroutine(ShowText(_question.GetCard().Color == answer.GetCard().Color));
    }


    private IEnumerator ShowText(bool isCorrect = false)
    {
        _answerUI.SetText(isCorrect);
        yield return new WaitForSeconds(1.5f);
        _isChosen = false;
        _answerUI.DisableText();
        if (_currentAnswerNumber < _answersAmount)
        {
            GenerateQuestion();
        }
        else
        {
            
        }
    }

}
