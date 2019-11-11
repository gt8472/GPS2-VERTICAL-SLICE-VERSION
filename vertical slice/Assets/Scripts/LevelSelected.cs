using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSelected : MonoBehaviour
{
    public void Level1()
    {
        SceneManager.LoadScene(2);
    }
    public void Level2()
    {
        SceneManager.LoadScene(3);
    }
    public void BackToMainMenu()
    {
        SceneManager.LoadScene(0);
    }
}
