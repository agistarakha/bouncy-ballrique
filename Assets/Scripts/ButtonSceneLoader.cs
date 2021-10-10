using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButtonSceneLoader : MonoBehaviour
{

    private Button loadSceneButton;
    private Text buttonText;
    // Start is called before the first frame update
    void Start()
    {
        loadSceneButton = GetComponent<Button>();
        buttonText = GetComponentInChildren<Text>();
        buttonText.text = gameObject.name;
        loadSceneButton.onClick.AddListener(LoadProblemScene);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void LoadProblemScene()
    {
        SceneManager.LoadScene(gameObject.name);
    }
}
