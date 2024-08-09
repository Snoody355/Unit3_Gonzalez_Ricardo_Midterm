using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PannelToggle : MonoBehaviour
{
    [SerializeField] private GameObject CurrentPannel;


    public void TogglePannel()
    {
        CurrentPannel.SetActive(true);
        Invoke("TurnOffPannel", 10f);
        
    }


    private void TurnOffPannel()
    {
        CurrentPannel.SetActive(false);
    }

    public void ActivatePannel()
    {
        CurrentPannel.SetActive(true);
    }

    public void DeactivatePannel()
    {
        CurrentPannel.SetActive(false);
    }

}
