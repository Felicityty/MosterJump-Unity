using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class pauseMenu : MonoBehaviour
{
    public GameObject pause;

    [SerializeField] private bool menuKey = true; // 控制点击一次出现，再次点击隐藏的效果
    [SerializeField] private AudioSource audioS; // 同时需要控制背景音乐的暂停和播放

    // Update is called once per frame
    void Update()
    {
        if (menuKey)
        {
            if (Input.GetKeyDown(KeyCode.Space)) // 空格键
            {
                pause.SetActive(true); // pause出现
                menuKey = false;
                Time.timeScale = 0; // 时间暂停
                audioS.Pause(); // 音乐暂停
            }
        }
        else if (Input.GetKeyDown(KeyCode.Space))
        {
            pause.SetActive(false); 
            menuKey = true;
            Time.timeScale = 1; // 时间正常进行
            audioS.Play(); // 音乐继续
        }
    }
    
    // 返回游戏
    public void Return()
    {
        pause.SetActive(false); 
        menuKey = true;
        Time.timeScale = 1; // 时间正常进行
        audioS.Play(); // 音乐继续
    }
    
    // 重新开始
    public void Restart()
    {
        SceneManager.LoadScene(1);
        Time.timeScale = 1; // 时间正常进行
        coin.Global.coinsNum = 0; // 重新开始 coin的个数清空
    }
    
    // 退出游戏
    public void Exit()
    {
        SceneManager.LoadScene(0);
        coin.Global.coinsNum = 0; // 重新开始 coin的个数清空
    }
}
