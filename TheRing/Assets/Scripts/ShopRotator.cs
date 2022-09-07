using UnityEngine;

public class ShopRotator : MonoBehaviour
{
    [SerializeField] private float rotationSpeed = 20;

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, rotationSpeed * Time.deltaTime, 0);
    }
}
