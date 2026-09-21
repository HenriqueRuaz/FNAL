using UnityEngine;

public class DoorController : MonoBehaviour {
    [Header("Posição quando fechada")]
    public float closedY;

    [Header("Velocidade")]
    public float moveSpeed = 8f;

    // Estado real da porta
    public bool IsClosed {
        get; private set;
    }

    // Estado para o qual a porta está a ir
    public bool TargetClosed {
        get; private set;
    }

    // Está atualmente a mover-se?
    public bool IsMoving {
        get; private set;
    }

    private float openY;
    private float targetY;

    void Awake() {
        openY = transform.position.y;
        targetY = openY;

        IsClosed = false;
        TargetClosed = false;
        IsMoving = false;
    }

    void Update() {
        if(!IsMoving)
            return;

        Vector3 pos = transform.position;

        pos.y = Mathf.MoveTowards(
            pos.y,
            targetY,
            moveSpeed * Time.deltaTime
        );

        transform.position = pos;

        if(Mathf.Approximately(pos.y, targetY)) {
            pos.y = targetY;
            transform.position = pos;

            IsMoving = false;

            // Agora sim, atualizamos o estado real
            IsClosed = TargetClosed;
        }
    }

    public void ToggleDoor() {
        if(IsMoving)
            return;

        TargetClosed = !IsClosed;

        targetY = TargetClosed ? closedY : openY;

        IsMoving = true;
    }
}