using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 木块
public class brick : MonoBehaviour
{
    public Transform ceilingCheck; // 天花板检测
    public LayerMask ground;
    public bool isCeilingCol; // 天花板触碰
    
    // 全局变量 - 几个场景中都可以用
    public class Global
    {
        public static int brickNum;
    }
    // private int brickNum = 0;

    private AudioSource audioS; // 音效
    [SerializeField] AudioClip brickBreak;
    
    private void Start()
    {
        audioS = GetComponent<AudioSource>();
    }
    
    private void FixedUpdate()
    {
        isCeilingCol = Physics2D.OverlapCircle(ceilingCheck.position, 0.1f, ground);
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("brick") && isCeilingCol)
        {
            audioS.clip = brickBreak;
            audioS.Play();
            Destroy(col.gameObject);
            Global.brickNum++;
            Debug.Log("bricks：" + Global.brickNum);
        }
    }
}
