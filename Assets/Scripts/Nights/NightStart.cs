using UnityEngine;
using UnityEngine.Rendering.Universal;

public class StartPlay : MonoBehaviour {
    [Header("Luz da lâmpada")]
    public Light2D officeLight;

    public float startRadius = 1f;
    public float finalRadius = 300f;

    [Header("Luz ambiente")]
    public Light2D globalLight;

    public float finalGlobalIntensity = 0.3f;

    [Header("Duração")]
    public float lightDuration = 6f;

    void Start() {
        officeLight.pointLightOuterRadius = startRadius;
        globalLight.intensity = 0f;
    }

    void Update() {
        float time = Time.timeSinceLevelLoad;

        // -------------------------
        // LUZ DA LÂMPADA
        // -------------------------

        float lightT = time / lightDuration;
        lightT = Mathf.Clamp01(lightT);

        // Começa devagar e acelera
        lightT = lightT * lightT;

        officeLight.pointLightOuterRadius =
            Mathf.Lerp(startRadius, finalRadius, lightT);


        // -------------------------
        // LUZ AMBIENTE
        // -------------------------

        // Só começa depois de 1 segundo
        float globalT = Mathf.InverseLerp(
            1f,
            lightDuration,
            time
        );

        globalT = Mathf.Clamp01(globalT);

        globalT = Mathf.Pow(globalT, 1.3f);

        globalLight.intensity =
            Mathf.Lerp(
                0f,
                finalGlobalIntensity,
                globalT
            );
    }
}