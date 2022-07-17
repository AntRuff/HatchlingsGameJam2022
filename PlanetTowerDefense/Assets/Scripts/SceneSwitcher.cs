using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

public class SceneSwitcher : MonoBehaviour
{
    public int targetSceneIndex;

    public void loadNewScene()
    {
        Debug.Log("load new scene");
        SceneManager.LoadScene(targetSceneIndex);
    }
}
