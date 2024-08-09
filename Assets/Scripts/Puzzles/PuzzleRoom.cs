using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleRoom : MonoBehaviour
{
    private PuzzleController puzzleController;
    [SerializeField] private bool isPuzzleCompleted;
    private IPuzzlePiece[] puzzlePieces;
    // Start is called before the first frame update
    public virtual void PuzzleEnter()
    {
        Debug.Log("Player Entered the room");
    }

    // Update is called once per frame
    public virtual void PuzzleExit()
    {
        Debug.Log("Player Exited teh Room");
    }

    public virtual void InitializeRoom(PuzzleController controller)
    {
        puzzleController = controller;
        puzzlePieces = GetComponentsInChildren<IPuzzlePiece>();

        


    }

    public virtual void CheckRoomStatus()
    {
        isPuzzleCompleted = true;
        foreach (IPuzzlePiece piece in puzzlePieces)
        {
           if (!piece.IsCorrect) isPuzzleCompleted = false;
        }

        if (isPuzzleCompleted)
        {
            Debug.Log("allRequirments met");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        puzzleController.ChangePuzzleRoom(this);
    }
}
