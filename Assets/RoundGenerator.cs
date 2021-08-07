using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoundGenerator : MonoBehaviour
{
    //Prefabを入れておく箱
    public GameObject roundPrefab;
    public GameObject falseRoundPrefab;
    //時間計測用の変数
    private float delta = 0;
    //円の生成間隔
    private float span = 0.5f;
    //円の生成位置（X座標）
    private float genPosX = 10.0f;
    //円の生成位置（Y座標）
    private float genPosY = 3.5f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        this.delta += Time.deltaTime;
        int num = Random.Range(1,11);
        if(this.delta > this.span){
            this.delta = 0;
            if(num <= 2){
                GameObject falseRound = Instantiate(falseRoundPrefab);
                falseRound.transform.position = new Vector2(this.genPosX, this.genPosY);
            }else if(num >= 3 && num <= 9){
                GameObject trueRound = Instantiate(roundPrefab);
                trueRound.transform.position = new Vector2(this.genPosX, this.genPosY);
            }
        }
    }
}
