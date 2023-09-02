using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScenesManager : MonoBehaviour
{
    public Camera mainCamera;
    public float distanceFromCamera = 10f;
    
    public void ChangeScene(int index)
    {
        int sceneCount = SceneManager.sceneCount;
        for (int i = 0; i < sceneCount; i++)
        {
            UnityEngine.SceneManagement.Scene scene = SceneManager.GetSceneAt(i);
            Debug.Log("Checked Scene Name: " + scene.name);
            if (scene.name != "Canvas")
            {
                SceneManager.UnloadSceneAsync(scene.name);
            }
        }

        SceneManager.LoadScene(index, LoadSceneMode.Additive);


    }

    public void EnterGame()
    {
        SceneManager.LoadScene(0);
        SceneManager.LoadScene(2, LoadSceneMode.Additive);
    }
}
