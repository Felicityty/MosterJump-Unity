using System.Collections;
using System.Collections.Generic;
using System.Net.Mime;
using UnityEngine;
using UnityEngine.UI;

public class showScore : MonoBehaviour
{
    [SerializeField] private Text coinText;
    
    // Start is called before the first frame update
    void Start()
    {
        coinText.text = "COINS: " + coin.Global.coinsNum; // 引用coin脚本中的变量
        coin.Global.coinsNum = 0; // 死亡后coin的个数清空
    }

}
