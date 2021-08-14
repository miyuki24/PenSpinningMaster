using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissingController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerStay2D(Collider2D other){
        JudgeController judgeController = new JudgeController();
        if(other.gameObject.tag == "roundTag"){
            judgeController.missCount += 1;
            if(judgeController.missCount == 3){
                judgeController.isGameOver = true;
            }
            judgeController.MissCount();
        }
    }
}
