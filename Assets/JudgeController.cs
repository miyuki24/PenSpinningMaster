using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class JudgeController : MonoBehaviour
{
    private bool isEnd = false;
    private GameObject pointText;
    private int point = 0;
    private GameObject round;
    private GameObject falseRound;
    // Start is called before the first frame update
    void Start()
    {
        //シーンからポイントテキストを取得
        this.pointText = GameObject.Find("pointText");
        this.round = GameObject.Find("round");
        this.falseRound = GameObject.Find("falseRound");
        Debug.Log("Start関数が呼ばれた");
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("Update関数が呼ばれた");
    }

    void OnTriggerEnter2D(Collider2D other){
        if(other.gameObject.tag == "roundTag"){
            if(Input.GetMouseButtonDown(0)){
                this.point += 10;
                this.pointText.GetComponent<Text>().text = this.point + "ポイント";
                Debug.Log(point);
            }
            Debug.Log("roundTagが呼ばれた");
        }else if(other.gameObject.tag == "falseRoundTag"){
            if(Input.GetMouseButtonDown(0)){
                this.isEnd = true;
            }
        }
        Debug.Log("onTriggerEnterが呼ばれた");
    }
}
