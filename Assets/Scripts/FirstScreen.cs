using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

#if UNITY_EDITOR
using UnityEditor;
#endif

public class FirstScreen : MonoBehaviour
{
    public InputField playerInput;
    public GameObject errorMessage;

    public void StartNew()
    {
        string playerName = "NoName";
        if (!playerInput.text.Equals("Enter your name..."))
        {
            //validate data
            if (ValidName(playerInput.text))
                playerName = playerInput.text;
            else
            {
                errorMessage.SetActive(true);
                return;
            }
        }
        SavedData.Instance.playerName = playerName;
        SceneManager.LoadScene(1);
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
