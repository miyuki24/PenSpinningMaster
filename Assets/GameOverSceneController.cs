using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverSceneController : MonoBehaviour
{
    //private GameObject finalPointText;

    //public JudgeController judgeController;
    // Start is called before the first frame update
    void Start()
    {
        //this.judgeController = GameObject.FindGameObjectsWithTag("judgeController");
        //this.finalPointText = GameObject.Find("finalPointText");
        //this.finalPointText.GetComponent<Text>().text = judgeController.point + "ポイント";
        Invoke("GetRetryScene",1.5f);
    }

    // Update is called once per frame
    void Update()
    {
    }

    void GetRetryScene(){
        SceneManager.LoadScene ("RetryScene");
    }
}

