using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Mime;
using UnityEngine;
using UnityEngine.UI;

public class coin : MonoBehaviour
{
    // 全局变量 - 几个场景中都可以用
    public class Global
    {
        public static int coinsNum;
    }
    // private int coinsNum = 0;

    private AudioSource audioS; // 音效
    [SerializeField] AudioClip coinCollect;
    [SerializeField] private Text coinText; // 跟显示的Text绑定起来

    private void Start()
    {
        audioS = GetComponent<AudioSource>();
        coinText.text = "COINS: " + Global.coinsNum;
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("coins"))
        {
            audioS.clip = coinCollect;
            audioS.Play();
            Destroy(col.gameObject);
            Global.coinsNum++;
            Debug.Log("coins：" + Global.coinsNum);
            coinText.text = "COINS: " + Global.coinsNum;
        }
    }
}
