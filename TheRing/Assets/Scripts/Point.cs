using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Point : MonoBehaviour
{
    [SerializeField] private Vector3 axis = new Vector3(0, 0, 0);

    [SerializeField] private LayerMask player_layer;
    private PlayerManager pm;

    [SerializeField] private Color collectable_color, noncollectable_color;

    [SerializeField] private AudioClip pickup_sound;

    private void Awake()
    {
        pm = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerManager>();
    }

    private void Update()
    {
        transform.Rotate(axis * Time.deltaTime);



        if (pm.can_collect)
        {
            // Color ve rotation değişimi kutular collectable olduğunda
            axis.y = 270;
            GetComponent<MeshRenderer>().material.color = collectable_color;

            // Collect Point
            bool touchingToPlayer = Physics.CheckSphere(transform.position, 1.2f, player_layer);
            
            if (touchingToPlayer /* && pm.can_collect */ ) 
            {
                PlayerPrefs.SetInt("money", PlayerPrefs.GetInt("money") + 5);
                pm.IncreaseHealth(2.0f);
                // pickup sound
                Camera.main.GetComponent<AudioSource>().PlayOneShot(pickup_sound, 0.5f);

                Destroy(this.gameObject);
            }
        }
        else
        {
            axis.y = 45;
            GetComponent<MeshRenderer>().material.color = noncollectable_color;
        }
    }
}
