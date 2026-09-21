using UnityEngine;

public class DoorButton : MonoBehaviour {
    public DoorController door;

    public SpriteRenderer idleSprite;
    public SpriteRenderer closedSprite;

    void Start() {
        UpdateSprites();
    }

    void OnMouseDown() {
        if(door.IsMoving)
            return;

        door.ToggleDoor();

        // Muda imediatamente
        UpdateSprites();
    }

    void UpdateSprites() {
        idleSprite.enabled = !door.TargetClosed;
        closedSprite.enabled = door.TargetClosed;
    }
}