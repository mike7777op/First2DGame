using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class TitleControl : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void GameStart()
    {
        print("GameStart");
        //跳轉到遊戲
        //新方式
        SceneManager.LoadScene("game");

        //舊方式
        // Application.LoadLevel("game");
        //bulidsetting裡的index
        // Application.LoadLevel(1);


    }
}
