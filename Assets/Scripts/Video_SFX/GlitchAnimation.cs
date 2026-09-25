using UnityEngine;
using UnityEngine.UI;

public class GlitchAnimation : MonoBehaviour {
    public Image glitchImage;
    public Sprite[] frames;
    public float frameRate = 0.05f;
    public AudioSource sfx;

    private int currentFrame = 0;
    private float timer = 0f;
    public bool isPlaying = false;

    private bool soundPlayed = false;

    void Update() {
        if(!isPlaying || frames.Length == 0)
            return;

        // Tocar som só uma vez quando o glitch aparece
        if(!soundPlayed) {
            sfx.Play();
            soundPlayed = true;
        }

        timer += Time.deltaTime;

        if(timer >= frameRate) {
            timer = 0f;
            currentFrame++;

            if(currentFrame >= frames.Length) {
                isPlaying = false;
                soundPlayed = false; // reset para próxima vez
                gameObject.SetActive(false);
                return;
            }

            glitchImage.sprite = frames[currentFrame];
        }
    }

    public void StartGlitch() {
        if(frames.Length == 0)
            return;

        gameObject.SetActive(true);
        isPlaying = true;
        timer = 0f;
        currentFrame = 0;
        soundPlayed = false; // pronto para tocar som
        glitchImage.sprite = frames[currentFrame];
    }
}
