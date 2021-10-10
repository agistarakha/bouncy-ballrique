using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverManager : MonoBehaviour
{
    public static GameOverManager _instance = null;
    public static GameOverManager Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<GameOverManager>();
            }
            return _instance;
        }
    }

    public GameObject gameOverPanel;
    public Button restartButton;
    public bool isGameOver;
    // Start is called before the first frame update
    void Start()
    {
        isGameOver = false;
        // restartButton = gameOverPanel.GetComponentInChildren<Button>();
        // restartButton.onClick.AddListener(Restart);
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void ShowGameOverUI()
    {
        gameOverPanel.SetActive(true);
        StartCoroutine(RestartScene());
    }

    IEnumerator RestartScene()
    {
        yield return new WaitForSeconds(2);
        ScoreManager.score = 0;
        SceneManager.LoadScene("Problem 9");
    }



}
