using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PenController : MonoBehaviour
{
    //ペンの回転速度
    private float rotSpeed = 5.0f;
    private float highestAngleZ = 0;
    private bool isRotation = false;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //ボタンが押されたらフラグが立つ
        if(Input.GetMouseButtonDown(0)){
            isRotation = true;
        }
        //フラグが立っている時、eulerAngles.zの最高値を更新する。highestAngelZが360になるまで続ける
        if(this.transform.eulerAngles.z > highestAngleZ && isRotation == true){
            highestAngleZ = this.transform.eulerAngles.z;
        }
        //フラグが立っていて、highestAngelZ・eulerAngles.zが共に360以下の時(一周していない時)
        if(this.transform.eulerAngles.z == highestAngleZ && isRotation == true){
            this.transform.Rotate(0,0,this.rotSpeed);
        //一周したら(eulerAngles.z = 0になったら)
        }else{
            isRotation = false;
            this.highestAngleZ = 0;
            this.transform.eulerAngles = Vector3.zero;
        }
    }
}