using StarterAssets;
using UnityEngine;

public class PushAwayTrigger : MonoBehaviour
{
    public GameObject PushAwayDir;
    public float PushAwayForce = 10.0f;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        // Check if the object entering the trigger is the Player
        if (other.CompareTag("Player"))
        {
            //Debug.Log("Player entered the trigger zone!");
            
            other.GetComponent<ThirdPersonController>().ApplyForce(PushAwayDir.transform.forward * PushAwayForce);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
