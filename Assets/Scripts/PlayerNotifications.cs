using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerNotifications : MonoBehaviour
{
    [SerializeField] private GameObject NightStandNotification;
    [SerializeField] private GameObject BathroomNotification;
    [SerializeField] private GameObject InsideKitchenNotification;
    [SerializeField] private GameObject OutsideKitchenNotification;
    [SerializeField] private GameObject InsideStudioNotification;
    [SerializeField] private GameObject OutsideStudioNotification;
    [SerializeField] private GameObject InsideLivingroomNotification;
    [SerializeField] private GameObject OutsideLivingroomNotification;
    [SerializeField] private GameObject StudioNotification;
    [SerializeField] private GameObject LivingroomNotification;
    [SerializeField] private GameObject KitchenNotification;


    public void NotifyPlayerNightstand()
    {
        NightStandNotification.SetActive(true);
    }

    public void DeNotifyPlayerNightstand()
    {
        NightStandNotification.SetActive(false);
    }

    public void NotifyPlayerBathroom()
    {
        BathroomNotification.SetActive(true);
    }

    public void DeNotifyPlayerBathroom()
    {
        BathroomNotification.SetActive(false);
    }

    public void NotifyPlayerInsideKitchen()
    {
        InsideKitchenNotification.SetActive(true);
    }

    public void DeNotifyPlayerInsideKitchen()
    {
        InsideKitchenNotification.SetActive(false);
    }

    public void NotifyPlayerOutsideKitchen()
    {
        OutsideKitchenNotification.SetActive(true);
    }

    public void DeNotifyPlayerOutsideKitchen()
    {
        OutsideKitchenNotification.SetActive(false);
    }

    public void NotifyPlayerInsideStudio()
    {
        InsideStudioNotification.SetActive(true);
    }

    public void DeNotifyPlayerInsideStudio()
    {
        InsideStudioNotification.SetActive(false);
    }

    public void NotifyPlayerOutsideStudio()
    {
        OutsideStudioNotification.SetActive(true);
    }

    public void DeNotifyPlayerOutsideStudio()
    {
        OutsideStudioNotification.SetActive(false);
    }

    public void NotifyLivinroomInside()
    {
        InsideLivingroomNotification.SetActive(true);
    }

    public void DeNotifyLivinroomInside()
    {
        InsideLivingroomNotification.SetActive(false);
    }

    public void NotifyLivinroomOutside()
    {
        OutsideLivingroomNotification.SetActive(true);
    }

    public void DeNotifyLivinroomOutside()
    {
        OutsideLivingroomNotification.SetActive(false);
    }

    public void NotifyStudioInside()
    {
        StudioNotification.SetActive(true);
    }

    public void DeNotifyStudioOutside()
    {
        StudioNotification.SetActive(false);
    }

    public void NotifyLivingroomInsidePuzzle()
    {
        LivingroomNotification.SetActive(true);
    }

    public void DeNotifyLivingroomOutsidePuzzle()
    {
        LivingroomNotification.SetActive(false);
    }

    public void NotifyKitchenInsideDialogue()
    {
        KitchenNotification.SetActive(true);
    }

    public void DeNotifyKitchenOutsideDialogue()
    {
        KitchenNotification.SetActive(false);
    }

}
