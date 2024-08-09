using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using TMPro;

public class PuzzleRoom4 : PuzzleRoom
{
    private PuzzleController puzzleController;
    [SerializeField]private bool is2ndPuzzleCompleted;
    private bool dooropend = false;
    [SerializeField] private UnityEvent Open;
    [SerializeField] GameObject Puzzle4Pannel;
    [SerializeField] TextMeshProUGUI counter;
    [SerializeField] PannelToggle MapPannel;
    private int count;
     private IPuzzlePiece[] targets;

    public override void PuzzleEnter()
    {
        base.PuzzleEnter();
        Puzzle4Pannel.SetActive(true);


    }

    public override void PuzzleExit()
    {
        base.PuzzleExit();
        Puzzle4Pannel.SetActive(false);
        MapPannel.DeactivatePannel();
    }
    public override void InitializeRoom(PuzzleController controller)
    {
        puzzleController = controller;
        targets = GetComponentsInChildren<IPuzzlePiece>();
    }

    private void Update()
    {
        
        CheckRoomStatus();

        if (is2ndPuzzleCompleted && !dooropend)
        {
            Debug.Log("tried to open the door");
            Open.Invoke();
            dooropend = true;
        }


    }

    public override void CheckRoomStatus()
    {
        is2ndPuzzleCompleted = true;
        count = 10;
        foreach(IPuzzlePiece piece in targets)
        {
            if (!piece.IsCorrect)
            {
                is2ndPuzzleCompleted = false;
                count--;
            }

            counter.text = count.ToString() + "/10";
            
            
        }

        
    }

    private void OnTriggerEnter(Collider other)
    {
        puzzleController.ChangePuzzleRoom(this);
    }
    
}
