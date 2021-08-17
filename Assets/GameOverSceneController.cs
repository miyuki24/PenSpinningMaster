using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverSceneController : MonoBehaviour
{
    private GameObject finalPointText;

    public JudgeController judgeController;
    // Start is called before the first frame update
    void Start()
    {
        this.finalPointText = GameObject.Find("finalPointText");
        this.finalPointText.GetComponent<Text>().text = judgeController.point + "ポイント";
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0)){
            SceneManager.LoadScene ("RetryScene");
        }
    }
}
