using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ScenesManager : MonoBehaviour
{
    public new Camera camera;
    public Button backButton;
    public void GoRight(bool right)
    {
        float ScreenWidth = camera.aspect * camera.orthographicSize;
        if (right == true)
        {

            camera.transform.position = new(camera.transform.position.x + ScreenWidth * 2, camera.transform.position.y, -10);
        }
        else
        {
            camera.transform.position = new(camera.transform.position.x - ScreenWidth * 2, camera.transform.position.y, -10);
        }
        Debug.Log(camera.transform.position);
    }
    public void GoUp(bool up)
    {
        float ScreenHeight = 2f * camera.orthographicSize;
        if (up == true)
        {
            camera.transform.position = new(camera.transform.position.x, camera.transform.position.y + ScreenHeight, -10);
        }
        else
        {
            camera.transform.position = new(camera.transform.position.x, camera.transform.position.y - ScreenHeight, -10);
            backButton.gameObject.SetActive(false);
        }
        
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

    public void EnterGame()
    {
        SceneManager.LoadScene(1);
    }
}
