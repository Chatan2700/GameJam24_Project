using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public int keyCount; // Cuantas llaves tiene el jugador
   // [SerializeField] private bool keyHold; // Comprueba si tiene una llave el jugador


    public void PickupKey()
    {
        keyCount++; 
       // keyHold = true;
    }

}
