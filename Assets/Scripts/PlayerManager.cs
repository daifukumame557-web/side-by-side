using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public float moveSpeed = 5f;
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();

        //（奥行き）の移動と、余計な回転固定する
        rb.constraints = RigidbodyConstraints.FreezePositionZ |
                         RigidbodyConstraints.FreezeRotationX |
                         RigidbodyConstraints.FreezeRotationY |
                         RigidbodyConstraints.FreezeRotationZ;
    }

    void Update()
    {
        float moveDirection = 0f;

        if (Input.GetKey(KeyCode.D))
        {
            moveDirection = 1f;
            transform.rotation = Quaternion.Euler(0, 90f, 0);
        }
        else if (Input.GetKey(KeyCode.A))
        {
            moveDirection = -1f;
            transform.rotation = Quaternion.Euler(0, -90f, 0);
        }

        // Y軸（現在の落下速度など）はそのままキープし、X軸の速度だけを書き換える
        rb.linearVelocity = new Vector3(moveDirection * moveSpeed, rb.linearVelocity.y, 0f);
    }
}
