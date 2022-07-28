using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

#if UNITY_EDITOR
using UnityEditor;
#endif

public class FirstScreen : MonoBehaviour
{
    public Text BestScoreText;
    public TMP_InputField PlayerNameInput;

    private void Start()
    {
        SavedData.Instance.LoadBestScoreData();

        BestScoreText.text = $"Best Score : {SavedData.Instance.BestScorePlayerName} : {SavedData.Instance.BestScore}";
    }
    public void StartNew()
    {
        SceneManager.LoadScene(1);
    }

    public void OnNameChanged()
    {
        if (SavedData.Instance != null)
        {
            SavedData.Instance.CurrentPlayerName = PlayerNameInput.text;
        }
    }

    public void Exit()
    {
    #if UNITY_EDITOR
        EditorApplication.ExitPlaymode(); //выход из приложения в редакторе юнити
    #else
        Application.Quit(); // после компил¤ции будет выполн¤тьс¤ эта строка
    #endif
    }

    public bool ValidName(string name)
    {
        return (name.Length > 1 && name.Length <= 20);
    }
}
