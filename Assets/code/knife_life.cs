using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knife_life : MonoBehaviour
{
    public GameObject player;
    public float knife_Delay = 5f;
    public float speed = 3f;  // �̵� �ӵ�

    private Vector2 moveDirection;
    private bool hasTarget = false;
    private PlayerCounter playerHealth;

    void Awake()
    {
        if (player == null)
        {
            //�÷��̾� ã��
            player = GameObject.FindGameObjectWithTag("Player");
        }

        if (player != null)
        {
            // �÷��̾��� Health ������Ʈ�� ã��
            playerHealth = player.GetComponent<PlayerCounter>();

            // �÷��̾� ��ġ ����
            Vector2 targetPosition = player.transform.position;
            hasTarget = true;

            moveDirection = (targetPosition - (Vector2)transform.position).normalized;

            // �ð� ������ ������
            Destroy(gameObject, knife_Delay);
        }
    }

    void Update()
    {
        if (hasTarget)
        {
            transform.position += (Vector3)moveDirection * speed * Time.deltaTime;
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        // �浹�� ��ü�� �÷��̾��� ���
        if (collision.gameObject == player)
        {
            // �÷��̾�� �������� ����
            if (playerHealth != null)
            {
                playerHealth.TakeDamage();
            }

            // ������ �ı�
            Destroy(gameObject);
        }
    }
}
