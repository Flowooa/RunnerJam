using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitboxKill : MonoBehaviour
{
    [SerializeField] Transform SpawnPoint;                                   //On r�cup�re le transform du point de respawn

    private void OnCollisionStay(Collision collision)                    //On d�tecte quand il y a une collision prolong�e
    {
        if (collision.transform.CompareTag("Player"))                        //Si il y a collision avec un objet poss�dant le tag Player
            collision.transform.position = SpawnPoint.position;           //On r�cup�re la position du transform de resapwn et on y t�l�porte l'objet Player
    }
}
