using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public void EndGame()
    {
        GameManager.Singleton.EndGame();
    }

    public void Respawn()
    {
        GameManager.Singleton.Respawn();
    }

    public void RestartGame()
    {
        GameManager.Singleton.RestartGame();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
