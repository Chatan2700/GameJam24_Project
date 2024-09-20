using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ReloadScene : MonoBehaviour
{

    [SerializeField] private string nextSceneName;
    public void reload()
    {
        SceneManager.LoadScene(nextSceneName);
        GameManagement.manager.resetCounter();
        
    }
}
