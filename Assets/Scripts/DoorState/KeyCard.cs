using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class KeyCard : MonoBehaviour
{
    [SerializeField] private GameObject Door;
    
    [SerializeField] private GameObject card;
    

    public UnityEvent OnCardCollect;
    private void OnTriggerEnter(Collider other)
    {
        card.SetActive(false);
        OnCardCollect.Invoke();
        
    }
}
