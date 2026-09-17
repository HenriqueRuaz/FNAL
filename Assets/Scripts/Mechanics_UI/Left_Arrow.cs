using UnityEngine;

public class Left_Arrow : MonoBehaviour {
    public OfficeLook officeLook;

    private SpriteRenderer sr;
    private Collider2D col;

    void Awake() {
        sr = GetComponent<SpriteRenderer>();
        col = GetComponent<Collider2D>();
    }

    void Update() {
        bool shouldShow = officeLook.isNearLeft;

        sr.enabled = shouldShow;
        col.enabled = shouldShow;
    }

    void OnMouseEnter() {
        officeLook.GoToLeft();
    }
}