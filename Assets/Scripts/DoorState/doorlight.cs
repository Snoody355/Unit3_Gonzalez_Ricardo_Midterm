using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class doorlight : MonoBehaviour
{
    [SerializeField] private KeyCard connectedKeycard;
    [SerializeField] private Material unlockedmaterial;

    private MeshRenderer myrenderer;

    // Start is called before the first frame update
    void Start()
    {
        myrenderer = GetComponent<MeshRenderer>();
        connectedKeycard.OnCardCollect.AddListener(ChangeMaterial);
    }

    private void ChangeMaterial()
    {
        myrenderer.material = unlockedmaterial;
    }
}
