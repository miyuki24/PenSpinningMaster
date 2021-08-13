using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class RetrySceneController : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void GetDoButtonDown(){
        SceneManager.LoadScene("SampleScene");
    }
    public void GetDoNotButtonDown(){

    }
}
