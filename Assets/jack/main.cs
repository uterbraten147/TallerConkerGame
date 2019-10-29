using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class main : MonoBehaviour
{
    public GameObject cambiamain;
    public GameObject cambiaoption;
    public GameObject cambiacreditos;

    public EventSystem misEventos;

    public bool menumain = true;
    public bool optionmenu = false;
    public bool creditosmain = false;

    public void menumainact()
    {
        menumain = true;
        optionmenu = false;
        creditosmain = false;
        if (menumain == true)
        {
            cambiamain.SetActive(true);
            cambiaoption.SetActive(false);
            cambiacreditos.SetActive(false);
        }
        SeleccionarNuevo();
    }

    public void menuoption()
    {
        menumain = false;
        optionmenu = true;
        creditosmain = false;
        if (optionmenu == true)
        {
            cambiamain.SetActive(false);
            cambiaoption.SetActive(true);
            cambiacreditos.SetActive(false);


        }
        SeleccionarNuevo();

    }
    public void menucredito()
    {
        menumain = false;
        optionmenu = false;
        creditosmain = true;
        if (creditosmain == true)
        {
            cambiamain.SetActive(false);
            cambiaoption.SetActive(false);
            cambiacreditos.SetActive(true);

        }
        SeleccionarNuevo();
    }

    public void SeleccionarNuevo()
    {
        //misEventos.GetComponent<EventSystem>().SetSelectedGameObject(level1);
        misEventos.SetSelectedGameObject(GameObject.FindGameObjectWithTag("seleccionable"));
    }
}
