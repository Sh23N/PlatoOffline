using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class main_menu : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //SceneManager.GetActiveScene().buildIndex;
        // SceneManager.LoadScene("menu");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnClickGame(string GameName)
    {
        SceneManager.LoadScene(GameName);
    }
}


