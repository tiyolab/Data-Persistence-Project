using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class HomeManager : MonoBehaviour
{
    public TextMeshProUGUI bestScoreText;
    public TMP_InputField nameInputField;

    void Start()
    {
        bestScoreText.text = "Best Score : " + SessionManager.Instance.playerBestScoreName + " : " + SessionManager.Instance.playerBestScore;
        nameInputField.text = SessionManager.Instance.playerName;
    }

    public void StartGame()
    {
        SessionManager.Instance.playerName = nameInputField.text;
        SessionManager.Instance.SavePlayerInfo();

        SceneManager.LoadScene(1);
    }

    public void QuitGame()
    {
        SessionManager.Instance.SaveBestScore();
        SessionManager.Instance.SavePlayerInfo();

#if UNITY_EDITOR
        UnityEditor.EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }

}
