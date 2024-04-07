using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crystal : MonoBehaviour
{
    [SerializeField] private string _title = "Crystal";

    public void DeleteObject()
    {
        Destroy(gameObject);
    }
}
