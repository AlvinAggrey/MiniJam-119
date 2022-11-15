using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChangeButton : MonoBehaviour
{
    [SerializeField] int sceneNumber = 0;
    public void LoadScene()
    {
        SceneManager.LoadScene(sceneNumber);
    }
}
