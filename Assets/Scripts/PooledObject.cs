using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PooledObject : MonoBehaviour
{
    [SerializeField] private Rigidbody rb;
    private objectPool pool;
    private float resetTimer;

    public void LinkPooledObject(objectPool linkPool)
    {
        pool = linkPool;
    }

    public void ResetPooledObject()
    {
        rb.velocity = Vector3.zero;
        pool.SendBackToPool(this);
    }

    public void ResetPooledObject(float timer)
    {
        Invoke("ResetPooledObject", timer);
    }

    private void Update()
    {
        if(resetTimer > 0)
        {
            resetTimer -= Time.deltaTime;
            if(resetTimer <=0)
            {
                ResetPooledObject();
            }
        }
    }

    public Rigidbody GetRigidbody()
    {
        return rb;
    }
}
