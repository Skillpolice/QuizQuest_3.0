using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor.SceneManagement;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    [Header("Questions Steps")]
    public Question[] questionsStep;
    public int countCurrAnswers = 0;
    public int countHealth = 3;
    private int currentQuestIndex;

    [Header("Text")]
    public Text questionText;
    public Text[] answersTexts;

    [Header("UI elements")]
    public Button[] buttons;

    void Start()
    {
        currentQuestIndex = 0;
        countCurrAnswers = 0;
        countHealth = 3;

        DontDestroyOnLoad(gameObject);
        ShowAnswers();
    }

    public void CheckButtonAnswers(int index)
    {
        if (index == questionsStep[currentQuestIndex].correctAnswer)
        {
            
            print("Yes");
            countCurrAnswers++;
        }
        else
        {
            
            print("No");
            countHealth--;
        }
        currentQuestIndex++;


        //проаверка index и переход на следующую сцену
        int maxIndex = questionsStep.Length -1;
        if (currentQuestIndex > maxIndex || countHealth <= 0)
        {
            SceneManager.LoadScene(1);
            return;
        }
        ShowAnswers();
    }

    public void FiftyFifty()
    {
        int currectAnswer = questionsStep[currentQuestIndex].correctAnswer;
        int countBttn = 0;

        for (int i = 0; i < buttons.Length; i++)
        {
            if (currectAnswer != i)
            {
                buttons[i].gameObject.SetActive(false);
                countBttn++;
                if(countBttn >= 2)
                {
                    return;
                }
            }
        }

    }

    public void ShowAnswers()
    {
        questionText.text = questionsStep[currentQuestIndex].contentText;

        for (int i = 0; i < buttons.Length; i++)
        {
            buttons[i].gameObject.SetActive(true);
        }

        for (int i = 0; i < answersTexts.Length; i++)
        {
            //int rand = Random.Range(0, answersTexts.Count);
            answersTexts[i].text = questionsStep[currentQuestIndex].answers[i];

        }

    }

}
