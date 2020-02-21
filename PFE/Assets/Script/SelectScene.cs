using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class SelectScene : MonoBehaviour
{
    public void advanced_simple_artiste()
    {
        StaticClass.CrossSceneInformation = "artiste";
        SceneManager.LoadScene("advanced_rep_simple_size");
    }

    public void advanced_big_artiste()
    {
        StaticClass.CrossSceneInformation = "artiste";
        SceneManager.LoadScene("advanced_rep_big_size");
    }

    public void simple_simple_artiste()
    {
        StaticClass.CrossSceneInformation = "artiste";
        SceneManager.LoadScene("simple_rep_simple_size");
    }

    public void simple_big_artiste()
    {
        StaticClass.CrossSceneInformation = "artiste";
        SceneManager.LoadScene("simple_rep_big_size");
    }

    public void return_menu()
    {
        SceneManager.LoadScene("menu");
    }



        public void advanced_simple_spectateur()
    {
        StaticClass.CrossSceneInformation = "spectateur";
        SceneManager.LoadScene("advanced_rep_simple_size");
    }

    public void advanced_big_spectateur()
    {
        StaticClass.CrossSceneInformation = "spectateur";
        SceneManager.LoadScene("advanced_rep_big_size");
    }

    public void simple_simple_spectateur()
    {
        StaticClass.CrossSceneInformation = "spectateur";
        SceneManager.LoadScene("simple_rep_simple_size");
    }

    public void simple_big_spectateur()
    {
        StaticClass.CrossSceneInformation = "spectateur";
        SceneManager.LoadScene("simple_rep_big_size");
    }
}
