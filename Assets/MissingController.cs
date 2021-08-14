using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissingController : MonoBehaviour
{
    public JudgeController judgeController;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other){
        if(other.gameObject.tag == "roundTag"){
            judgeController.missCount += 1;
            if(judgeController.missCount == 3){
                judgeController.isGameOver = true;
            }
            judgeController.MissCount();
        }
    }
}
