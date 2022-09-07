using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPoint : MonoBehaviour
{
    [SerializeField]private GameObject point;

    private void Start()
    {
        if (!this.gameObject.CompareTag("Enemy"))
        { 
            CreatePoints(); 
        }
    }

    private void CreatePoints()
    {
        float radius_cyl = transform.localScale.x / 2;
        float radius_cube = point.transform.localScale.x / 2;

        float minRange = transform.position.z - transform.localScale.y;
        float maxRange = transform.position.z + transform.localScale.y;

        Instantiate(point, new Vector3(transform.position.x, transform.position.y + radius_cyl + radius_cube, Random.Range(minRange,maxRange)), Quaternion.identity);

    }
}
