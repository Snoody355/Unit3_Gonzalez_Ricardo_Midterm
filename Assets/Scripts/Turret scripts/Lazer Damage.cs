using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LazerDamage : MonoBehaviour
{
    [SerializeField] private EdgeCollider2D lineCollider;
    [SerializeField] private LineRenderer Lazer;


    // Update is called once per frame
    void Update()
    {
        SetEdgeCollider(Lazer);
    }

    void SetEdgeCollider(LineRenderer lazer)
    {
        List<Vector2> edges = new List<Vector2>();

        for ( int point = 0; point<lazer.positionCount; point++)
        {
            Vector3 lReninedererPoint = lazer.GetPosition(point);
            edges.Add(new Vector2(lReninedererPoint.x, lReninedererPoint.y));

        }

        lineCollider.SetPoints(edges);
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("yo yo yo yo ");
    }
}
