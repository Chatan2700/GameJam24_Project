using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TemporalBoundarie : MonoBehaviour
{
    [SerializeField] private GameObject temporalCollider;
    [SerializeField] private GameObject PuzzleToDesactivate;

    private void Start()
    {

        if (temporalCollider == null)
        {
            Debug.LogError("Temporal Collider no asignado.");
            return;
        }
    }

    private void Update()
    {
        if (GameManagement.manager != null)
        {
            int puzzleCompletedCounter = GameManagement.manager.GetPuzzleCounter();

            // Activar o desactivar el collider según el valor del contador
            if (puzzleCompletedCounter >= 1) // Ajusta la condición según tu lógica
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


}
