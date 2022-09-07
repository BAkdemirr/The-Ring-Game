using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    private const float size_scalel = 0.28f;
    private const float checker_radius = 0.18f;
    [SerializeField] private Vector3 default_size = new Vector3(1, 1, 1);
    [SerializeField] private LayerMask cylinder_layer;

    public float offset = 0.2f;

    public bool can_collect = false;

    public float health = 10.0f;

    [SerializeField] private UIManager ui_manager;

    [SerializeField] private AudioClip touch_sound, death_sound;

    [SerializeField] private GameObject distanceValue, pauseBtn;

    int reklamSayaci = 0;

    //public static PlayerManager pm;

    //private void Awake()
    //{
    //    if (pm == null) 
    //    {
    //        DontDestroyOnLoad(gameObject);
    //        pm = this;
    //        print("DontDestroy çalıştı");
    //    }
    //    else
    //    {
    //        Destroy(gameObject);
    //    }
    //}

    private void Start()
    {
        
    }
    
    // !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
    private void FixedUpdate()
    {
        //distanceValue.SetActive(true);
        //pauseBtn.SetActive(true);
        //transform.Translate(Vector3.forward * 5 * Time.deltaTime, Space.World);

        // Define cylinder and radius
        Transform cyl = Physics.OverlapSphere(transform.position, checker_radius, cylinder_layer)[0].transform;
        float cyl_radius = cyl.localScale.x * size_scalel;

        // Death situations

        if (health <= 0) 
        {
            Death();
        }



        if (cyl_radius > transform.localScale.y) 
        {
            Death();
        }

        if (cyl.CompareTag("Enemy")) 
        {
            if (cyl_radius + offset > transform.localScale.y) 
            {
                Death();
            }
        }

        // check can collect
        if (cyl_radius + offset > transform.localScale.y)
        {
            can_collect = true;
        }
        else
        {
            can_collect = false;
        }

        HealthCounter();

        ChangeRingRadius(cyl_radius);
    }

    private void Death()
    {
        if (Camera.main != null)
        {
            Camera.main.GetComponent<CameraController>().enabled = false;
        }

        // GameOver UI
        ui_manager.OpenGameOverUI();

        // isPlayerAlive bool değişimi
        GameManager.gm.isPlayerAlive = false;

        // Save HighScore
        if (GameManager.gm.distance > PlayerPrefs.GetFloat("Highscore")) 
        {
            PlayerPrefs.SetFloat("Highscore", GameManager.gm.distance);
        }
        // Set highscore
        UIManager.ui_m.SetHighscoreText();

        Camera.main.GetComponent<AudioSource>().PlayOneShot(death_sound);

        // death counter for interstitial ad reklam olayı
        reklamSayaci = PlayerPrefs.GetInt("reklamSayaci");
        reklamSayaci++;
        PlayerPrefs.SetInt("reklamSayaci", reklamSayaci);

        if (reklamSayaci == 3) 
        {
            UnityAds.unityAds.ShowInterstitialAd();
            PlayerPrefs.SetInt("reklamSayaci", 0);
        }

        Destroy(gameObject);
        
    }

    private void ChangeRingRadius(float cyl_radius)
    {
        if (Input.touchCount > 0) 
        {
            Touch touch = Input.GetTouch(0);

            // sound unity bak

            // Changing the radius based on cylinder radius
            if (Input.GetTouch(0).phase == TouchPhase.Stationary)  
            {
                Vector3 target_vector = new Vector3(default_size.x, cyl_radius, cyl_radius);

                transform.localScale = Vector3.Slerp(transform.localScale, target_vector, 0.125f);

                
                
            }
            if (Input.GetTouch(0).phase== TouchPhase.Began)
            {
                // Play Sound Effect Blip
                Camera.main.GetComponent<AudioSource>().PlayOneShot(touch_sound, 0.7f);
            }
            
        }
        else
        {
            transform.localScale = Vector3.Slerp(transform.localScale, default_size, 0.125f);
        }


    }

    private void HealthCounter()
    {
        health = Mathf.Clamp(health, -1, 10.0f);

        if (health >= 0) 
        {
            health -= Time.deltaTime;
            UIManager.ui_m.SetPlayerHealth(health);
        }
        
    }

    public void IncreaseHealth(float value)
    {
        health += value;
    }
}
