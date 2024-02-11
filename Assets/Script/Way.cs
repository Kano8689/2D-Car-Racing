using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Way : MonoBehaviour
{
    Renderer renderer;
    SceneManager scene;
    string s;
    public AudioSource adioBtnClick;
    // Start is called before the first frame update
    void Start()
    {
        renderer = GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        s = SceneManager.GetActiveScene().name;

        if (s=="Play")
        {
            float Yspeed = Time.time * 1f;
            renderer.material.SetTextureOffset("_MainTex", new Vector2(0, Yspeed));
        }
    }

    public void onClickSetting()
    {
        SceneManager.LoadScene("Setting");
    }

    public void OnGarageClick()
    {
        adioBtnClick.Play();
        SceneManager.LoadScene("Garage");
    }
}
