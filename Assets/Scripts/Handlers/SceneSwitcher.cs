using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitcher : MonoBehaviour
{
    public void GoToScene(string sceneName)
    {
        if (sceneName != "")
        {
            SceneManager.LoadScene(sceneName);
        }
        else
        {
            Debug.Log("Scene has not been set for this button");
        }
    }
}
