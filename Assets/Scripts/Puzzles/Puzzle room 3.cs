using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puzzleroom3 : PuzzleRoom
{
    private PuzzleController puzzleController;
    [SerializeField] private GameObject newRespawnpoint;
    [SerializeField] private Transform boxPoint;
    [SerializeField] private GameObject Box;
    private GameObject tempBox;

    public override void InitializeRoom(PuzzleController controller)
    {
        puzzleController = controller;
        
    }

    public override void PuzzleEnter()
    {
        base.PuzzleEnter();
        GameManager.Singleton.ChangeRespawn(newRespawnpoint);
        Box.transform.position = boxPoint.transform.position;
        Box.SetActive(true);
        
    }

    public override void PuzzleExit()
    {
        base.PuzzleExit();
        Box.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        puzzleController.ChangePuzzleRoom(this);
    }
}
