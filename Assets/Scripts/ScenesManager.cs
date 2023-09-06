using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScenesManager : MonoBehaviour
{
    public new Camera camera;
    public void ChangeScene(bool right)

    {
        Debug.Log(camera.transform.position);
        float ScreenWidth = camera.aspect * camera.orthographicSize;
        if (right == true)
        {

            camera.transform.position = new(camera.transform.position.x + ScreenWidth*2, camera.transform.position.y, -10);
        }
        else
        {
            camera.transform.position = new(camera.transform.position.x - ScreenWidth*2, camera.transform.position.y, -10);
        }
        /* int sceneCount = SceneManager.sceneCount;
        for (int i = 0; i < sceneCount; i++)
        {
            UnityEngine.SceneManagement.Scene scene = SceneManager.GetSceneAt(i);
            //Debug.Log("Checked Scene Name: " + scene.name);
            if (scene.name != "Canvas")
            {
                SceneManager.UnloadSceneAsync(scene.name);
            }
        }

        SceneManager.LoadScene(index, LoadSceneMode.Additive); */
    }

    public void EnterGame()
    {
        SceneManager.LoadScene(0);
        SceneManager.LoadScene(2, LoadSceneMode.Additive);
    }
}
