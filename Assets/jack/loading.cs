using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class loading : MonoBehaviour
{
    public GameObject load;
   

    AsyncOperation async;

    public void Loadlevel(string lv)
    {
        StartCoroutine(loadingscreen(lv));

    }


    IEnumerator loadingscreen(string lvl)
    {
        load.SetActive(true);
        async = SceneManager.LoadSceneAsync(lvl);
        async.allowSceneActivation = false;

        while (async.isDone == false)
        {
           
            if (async.progress == 0.9f)
            {
                 load.SetActive(false);
                async.allowSceneActivation = true;
            }
            yield return new WaitForSeconds(3);
        }

      
    }


}
