using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [HideInInspector]public bool isPlayerAlive = true;
    public static GameManager gm;

    private GameObject player;
    [SerializeField] private Transform playerStartPoint;

    [SerializeField] private CameraController cc;
    [SerializeField] private float difficulty;

    public float distance;

    public AdButtonTimer adButtonTimer;

    [SerializeField] private GameObject pauseBtn;

    private void Awake()
    {
        // awake içinde bunu yazıp ve tanımlamayı public static yaparsak başka scriptlerde
        // GameManager.gm.isplayeralive diyerek ulaşım yapılabilir. Her seferinde serializefield yazıp ulaşmaya gerek yok.
        // instance erişim

        gm = this;

        player = GameObject.FindGameObjectWithTag("Player");

        
    }

    private void Update()
    {
        
        
        // Load level when clicked
        if (!isPlayerAlive)
        {
            //if (adButtonTimer.isButtonClicked == true) 
            //{
            //    adButtonTimer.ButtonClicked();
            //}

            pauseBtn.SetActive(false);
            UIManager.ui_m.OpenGameOverUI();


        }

        // Calculate player distance
        if (player != null)
        {
            distance = Vector3.Distance(player.transform.position, playerStartPoint.position);
            UIManager.ui_m.SetDistanceValue(distance);
        }

        cc.speed += Time.timeSinceLevelLoad / 10000 * difficulty;
        cc.speed = Mathf.Clamp(cc.speed, 1, 18);


        if (cc.speed == 18)
        {
            // Mathf.Max(cc.speed - 5, 0f);
            cc.speed = Random.Range(8, 18);
        }

        

    }

    public void OnRewardAdSuccess()
    {
        print("Done");
    }
}
