using UnityEngine;
using System.Collections;

public class NightManager : MonoBehaviour {
    [Header("Startup")]
    public float firstStartDelay = 5f;
    public float restartDelay = 2.5f;

    [Header("Referências")]
    public OfficeLook officeLook;

    public float currentDelay {
        get; private set;
    }

    public bool CanPlay {
        get; private set;
    }

    void Start() {
        StartNight(false);
    }

    public void StartNight(bool isRestart) {
        CanPlay = false;

        if(isRestart)
            currentDelay = restartDelay;
        else
            currentDelay = firstStartDelay;

        StartCoroutine(StartNightCoroutine());
    }

    IEnumerator StartNightCoroutine() {
        yield return new WaitForSeconds(currentDelay);

        CanPlay = true;

        officeLook.EnableLook();
    }
}
