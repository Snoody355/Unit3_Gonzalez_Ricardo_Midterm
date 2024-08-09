using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleRoom5 : PuzzleRoom
{
    private PuzzleController puzzleController;
    public override void PuzzleEnter()
    {
        base.PuzzleEnter();
        GameManager.Singleton.inRoom5();
    }
    public override void InitializeRoom(PuzzleController controller)
    {
        puzzleController = controller;
        
    }
    private void OnTriggerEnter(Collider other)
    {
        puzzleController.ChangePuzzleRoom(this);
    }
}
