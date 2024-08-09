using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class CutsceneControl : MonoBehaviour
{
    [SerializeField] private CutsceneQueue queue;

    [SerializeField] private PlayableDirector director;

    // Start is called before the first frame update
    void Start()
    {
        GameManager.Singleton.OnLevelStart.AddListener(PlayCutscene);

    }

    public void PlayCutscene()
    {
        director.Play();
    }

    public virtual void OnCutsceneEnter()
    {
        GameManager.Singleton.LockPlayer(true);
    }

    public virtual void OnCutsceneFinish()
    {
        GameManager.Singleton.OnLevelStart.RemoveListener(PlayCutscene);
        GameManager.Singleton.LockPlayer(false);
        Destroy(gameObject);
    }

   public enum CutsceneQueue
    {
        onLevelStart, OnLevelFinished, OnPizzleStart, OnPuzzleFinished
    }
}
