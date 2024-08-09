using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Targetscript : MonoBehaviour
{

    [SerializeField] SpringJoint joint;

    private void OnTriggerEnter(Collider other)
    {
        Destroy(joint);
    }

}
