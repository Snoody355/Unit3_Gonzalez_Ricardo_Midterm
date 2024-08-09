using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformAnimationj : MonoBehaviour
{
    [SerializeField] private Vector3 PlatformOffset;
    private Vector3 originalPosition;
    private bool isExtended;
    float currentTimer;
    bool starttimer;
    [SerializeField] float maxTime;

    // Start is called before the first frame update
    void Start()
    {
        originalPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        activatePlatform();
        if (starttimer)
        {
            currentTimer += Time.deltaTime;
            if(currentTimer >= maxTime)
            {
                currentTimer = 0;
                ReturnPlatform();
            }
        }
    }

    public void ExtendPlatform()
    {
        starttimer = true;
        isExtended = true;
    }

    public void ReturnPlatform()
    {
        starttimer = false;
        isExtended = false;
    }

    public void activatePlatform()
    {
        
        Vector3 targetPosition = originalPosition;
        if (isExtended)
        {
            targetPosition = originalPosition + PlatformOffset;
        }

        transform.position = Vector3.Lerp(transform.position, targetPosition, Time.deltaTime);
    }
}
