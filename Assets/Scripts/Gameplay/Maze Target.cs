using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MazeTarget : MonoBehaviour, IPuzzlePiece
{
    [SerializeField] private GameObject target;

     private bool isShot;

    public bool IsCorrect { get => isShot; set => isShot = value; }

    private void OnTriggerEnter(Collider other)
    {
        isShot = true;
        target.gameObject.SetActive(false);
    }
}
