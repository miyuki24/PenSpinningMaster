using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoundController : MonoBehaviour
{
    //移動速度
    private float speed = -4.0f;
    //消滅位置
    private float deadline = -10.0f;
    private int point = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Vector3.right=1,0,0で初めから定義
        transform.Translate(Vector3.right * this.speed * Time.deltaTime);
        //画面外にでたら
        if(transform.position.x < this.deadline){
            Destroy(this.gameObject);
        }
    }
}
