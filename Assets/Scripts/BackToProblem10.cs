using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BackToProblem10 : MonoBehaviour
{
    private Button backButton;
    // Start is called before the first frame update
    void Start()
    {
        backButton = GetComponent<Button>();
        backButton.onClick.AddListener(Back);
    }

    private void Back()
    {
        ScoreManager.score = 0;
        SceneManager.LoadScene("Problem 10");
    }

    // Update is called once per frame
    void Update()
    {

    }
}
