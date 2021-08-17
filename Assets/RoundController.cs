using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoundController : MonoBehaviour
{
    //消滅位置。変数をpublicか関数を作るか
    private float deadline = -10.0f; 
    
    //public GameManager gameManager;
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(speed);
        //Vector3.right=1,0,0で初めから定義されている。X軸の値だけを簡単に動かせる
        transform.Translate(Vector3.right * speed * Time.deltaTime);
        //画面外にでたら
        if(transform.position.x < this.deadline){
            Destroy(this.gameObject);
        }
    }
}
