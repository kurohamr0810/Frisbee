using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            int currentScenelndex = SceneManager.GetActiveScene().buildIndex;
            int nextSceneIndex = currentScenelndex + 1;


            if (nextSceneIndex == SceneManager.sceneCountInBuildSettings)
            {
                nextSceneIndex = 0;
            }

            SceneManager.LoadScene(nextSceneIndex);

        }


    }
}
