using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class pause : MonoBehaviour
{
    //  bool pause=false;
    public GameObject /*btnpause,*/ Resume, Quit, pausemenu;
    public Canvas Canvas;
    // public GameObject ButtonsAction;


    public EventSystem misEventos;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.P)|| Input.GetKeyDown(KeyCode.Escape))
        {
            if (Time.timeScale == 1)
            {
                Time.timeScale = 0;
                pausebtn();
            }
        }
    }



    public void pausebtn()
    {
        Time.timeScale = 0;
        pausemenu.SetActive(true);

    }

    public void quitbtn()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
    }

    public void resume()
    {
        Time.timeScale = 1;
        pausemenu.SetActive(false);
    }

    public void SeleccionarNuevo()
    {

        misEventos.SetSelectedGameObject(GameObject.FindGameObjectWithTag("seleccionable"));
    }

}
