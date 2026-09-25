using UnityEngine;

public class Arrow_Return : MonoBehaviour {
    public enum Direction {
        Left,
        Right
    }

    public Direction direction;
    public OfficeLook officeLook;

    private SpriteRenderer sr;
    private Collider2D col;

    void Awake() {
        sr = GetComponent<SpriteRenderer>();
        col = GetComponent<Collider2D>();
    }

    void Update() {
        UpdateVisibility();
    }

    void UpdateVisibility() {
        bool correctWall =
            direction == Direction.Left
            ? officeLook.state == OfficeLook.PanState.Left
            : officeLook.state == OfficeLook.PanState.Right;

        bool shouldShow =
            correctWall &&
            officeLook.CanUseReturnIcon;

        sr.enabled = shouldShow;
        col.enabled = shouldShow;
    }

    void OnMouseEnter() {
        officeLook.GoToOffice();
    }
}