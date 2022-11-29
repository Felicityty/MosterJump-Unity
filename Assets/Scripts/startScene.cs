using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// 返回场景一
public class startScene : MonoBehaviour
{
    public void StartMenu()
    {
        SceneManager.LoadScene(1);
        Time.timeScale = 1; // 时间正常进行
    }
}
