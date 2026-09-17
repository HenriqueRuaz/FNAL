using UnityEngine;

public class Return_From_Right : MonoBehaviour {
    public OfficeLook officeLook;

    private SpriteRenderer sr;
    private Collider2D col;

    void Awake() {
        sr = GetComponent<SpriteRenderer>();
        col = GetComponent<Collider2D>();
    }

    void Update() {
        bool shouldShow =
            officeLook.state == OfficeLook.PanState.Right &&
            officeLook.CanUseReturnIcon;

        sr.enabled = shouldShow;
        col.enabled = shouldShow;
    }

    void OnMouseEnter() {
        officeLook.GoToOffice();
    }
}