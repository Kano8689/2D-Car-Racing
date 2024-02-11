using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Garage : MonoBehaviour
{
    public Sprite[] Cars;
    public AudioSource audioBtnClick;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnSelectCar(int chCar)
    {
        PlayerPrefs.SetInt("car_number",chCar);
        SceneManager.LoadScene("Play");
    }

    
}
