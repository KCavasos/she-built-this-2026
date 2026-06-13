using StarterAssets;
using UnityEngine;

public class FreezeGun : MonoBehaviour
{
    private StarterAssetsInputs _input;
    private GameObject _mainCamera;
    
    [SerializeField] private LayerMask TargetMask; 
    
    public float MaxDistance = 50.0f;
    
    public AudioClip FireAudioClip;
    public float FireAudioVolume = 1.0f;
        
    public GameObject WeaponObject;

    public float FreezeDuration = 5.0f;
    
    public GameObject BulletPrefab;
    
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _input = GetComponent<StarterAssetsInputs>();   
        if (_mainCamera == null)
        {
            _mainCamera = GameObject.FindGameObjectWithTag("MainCamera");
        }
    }

    // Update is called once per frame
    void Update()
    {
        Debug.DrawRay(_mainCamera.transform.position, _mainCamera.transform.forward * 1000, Color.red);
        if (_input.fire)
        {
            FireWeapon();
            _input.fire = false;
        }
    }

    public void FireWeapon()
    {
        if (_mainCamera == null)
        {
            _mainCamera = GameObject.FindGameObjectWithTag("MainCamera");
        }
        
        if (FireAudioClip != null)
            AudioSource.PlayClipAtPoint(FireAudioClip, WeaponObject.transform.position, FireAudioVolume);


        //Quaternion LookDownCameraAim = Quaternion.LookRotation();
        GameObject bullet = Instantiate(BulletPrefab, _mainCamera.transform.position, _mainCamera.transform.rotation);
        bullet.transform.LookAt(_mainCamera.transform.forward * 1000);
        
        Bullet bulletScript = bullet.GetComponent<Bullet>();
        bulletScript.direction = -_mainCamera.transform.right;
        
        
        //Debug.Log("Fire!");
        RaycastHit hit;
        Physics.Raycast(_mainCamera.transform.position, _mainCamera.transform.forward, out hit, MaxDistance, TargetMask);
        
        if (hit.collider != null)
        {
            Debug.DrawLine(hit.point, hit.point + hit.normal * 4, Color.red);
            hit.collider.SendMessageUpwards("OnShot", FreezeDuration, SendMessageOptions.DontRequireReceiver);
            Debug.Log("Shot a thing! " + hit.collider.name);
        }
    }
}
