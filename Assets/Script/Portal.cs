using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Portal : MonoBehaviour
{
    public string scenceName;
    // Start is called before the first frame update
    void Start()
    {
        this.transform.tag = "Portal";
    }

    //¶Ç°e³õ´º
    public void ChangeScence()
    {
        SceneManager.LoadScene(scenceName);
    }
}
