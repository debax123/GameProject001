using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Loader : MonoBehaviour
{
    public string sceneName;

    public void Load()
    {
        SceneManager.LoadScene(sceneName);
    }
}
