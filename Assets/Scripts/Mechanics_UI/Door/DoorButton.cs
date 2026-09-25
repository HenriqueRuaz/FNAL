using UnityEngine;

public class DoorButton : MonoBehaviour {
    public DoorController door;

    public SpriteRenderer idleSprite;
    public SpriteRenderer closedSprite;

    void Start() {
        UpdateSprites();
    }

    void OnMouseDown() {
        ToggleDoor();
    }

    void ToggleDoor() {
        if(door.IsMoving)
            return;

        door.ToggleDoor();
        UpdateSprites();
    }

    void UpdateSprites() {
        idleSprite.enabled = !door.TargetClosed;
        closedSprite.enabled = door.TargetClosed;
    }
}