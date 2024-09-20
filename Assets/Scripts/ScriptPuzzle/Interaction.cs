using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Interaction : MonoBehaviour
{
    public GameObject panel;

    public void OnPointerClick()
    {
        panel.SetActive(true);
        GameManagement.manager.TriggerOff(gameObject, EventTriggerType.PointerClick);
    }
}
