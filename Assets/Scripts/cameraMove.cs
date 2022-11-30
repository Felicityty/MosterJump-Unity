using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// camera的自移动
public class cameraMove : MonoBehaviour
{
    public Transform target;
    // public float smoothing;
    
    // public Vector2 minPosition;
    // public Vector2 maxPosition;

    // private void LateUpdate()
    // {
    //     Vector3 targetPos = target.position;
    //     targetPos.x = Mathf.Clamp(targetPos.x, targetPos.x-2, 50);
    //     // targetPos.y = Mathf.Clamp(targetPos.y, 0, 5);
    //     transform.position = Vector3.Lerp(transform.position, targetPos, smoothing);
    // }

    // Update is called once per frame
    void Update()
    {
        // Debug.Log("mosterPosition" + target.position.x); // 获取moster的位置
        // Debug.Log("cameraPosition" + transform.localPosition.x); // 获取camera的位置
        if (transform.localPosition.x - target.position.x < 9.4)
        {
            if (transform.localPosition.x > 41.8)
            {
                // Debug.Log(333);
                // moster速度过快 需提高camera运动的速度
                var location = 0f * Time.deltaTime;
                transform.Translate(location, 0, 0);
            }
            else if (transform.localPosition.x - target.position.x < -5)
            {
                // Debug.Log(222);
                // moster速度过快 需提高camera运动的速度
                var location = 3f * Time.deltaTime;
                transform.Translate(location, 0, 0);
            }
            else if (transform.localPosition.x - target.position.x < -3)
            {
                // Debug.Log(111);
                // moster速度过快 需提高camera运动的速度
                var location = 2f * Time.deltaTime;
                transform.Translate(location, 0, 0);
            }
            else
            {
                // Debug.Log(000);
                // moster能跟得上camera的运动速度
                var location = 0.8f * Time.deltaTime;
                transform.Translate(location, 0, 0);
            }
        }
        else
        {
            // 跟不上
            Invoke("Restart", 0.1f);
        }
    }
    
    private void Restart() // 跟不上camera后 跳转到end场景
    {
        SceneManager.LoadScene(4);
    }
}
