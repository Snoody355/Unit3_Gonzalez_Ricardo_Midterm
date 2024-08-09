using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{

    //[SerializeField] private PlayableDirector director;
    private PlayerInput player;
    
    [SerializeField] public GameObject Respawnpoint;
    public static GameManager Singleton { get; private set; }
    private HealthModules playerHealth;
    public bool isInRoom5 = false;


    public UnityEvent OnRespawn;
    public UnityEvent OnLevelStart;
    public UnityEvent OnlevelFinish;

    private void Awake()
    {
        if (Singleton == null)
        {
            Singleton = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

        

    
    }
    public void StartLevel()
    {
        isInRoom5 = false;
        player = FindObjectOfType<PlayerInput>();
        
        playerHealth = FindObjectOfType<HealthModules>();

        
    }

    public void FinishLevel()
    {
        OnlevelFinish?.Invoke();
    }

    

    private void Start()
    {
        StartLevel();
        OnLevelStart?.Invoke();

        
    }

    public void LockPlayer(bool isLocked)
    {
        player.enabled = !isLocked;
    }

    

    public void Respawn()
    {
        GameObject tempPoint = Respawnpoint;
        player.DisablePlayer(false);
        player.TpPlayer(tempPoint);
        
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        Debug.Log("i respawned");

        OnRespawn.Invoke();
       
    }


    public void RespawnAtStart()
    {
        player.DisablePlayer(false);
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        RestartGame();
    }

    public void DeadPlayer()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        player.DisablePlayer(true);


    }

    public void ChangeRespawn(GameObject point)
    {
        Respawnpoint = point;
    }

    public void inRoom5()
    {
        isInRoom5 = true;
    }

    public void EndGame()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        player.DisablePlayer(true);
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(0);
        Invoke("StartLevel", 1f);
        OnLevelStart?.Invoke();
    }
}
