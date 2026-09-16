using UnityEngine;

public class CanvasFade : MonoBehaviour {
    public float fadeDuration = 1f;
    private CanvasGroup cg;
    private float timer = 0f;
    private bool fading = false;

    void Start() {
        cg = GetComponent<CanvasGroup>();
    }

    public void StartFade() {
        fading = true;
        timer = 0f;
    }

    void Update() {
        if(!fading)
            return;

        timer += Time.deltaTime;
        cg.alpha = Mathf.Lerp(1f, 0f, timer / fadeDuration);

        if(cg.alpha <= 0f) {
            fading = false;
        }
    }
}
