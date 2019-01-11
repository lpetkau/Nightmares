using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTrans : MonoBehaviour
{



    // Update is called once per frame

    public void Sceneload1()
    {
        SceneManager.LoadScene("Scale Model");
        Time.timeScale = 1f;
    }
    public void Sceneload2()
    {
        SceneManager.LoadScene("mAINmENu");

    }
    public void Sceneload3()
    {
        SceneManager.LoadScene("kidbedroom");
    }

    public void Sceneload4()
    {

        SceneManager.LoadScene("bathroom");


    }

    public void QuitGame()
    {
        Application.Quit();
    }

}