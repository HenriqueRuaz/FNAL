using UnityEngine;

public class OfficeLook : MonoBehaviour {
    public enum PanState {
        Office,
        Left,
        Right
    }

    [Header("Office")]
    public float officeCenterX = 0f;
    public float officeSwayLimit = 2f;
    public float deadZone = 0.1f;
    public float iconThreshold = 0.3f;

    [Header("Paredes")]
    public float wallLeftX = -19.38f;
    public float wallRightX = 19.38f;

    [Header("Velocidade")]
    public float swaySpeed = 3f;
    public float jumpSpeed = 8f;

    [Header("Cooldown")]
    public float iconCooldownTime = 0.5f;

    public PanState state { get; private set; } = PanState.Office;
    public bool isNearLeft {
        get; private set;
    }
    public bool isNearRight {
        get; private set;
    }

    public bool CanUseReturnIcon => iconCooldown <= 0f;

    private float targetX;
    private float iconCooldown;

    void Awake() {
        targetX = officeCenterX;

        Vector3 pos = transform.position;
        pos.x = officeCenterX;
        transform.position = pos;
    }

    void Update() {
        iconCooldown -= Time.deltaTime;

        if(state == PanState.Office) {
            UpdateOffice();
        } else {
            UpdateWall();
        }

        MoveCamera();
    }

    void UpdateOffice() {
        float mouse = Input.mousePosition.x / Screen.width - 0.5f;

        float sway = 0f;

        if(Mathf.Abs(mouse) > deadZone) {
            float t = Mathf.InverseLerp(deadZone, 0.5f, Mathf.Abs(mouse));
            sway = Mathf.Sign(mouse) * Mathf.Lerp(0f, officeSwayLimit, t);
        }

        targetX = officeCenterX + sway;

        isNearLeft = sway <= -officeSwayLimit + iconThreshold;
        isNearRight = sway >= officeSwayLimit - iconThreshold;
    }

    void UpdateWall() {
        targetX = state == PanState.Left ? wallLeftX : wallRightX;

        isNearLeft = false;
        isNearRight = false;
    }

    void MoveCamera() {
        float speed = state == PanState.Office ? swaySpeed : jumpSpeed;

        Vector3 pos = transform.position;
        pos.x = Mathf.Lerp(pos.x, targetX, speed * Time.deltaTime);
        transform.position = pos;
    }

    public void GoToOffice() {
        state = PanState.Office;
    }

    public void GoToLeft() {
        state = PanState.Left;
        iconCooldown = iconCooldownTime;
    }

    public void GoToRight() {
        state = PanState.Right;
        iconCooldown = iconCooldownTime;
    }
}