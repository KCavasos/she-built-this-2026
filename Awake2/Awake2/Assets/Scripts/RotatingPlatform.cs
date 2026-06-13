using System.Collections;
using UnityEngine;

public class RotatingPlatform : MonoBehaviour
{
    public Vector3 RotationSpeeds;
    public bool isRotating = true;
    public Collider RotatingCollision;
    public GameObject PushAwayTrigger;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        RotatingCollision.enabled = !isRotating;
    }

    // Update is called once per frame
    void Update()
    {
        if (isRotating)
        {
            RotatingCollision.enabled = false;
            if (RotationSpeeds.x != 0)
            {
                transform.Rotate(new Vector3(1,0,0), RotationSpeeds.x * Time.deltaTime);
            }
        }

        RotatingCollision.enabled = !isRotating;
    }

    public IEnumerator OnShot(float value)
    {
        print("Rotating platform got shot"!);
        if (isRotating)
        {
            RotatingCollision.enabled = true;
            isRotating = false;
            PushAwayTrigger.SetActive(false);

            yield return new WaitForSeconds(value);
            RotatingCollision.enabled = false;
            isRotating = true;
            PushAwayTrigger.SetActive(true);
        }
    }
}
