using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 蹦床
public class springBed : MonoBehaviour
{
    public float jumpForce = 12f;
    
    Animator anim;

    private AudioSource audioS;
    [SerializeField] AudioClip springBedSound;
    
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        audioS = GetComponent<AudioSource>();
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        // 检测到Player触碰时，就触发jump的动画
        if (col.gameObject.tag == "Player")
        {
            audioS.clip = springBedSound;
            audioS.Play();
            anim.SetTrigger("jump");
            
            // Impulse是瞬间加上去的力
            col.gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
        }
    }
}
