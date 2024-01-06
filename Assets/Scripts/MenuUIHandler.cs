using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
#if UNITY_EDITOR
using UnityEditor; // UnityEditor 네임스페이스를 추가합니다.
#endif

public class MenuUIHandler : MonoBehaviour
{
    public TMP_InputField nameInputField;
    public TMP_Text bestScoreText;

    // Start is called before the first frame update

    void Start()
    {
        bestScoreText.text = "Best Score: " + PlayerDataManager.Instance.playerData.highScore;
    }

    public void StartGame()
    {
        if (nameInputField != null && PlayerDataManager.Instance != null)
        {
            PlayerDataManager.Instance.SetPlayerName(nameInputField.text);
        }

        // // 메인 게임 씬 로드
        SceneManager.LoadScene("main");
    }

    public void ExitGame()
    {
#if UNITY_EDITOR
        // Unity 에디터에서 실행 중일 경우, 에디터 플레이 모드를 종료합니다.
        EditorApplication.isPlaying = false;
#else
        // 빌드된 게임에서 실행 중일 경우, 게임을 종료합니다.
        Application.Quit();
#endif
    }

}

