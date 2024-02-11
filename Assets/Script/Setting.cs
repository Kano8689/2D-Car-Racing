using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Setting : MonoBehaviour
{
    public Sprite[] Cars;
    public AudioSource audioBtnClick;
    int gameController = 1;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnGarageBtn()
    {
        SceneManager.LoadScene("Garage");
    }

    public void OnControlBtn()
    {
        SceneManager.LoadScene("Control");
    }

    public void OnSelectCar(int chCar)
    {
        PlayerPrefs.SetInt("car_number",chCar);
        SceneManager.LoadScene("Play");
    }


    public void onClickPlayType(int ch)
    {
        //if (ch == 1)
        //{
        //    gameController = 1;
        //}
        //else if (ch == 2)
        //{
        //    gameController = 2;
        //}
        //else if (ch == 3)
        //{
        //    gameController = 3;
        //}
        //else 
        //{
        //    gameController = 4;
        //}

        gameController = ch;
        PlayerPrefs.SetInt("gameController", gameController);
        //Debug.Log(gameController);
        SceneManager.LoadScene("Play");
    }
}
