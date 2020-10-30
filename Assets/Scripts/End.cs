using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class End : MonoBehaviour
{
    public Text resultText;

    public GameManager gameManager;

    public void Start()
    {
        gameManager = FindObjectOfType<GameManager>(); //поиск сцены GameManager
        resultText.text = gameManager.countCurrAnswers + " / " + gameManager.questionsStep.Length;
        Destroy(gameManager.gameObject);
    }

    public void Restart()
    {
        SceneManager.LoadScene(0);   
    }
}
