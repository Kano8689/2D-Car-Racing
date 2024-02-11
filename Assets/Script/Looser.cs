using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Looser : MonoBehaviour
{
    public AudioSource audioBtnClick;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnGarageClick()
    {
        audioBtnClick.Play();
        SceneManager.LoadScene("Garage");
    }

    public void onClickRestart()
    {
        audioBtnClick.Play();
        SceneManager.LoadScene("Play");
    }
}
