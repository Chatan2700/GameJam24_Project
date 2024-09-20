using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class InspectItem : MonoBehaviour
{
    public GameObject imagen;
    public GameObject mainItem;
    public string objectNameToCheck; // Nombre del objeto a verificar
    GameObject bg;
    bool isActive = false;

    public void OnPointerClick()
    {
        // Activa la imagen
        Debug.Log("Primera fase");
        imagen.SetActive(true);
        bg = GameObject.FindGameObjectWithTag("BG");
        bg.GetComponent<Image>().color = Color.gray;

        GameManagement.manager.PickupDoorkey();
        GameManagement.manager.PickupFinalEventKey();

        Debug.Log("Tercera Fase");
        // Centra la imagen en el Canvas
        RectTransform rectTransform = imagen.GetComponent<RectTransform>();
        rectTransform.anchoredPosition = Vector2.zero;
        isActive = true;
    }

    void Update()
    {
        if (isActive && Input.GetKeyDown(KeyCode.Escape))
        {
            imagen.SetActive(false);
            mainItem.SetActive(false);
            isActive = false;
            bg.GetComponent<Image>().color = Color.white;
        }
    }
}
