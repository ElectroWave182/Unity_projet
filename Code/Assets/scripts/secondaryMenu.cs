using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class secondaryMenu : MonoBehaviour
{
    public TMP_InputField inputField1;
    public TMP_InputField inputField2;
    public Button playButton;
    public string nextSceneName = "Urban_Pulse";
    // Start is called before the first frame update
    void Start()
    {
        playButton.onClick.AddListener(OnPlayButtonClicked);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnPlayButtonClicked()
    {
        string value1 = inputField1.text;
        string value2 = inputField2.text;

        if (string.IsNullOrEmpty(value1) || string.IsNullOrEmpty(value2))
        {
            
            
            return; 
        }

        PlayerPrefs.SetString("InputField1Value", value1);
        PlayerPrefs.SetString("InputField2Value", value2);
        PlayerPrefs.Save();
        SceneManager.LoadScene(nextSceneName);
    }
}
