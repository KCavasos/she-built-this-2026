using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float bulletSpeed;
    public Vector3 direction;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //direction = transform.forward;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(direction * (bulletSpeed * Time.deltaTime));
    }
}
