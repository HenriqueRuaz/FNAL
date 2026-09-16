using UnityEngine;

public class GlitchSfx : MonoBehaviour {
    public GlitchAnimation ga;
    public AudioSource sfx;

    private bool alreadyPlayed = false;

    void Update() {
        // Se a animação não está a tocar, reset
        if(!ga.isPlaying) {
            alreadyPlayed = false;
            return;
        }

        // Se a animação começou e o som ainda não tocou
        if(!alreadyPlayed) {
            sfx.Play();
            alreadyPlayed = true;
        }
    }
}
