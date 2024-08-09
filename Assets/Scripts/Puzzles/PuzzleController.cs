using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleController : MonoBehaviour
{
    [SerializeField] private PuzzleRoom currentRoom;
    [SerializeField] private List<PuzzleRoom> puzzleRooms;
    
    private void Awake()
    {
        foreach(PuzzleRoom room in puzzleRooms)
        {
            room.InitializeRoom(this);
        }
    }

    public void ChangePuzzleRoom(PuzzleRoom newRoom)
    {
        if (currentRoom != null) {
            currentRoom.PuzzleExit();
        }

        currentRoom = newRoom;
        currentRoom.PuzzleEnter();
    }
}
