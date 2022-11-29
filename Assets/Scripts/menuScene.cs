using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// 返回首页
public class menuScene : MonoBehaviour
{
    public void backToMenu()
    {
        SceneManager.LoadScene(0);
    }
}
