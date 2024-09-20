using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinalEvent_SceneInteractable : MonoBehaviour
{
    [SerializeField] private string SceneName;
    [SerializeField] private GameObject temporalCollider;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(GameManagement.manager != null)
        {
            int FinalEventKey = GameManagement.manager.GetPickupFinalEventKey();

            if (FinalEventKey >= 2)
            {
                temporalCollider.SetActive(false); // Desactiva el collider

            }
            else
            {
                temporalCollider.SetActive(true); // Activa el collider si no se ha cumplido la condición
            }
        }
        else
        {
            Debug.LogError("GameManager no encontrado.");
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Debug.Log("Load Nightstand Puzzle...");
            SceneManager.LoadScene(SceneName);
        }
    }

}
