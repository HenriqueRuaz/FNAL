using UnityEngine;

public class Static_Sound : MonoBehaviour
{
    public AudioSource sfx;
    
    void Start()
    {
        if(gameObject.activeSelf)
            sfx.Play();
    }
}
