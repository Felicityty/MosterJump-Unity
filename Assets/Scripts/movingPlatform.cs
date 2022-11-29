using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movingPlatform : MonoBehaviour
{
    // SerializeField 序列化 这样既保证是私有的 又可以在Inspector面板里操作
    [SerializeField] private GameObject[] points; // 可以添加数组
    [SerializeField] private float speed = 2f; // 移动速度

    private int ponitNum = 1; // 点的取值 默认目标点是end
    private float waitTime = 0.5f; // 加上等待时间

    // Update is called once per frame
    void Update()
    {
        // 从当前点到目标位置
        transform.position = Vector2.MoveTowards(transform.position, points[ponitNum].transform.position, speed * Time.deltaTime);

        // 快到目标点时，切换目标点，达到左右移动的效果
        if (Vector2.Distance(transform.position, points[ponitNum].transform.position) < 0.1f)
        {
            if (waitTime < 0)
            {
                ponitNum = 1 - ponitNum; // 0 和 1 之间转换
                waitTime = 0.5f;
            }
            else
            {
                waitTime -= Time.deltaTime;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            col.gameObject.transform.SetParent(transform); // moster就变成平台的孩子了，就可以跟着平台一起移动
        }
    }

    private void OnTriggerExit2D(Collider2D other) // 退出
    {
        if (other.gameObject.tag == "Player")
        {
            other.gameObject.transform.SetParent(null);
        }
    }
}
