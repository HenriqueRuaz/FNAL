using UnityEngine;

public class DoorController : MonoBehaviour {
    public float closedY;
    public float moveSpeed = 8f;

    public bool IsClosed {
        get; private set;
    }
    public bool TargetClosed {
        get; private set;
    }
    public bool IsMoving {
        get; private set;
    }

    private float openY;
    private float targetY;

    void Awake() {
        openY = transform.position.y;
        targetY = openY;
    }

    void Update() {
        MoveDoor();
    }

    void MoveDoor() {
        if(!IsMoving)
            return;

        Vector3 pos = transform.position;

        pos.y = Mathf.MoveTowards(
            pos.y,
            targetY,
            moveSpeed * Time.deltaTime
        );

        transform.position = pos;

        if(Mathf.Approximately(pos.y, targetY))
            FinishMovement();
    }

    void FinishMovement() {
        IsMoving = false;
        IsClosed = TargetClosed;
    }

    public void ToggleDoor() {
        if(IsMoving)
            return;

        TargetClosed = !IsClosed;
        targetY = TargetClosed ? closedY : openY;
        IsMoving = true;
    }
}