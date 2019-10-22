using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BreuLevelController : MonoBehaviour
{
    #region Load Levels
    public void loadLevel2()
    {
        SceneManager.LoadScene("BreuScene02", LoadSceneMode.Single);
    }
    public void loadLevel3()
    {
        SceneManager.LoadScene("BreuScene03", LoadSceneMode.Single);
    }
    public void loadLevel4()
    {
        SceneManager.LoadScene("BreuScene04", LoadSceneMode.Single);
    }
    public void loadLevel5()
    {
        SceneManager.LoadScene("BreuScene05-North", LoadSceneMode.Single);
    }
    public void loadLevel6()
    {
        SceneManager.LoadScene("BreuScene06-West", LoadSceneMode.Single);
    }
    public void loadLevel7()
    {
        SceneManager.LoadScene("BreuScene07-South", LoadSceneMode.Single);
    }
    public void loadLevel8()
    {
        SceneManager.LoadScene("BreuScene08-East", LoadSceneMode.Single);
    }
    public void loadLevel9()
    {
        SceneManager.LoadScene("BreuScene09-Floor", LoadSceneMode.Single);
    }
    public void loadLevel10()
    {
        SceneManager.LoadScene("BreuScene10-Ceiling", LoadSceneMode.Single);
    }
    public void loadLevel11()
    {
        SceneManager.LoadScene("BreuSceneEnd", LoadSceneMode.Single);
    }


    #endregion
}
