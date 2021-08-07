using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PenController : MonoBehaviour
{
    //ペンの回転速度
    private float rotSpeed = 1.0f;
    private float highestAngleZ = 0;
    // Start is called before the first frame update
    void Start()
    {
        //初めの角度は45度
        this.transform.Rotate(0,0,45);
    }

    // Update is called once per frame
    void Update()
    {
        //一回転しているかどうか調べる。
        bool isRotation = (this.transform.eulerAngles.z > highestAngleZ)? true : false;
        //ボタンが押された時、フラグを立てて一回転させる。一周したらフラグをオフにする。ボタンが押されたら回転させるためにtrue。trueの間に回転させる処理をし続ける。その間の回転の上限を定めておいて、それを超えたら止める
        if(Input.GetMouseButtonDown(0) && isRotation){
            this.transform.Rotate(0,0,this.rotSpeed);
            highestAngleZ = this.transform.eulerAngles.z;
        }
    }
}
