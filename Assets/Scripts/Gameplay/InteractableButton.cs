using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class InteractableButton : MonoBehaviour, IInteractable
{
    [SerializeField] private UnityEvent OnbuttonPressed;
    [SerializeField] private Material highlightedMaterial;

    private Material OriginalMaterial;
    private MeshRenderer myrender;

    private void Awake()
    {
        myrender = GetComponent<MeshRenderer>();
        OriginalMaterial = myrender.material;
    }

    public void Interact(PlayerInput Interactor)
    {
        OnbuttonPressed.Invoke();
    }

    public void OnHoverEnter()
    {
        myrender.material = highlightedMaterial;
    }

    public void OnHoverExit()
    {
        myrender.material = OriginalMaterial;
    }
}
