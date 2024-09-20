using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DragDrop : MonoBehaviour
{
    public GameObject ObjToDrag;
    public GameObject ObjDragPos;
    public GameObject ObjContainer;

    public float DropDistance;
    public float DropDistContainer;
    public bool isLocked;
    Vector2 ObjInitPos;

    // Start is called before the first frame update
    void Start()
    {
        ObjInitPos = ObjToDrag.transform.position; // Save Object Original Position
        // Image.transform
        // Component.???
    }

    public void DragObject()
    {
        if(!isLocked)
        {
            ObjToDrag.transform.position = Input.mousePosition; // Move the object along with the mouse if is not locked
        }
    }

    public void DropObject()
    {
        float Distance = Vector3.Distance(ObjToDrag.transform.position, ObjDragPos.transform.position);
        float DistanceContainer = Vector3.Distance(ObjToDrag.transform.position, ObjContainer.transform.position);

        int DragCompleted = 1;

        //GameObject newF = GameObject.FindGameObjectWithTag("PlaceHolderBG"); //Set Parent
        

        if (Distance < DropDistance && DistanceContainer > DropDistContainer) // If is close to the goal and far from the container
        {
            isLocked = true;
            ObjToDrag.transform.position = ObjDragPos.transform.position;

            GameManagement.manager.TriggerOff(ObjToDrag, EventTriggerType.Drop);

            GameManagement.manager.PuzzleCounter(DragCompleted);

            if (ObjToDrag.transform.eulerAngles.z != 0)
            {
                ObjToDrag.transform.eulerAngles = Vector3.zero;
            }

        }
        else if (Distance > DropDistance && DistanceContainer < DropDistContainer)
        {
            ObjToDrag.transform.position = ObjContainer.transform.position;

            //ObjToDrag.transform.parent = newF.transform; // Move to parent (for grid layout)

        }
        else
        {
            ObjToDrag.transform.position = ObjInitPos;
            
        }

    }

    // Testing
    
}
