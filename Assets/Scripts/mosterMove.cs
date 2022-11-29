using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mosterMove : MonoBehaviour
{
    Rigidbody2D rb;

    AudioSource audioS; // 音效
    public AudioClip jumpSound;

    // 速度 public就可以在面板上显示出来
    public float mosterSpeed = 5f;
    // 范围标签
    [Range(1, 10)]
    public float jumpSpeed = 5f;

    public bool isGrounded; // 判断是否已经在地面上了
    public Transform groundCheck; // 拿到地面检测
    public LayerMask ground; // 检测地面的layer
    
    public float fallAddition = 3.5f; // 下落的重力加成
    public float jumpAddition = 1.5f; // 起跳的重力加成

    private float moveX; // 移动输入
    private float moveJump; // 跳跃输入

    private bool isJump; // 跳跃状态

    // Start is called before the first frame update
    void Start()
    {
        // 实例化 获取到Rigidbody2D的组件
        rb = GetComponent<Rigidbody2D>();
        audioS = GetComponent<AudioSource>();
    }

    // Update is called once per frame 每帧都调用
    void Update()
    {
        // 获取a，d输入的x轴变化  GetAxisRaw() -> -1,0,1
        // Edit -> Project Setting -> Input Manager
        moveX = Input.GetAxisRaw("Horizontal");
        moveJump = Input.GetAxisRaw("Vertical");

        if (moveJump == 1 && isGrounded)
        {
            rb.velocity = Vector2.up * jumpSpeed;
            isJump = true;
        }
    }
    
    // 物理的固定帧 0.02秒每帧
    private void FixedUpdate()
    {
        // OverlapCircle的参数 (检测点，检测半径，所在图层)
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, 0.1f, ground);
        Move();
        Jump();
    }
    
    // 移动
    private void Move()
    {
       // 获取方向*速度
        rb.velocity = new Vector2(moveX*mosterSpeed, rb.velocity.y);

        if (moveX != 0)
        {
            // 根据向左还是向右的，控制scale的正负，就可以改变moster的朝向
            transform.localScale = new Vector3(moveX, 1, 1);
        }
    }

    // 跳跃
    private void Jump()
    {
        // 这样的话音效就一遍
        if (isJump)
        {
            audioS.clip = jumpSound;
            audioS.Play();
            isJump = false;
        }
        
        // 让跳跃更自然
        if (rb.velocity.y < 0) // 在下落过程中
        {
            // 加成了3.5倍的重力
            rb.velocity += Vector2.up * (Physics2D.gravity.y * (fallAddition-1) * Time.fixedDeltaTime);
        }
        else if (rb.velocity.y > 0)
        {
            rb.velocity += Vector2.up * (Physics2D.gravity.y * (jumpAddition-1) * Time.fixedDeltaTime);
        }
    }
}
