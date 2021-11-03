using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour
{
    private bool istriggered = false;

    void OnTriggerEnter(Collider trig)
    {
        {
            if (trig.gameObject.CompareTag("Player"))
            {
                trig.gameObject.GetComponent<Player>().ChangeSize();
            }
            istriggered = true;
        }
    }
}
