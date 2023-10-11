using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ToMain : MonoBehaviour
{
    public string SceneToLoad;


    public void ToNext()
    {   
        SceneManager.LoadScene(SceneToLoad);       
    }
}
