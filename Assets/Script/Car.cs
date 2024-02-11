using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class Car : MonoBehaviour
{
    public GameObject enemyCar, fuelParents, Fuel, btnParentObject;
    public GameObject[] enemyCars;
    float[] Position = { -1.3f, 0.2f, 1.5f };
    float speed = 0.05f;
    public Slider fuelSlider;
    public Sprite[] Cars;
    int chCar;
    float carRotation = 0f;
    int gameController;
    bool isGoingLeft = false;
    bool isGoingRight = false;
    public AudioSource audioStart, audioCrash, audioFuel, audioRunCar;
    // Start is called before the first frame update
    void Start()
    {
        btnParentObject.SetActive(false);
        audioStart.Play();
        audioRunCar.Play();

        gameController = PlayerPrefs.GetInt("gameController", 1);
        if(gameController==2)
        {
            btnParentObject.SetActive(true);
        }

        if (!PlayerPrefs.HasKey("car_number"))
        {
            PlayerPrefs.SetInt("car_number", 1);
        }
        else
        {
            chCar = PlayerPrefs.GetInt("car_number");
        }

        this.GetComponent<SpriteRenderer>().sprite = Cars[chCar];

        InvokeRepeating("EnemyCarGenerate", 3f, 7f);
        // EnemyCarGenerate();
        InvokeRepeating("generateFuel", 10f, 15f);
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time==2f)
        {
            audioRunCar.Play();
        }

        if (gameController == 1)
        {
            //arrow
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                //carRotation += Time.deltaTime * 20f;
                //transform.rotation = Quaternion.Euler(0, 0, carRotation);
                //if (carRotation >= 20f)
                //{
                //    transform.rotation = Quaternion.Euler(0, 0, 0);
                //}
                //print("hello");
                float max = Mathf.Clamp(transform.position.x - speed, -1.31f, 1.56f);
                transform.position = new Vector2(max, transform.position.y);
            }
            if(Input.GetKeyUp(KeyCode.LeftArrow))
            {
                transform.rotation = Quaternion.Euler(0, 0, 0);
            }

            if (Input.GetKey(KeyCode.RightArrow))
            {
                //carRotation -= Time.deltaTime * 20f;
                //transform.rotation = Quaternion.Euler(0, 0, -carRotation);
                //if (carRotation <= -20f)
                //{
                //    transform.rotation = Quaternion.Euler(0, 0, 0);
                //}
                //print("hii");
                float max = Mathf.Clamp(transform.position.x + speed, -1.31f, 1.56f);
                transform.position = new Vector2(max, transform.position.y);
            }
            if (Input.GetKeyUp(KeyCode.RightArrow))
            {
                transform.rotation = Quaternion.Euler(0, 0, 0);
            }
        }
        
        if(gameController==2)
        {
            //button
            if (isGoingLeft)
            {
                //carRotation += Time.deltaTime * 20f;
                //transform.rotation = Quaternion.Euler(0, 0, carRotation);
                //if (carRotation >= 20f)
                //{
                //    transform.rotation = Quaternion.Euler(0, 0, 0);
                //}

                float max = Mathf.Clamp(transform.position.x - speed, -1.31f, 1.56f);
                transform.position = new Vector2(max, transform.position.y);
            }

            if (isGoingRight)
            {
                //carRotation -= Time.deltaTime * -20f;
                //transform.rotation = Quaternion.Euler(0, 0, carRotation);
                //if (carRotation <= 20f)
                //{
                //    transform.rotation = Quaternion.Euler(0, 0, 0);
                //}

                float max = Mathf.Clamp(transform.position.x + speed, -1.31f, 1.56f);
                transform.position = new Vector2(max, transform.position.y);
            }
        }

        if(gameController==3)
        {
            //phone
            if (Input.acceleration.y > 0.1f)
            {
                //carRotation -= Time.deltaTime * 20f;
                //if (carRotation >= 20f)
                //{
                //    transform.rotation = Quaternion.Euler(0, 0, 0);
                //}
                //else
                //{
                //    transform.rotation = Quaternion.Euler(0, 0, carRotation);
                //}

                float maxUp = Mathf.Clamp(transform.position.x - speed, -1.31f, 1.56f);
                transform.position = new Vector2(maxUp, transform.position.y);
                //transform.Rotate(0, 0, 1);
            }
            if (Input.acceleration.y < -0.1f)
            {
                carRotation -= Time.deltaTime * 20f;
                //if (carRotation <= -20f)
                //{
                //    transform.rotation = Quaternion.Euler(0, 0, 0);
                //}
                //else
                //{
                //    transform.rotation = Quaternion.Euler(0, 0, carRotation);
                //}

                float maxDown = Mathf.Clamp(transform.position.x + speed, -1.31f, 1.56f);
                transform.position = new Vector2(maxDown, transform.position.y);
                //transform.Rotate(0, 0, -1);
            }
        }

        if(gameController==4)
        {
            //touch
            Touch touch = Input.GetTouch(0);
            float half = Screen.width / 2;

            if(touch.position.x<half)
            {
                //carRotation += Time.deltaTime * 20f;
                //transform.rotation = Quaternion.Euler(0, 0, carRotation);
                //if (carRotation >= 15)
                //{
                //    transform.rotation = Quaternion.Euler(0, 0, 0);
                //}
                float max = Mathf.Clamp(transform.position.x - speed, -1.31f, 1.56f);
                transform.position = new Vector2(max, transform.position.y);
            }
            else
            {
                //carRotation -= Time.deltaTime * 20f;
                //transform.rotation = Quaternion.Euler(0, 0, carRotation);
                //if (carRotation <= -15)
                //{
                //    transform.rotation = Quaternion.Euler(0, 0, 0);
                //}

                float max = Mathf.Clamp(transform.position.x + speed, -1.31f, 1.56f);
                transform.position = new Vector2(max, transform.position.y);
            }

        }
        float score = fuelSlider.value;
        fuelSlider.value = score -= 0.015f;
        if (fuelSlider.value == 0)
        {
            //Debug.Log("Fuel is Empty");
            StartCoroutine(afterCrash());
            audioCrash.Play();
            SceneManager.LoadScene("Looser");
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Fuel")
        {
            Destroy(collision.gameObject);
            audioFuel.Play();
            fuelSlider.value = 100;
            //Debug.Log("Fuel");
        }

        if (collision.gameObject.tag == "enemyCars")
        {
            //print("Enemy Car");
            audioCrash.Play();
            SceneManager.LoadScene("Looser");
        }
    }
    
    void EnemyCarGenerate()
    {
        int randomPosition = Random.Range(0, Position.Length);
        int randomCar = Random.Range(0, enemyCars.Length);
        Vector2 pos = new Vector2(Position[randomPosition], 6.22f);
        Instantiate(enemyCars[0], pos, Quaternion.identity, enemyCar.transform);
    }

    void generateFuel()
    {
        int randomPosition = Random.Range(0, Position.Length);
        Vector2 pos = new Vector2(Position[randomPosition], 7);
        Instantiate (Fuel, pos, Quaternion.identity, fuelParents.transform);
    }

    IEnumerator afterCrash()
    {
        yield return new WaitForSeconds(1f);
        audioCrash.Play();
    }

    public void LeftSideDown()
    {
        isGoingLeft = true;
    }
    public void LeftSideUp()
    {
        //carRotation += Time.deltaTime * 15f;
        transform.rotation = Quaternion.Euler(0, 0, 0);
        isGoingLeft = false;
    }

    public void RightSideDown()
    {
        isGoingRight = true;
    }
    public void RightSideUp()
    {
        //carRotation += Time.deltaTime * 15f;
        transform.rotation = Quaternion.Euler(0, 0, 0);
        isGoingRight = false;
    }

}
