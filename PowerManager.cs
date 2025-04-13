//Taylor Burdgess, Charlie Garrido

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//TASK 1: Add a shield power-up to the game. 
public class PlayerShield : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public GameObject shieldVisual; // Optional: visual representation of shield
    private bool isShieldActive = false;
    private float shieldTimer = 0f;

    void Update()
    {
        if (isShieldActive)
        {
            shieldTimer -= Time.deltaTime;
            if (shieldTimer <= 0f)
            {
                DeactivateShield();
            }
        }
    }

    public void ActivateShield(float duration)
    {
        isShieldActive = true;
        shieldTimer = duration;
        if (shieldVisual != null)
            shieldVisual.SetActive(true);

        
    }

    public void DeactivateShield()
    {
        isShieldActive = false;
        if (shieldVisual != null)
            shieldVisual.SetActive(false);

    }

    public bool IsShieldActive()
    {
        return isShieldActive;
    }
}


public class Shield : MonoBehaviour
{

    public GameObject shieldPrefab;
    private GameManager gameManager;
    private PlayerShield playerShield;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public float shieldDuration = 5f; // duration in seconds

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            //gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
            if (playerShield != null)
            {
                playerShield.ActivateShield(shieldDuration);
                Destroy(gameObject); // remove the power-up after collection
            }
        }
    }
}


//TASK 2: Make sure that the power-up and -down sounds work properly. 

public class PowerManager: MonoBehaviour
{
    public AudioClip powerUpSound;
    public AudioClip powerDownSound;
    private AudioSource audioSource;

void Start()
{
    //The AudioSource attached to the Game Object
    audioSource = GetComponent<AudioSource>();

     if (audioSource == null)
{
    Debug.LogError("AudioSource component missing on this GameObject.");
}
}

public void PoweUp()
{
   PlaySound(powerupClip, "Power-Up");
}

public void PowerDown()
{
   PlaySound(powerDownClip, "Power-Down");
}

private void PlaySound(AudioClip clip)
{
    if(clip !=null && audioSource !=null)
    {
        audioSource.PlayOneShot(clip)
    }
    else
    {
      Debug.LogWarning('AudioClip or AudioSource missing.');
    }
}
}