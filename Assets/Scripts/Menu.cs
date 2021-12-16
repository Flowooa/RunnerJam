using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public void Play()                                  //Fonction pour charger la sc�ne pour lancer le Jeu
    {
        SceneManager.LoadScene("Runer3D");           //On met la sc�ne du Jeu
    }

    public void Quit()                                               //Fonction pour quitter le jeu 
    {
        Application.Quit();                                          //On quitte le jeu
    }
}
