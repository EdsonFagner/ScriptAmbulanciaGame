using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptSeta : MonoBehaviour
{
    [SerializeField]
    public Transform target;
     void Update()
    {
        transform.LookAt(target);
    }
}
