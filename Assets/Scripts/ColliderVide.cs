using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderVide : MonoBehaviour
{
    [SerializeField] Transform Spwn;

    private void OnCollisionStay(Collision collision)
    {
        if(collision.transform.CompareTag("Player"))
            
              collision.transform.position = Spwn.position;
           
    }
}
