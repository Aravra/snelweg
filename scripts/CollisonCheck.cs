using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisonCheck : MonoBehaviour
{
    bool Collided = false;

    private void OnCollisionEnter(Collision collision)
    {
        Collided = true;
    }
}
