using System.Collections;
using System.Collections.Generic;
using System.Net.Http.Headers;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class GameManagement : MonoBehaviour
{
    public static GameManagement manager;
    //public GameObject panel;
    int sceneNum;
    int counter;
    [SerializeField] int puzzles;
    [SerializeField] private int Doorkey;
    [SerializeField] private int FinalEventKey;
    [SerializeField] public bool PuzzledCompleted_1 = false;
    [SerializeField] public bool PuzzledCompleted_4 = false;


    private void Awake()
    {
        if (manager == null)
        {
            manager = this;
            DontDestroyOnLoad(this);
        }
        else if (manager != this)
        {
            Destroy(gameObject);
        }
    }
    void Start()
    {

    }

    void Update()
    {
        
    }


    public void TriggerOff(GameObject obj, EventTriggerType eventType)
    {
        EventTrigger trigger = obj.GetComponent<EventTrigger>();

        if (trigger == null)
        {
            Debug.Log("No Trigger Found");
            return;
        }

        for (int i = trigger.triggers.Count - 1; i >= 0; i--)
        {
            if (trigger.triggers[i].eventID == eventType)
            {
                trigger.triggers.RemoveAt(i);
                break;
            }
        }
    }

    public void PuzzleCounter(int newCounter)
    {
        counter += newCounter;
        Debug.Log("Puzzles Resolve: " + counter);

        // Conditions for change scene
        switch (sceneNum) // ID del puzzle en Build settings
        {
            case 0: // Bedroom Puzzle
                if (counter>=6)
                {
                    Debug.Log("Puzzle Completed");
                    PuzzledCompleted_1 = true;
                    puzzleCompleted();
                    //panel.SetActive(true);
                    // SceneManager.LoadScene(0);
                }
                break;
            case 1: // Bathroom Puzzle //Pending
                if (counter >= 2)
                {
                    Debug.Log("Puzzle Completed");
                    puzzleCompleted();
                    //NextScene(); // reemplazar con metodo de cambio de escena
                }
                break;
        }

    }

    void puzzleCompleted()
    {
        puzzles++;
        resetCounter();
    }

    public void resetCounter()
    {
        counter = 0;
    }

    public int GetPuzzleCounter()
    {
        return puzzles;
    }

    public void PickupDoorkey()
    {
        Doorkey++;
    }
    public void UseDoorkey()
    {
        Doorkey = 0;
        Debug.Log("Used Door Key");
    }
    public int GetPickupDoorkeyCounter()
    {
        return Doorkey;
    }

    public void PickupFinalEventKey()
    {
        FinalEventKey++;
    }
    public void UseFinalEventKey()
    {
        FinalEventKey = 0;
        Debug.Log("Used FinalEvent Key");
    }
    public int GetPickupFinalEventKey()
    {
        return FinalEventKey; // me devuelve el contador de FInalEventKey
    }

    public bool GetPuzzledCompleted_1()
    {
        return PuzzledCompleted_1;
    }

    


    // when puzzles = x number change music and conditions in scene
    /*
    void puzzleCondition()
    {
        if (puzzles >=2)
        {
            ColliderDePuerta.setActive(false);
            cambiarMusica();
        }

        if (puzzles >=4)
        {
            AbrirPuertaOficina;
            cambiarMusica();
        }

        switch(sceneNum) // escenas de los cuartos
        {
            case 0:
                {
                    if (puzzles < 1 && QuiereSalirDelCuarto)
                    {
                        Mostrardialogo("Deberia arreglar la mesa de noche");
                    }

                    if (puzzles < 2 && QuiereSalirDelCuarto)
                    {
                        Mostrardialogo("Debo ir al baño primero");
                    }

                    break;
                }

            case 1: // Corredores, Cocina y Sala
            case 2:
            case 3:
                {
                    if (puzzles < 3 && tieneLlave && QuiereAbrirOficina)
                    {
                        MostrarDialogo("Tengo que ir a la cocina");
                    }
                    else if (puzzles < 3 && !tieneLlave && QuiereAbrirOficina)
                    {
                        MostrarDialogo("Esta cerrado, tal vez dejo la llave en la sala");
                    }
                    break;

                    
                }
        }
    }
    */

}
