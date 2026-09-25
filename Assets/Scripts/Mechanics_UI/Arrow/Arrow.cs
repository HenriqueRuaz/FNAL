using UnityEngine;

public class Arrow : MonoBehaviour {
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
        bool shouldShow =
            direction == Direction.Left
            ? officeLook.isNearLeft
            : officeLook.isNearRight;

        sr.enabled = shouldShow;
        col.enabled = shouldShow;
    }

    void OnMouseEnter() {
        if(direction == Direction.Left)
            officeLook.GoToLeft();
        else
            officeLook.GoToRight();
    }
}