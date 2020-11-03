using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour
{
    public void LoadScenes(string name)
    {
        //Melakukan pengecekan jika name tidak null atau empty
        if (!string.IsNullOrEmpty(name))
        {
            //membuka scene dengan nama sesuai dengan variable name
            SceneManager.LoadScene(name);
        }
    }
}
