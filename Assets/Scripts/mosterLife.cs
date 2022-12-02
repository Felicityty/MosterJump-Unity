using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; // 重新加载场景

// moster的生命 - 掉下去死亡
public class mosterLife : MonoBehaviour
{
    public GameObject sun;
    
    private AudioSource audioS;
    [SerializeField] AudioClip deadSound;

    private void Start()
    {
        audioS = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "deadLine")
        {
            audioS.clip = deadSound;
            audioS.Play();
            Invoke("DestorySun", 0.3f);
            Invoke("Restart", 0.2f);
        }
    }

    private void Restart() // 死亡后 调到end场景
    {
        SceneManager.LoadScene(4);
    }

    private void DestorySun()
    {
        Destroy(sun);
    }
}
