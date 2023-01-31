using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtObject : MonoBehaviour
{
    [SerializeField]
    GameObject _gameObject;

    void Update()
    {
        transform.rotation = Quaternion.LookRotation(transform.position - _gameObject.transform.position);
    }
}