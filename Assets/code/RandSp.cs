using System.Collections;
using UnityEngine;

// ���� ���� ����
public class RandSp : MonoBehaviour
{
    // ��ȯ�� ������Ʈ
    public GameObject rangeObject;
    // ��ȯ�� ���
    BoxCollider2D rangeCollider;
    // ��ȯ�� �ð�
    public float  delay = 3f;

    private void Awake()
    {
        rangeCollider = rangeObject.GetComponent<BoxCollider2D>();
        if (rangeCollider == null)
        {
            Debug.LogError("�������");
        }
    }

    Vector3 Return_RandomPosition()
    {
        Vector3 originPosition = rangeObject.transform.position;
        // �ݶ��̴��� ����� �������� bound.size ���
        float range_X = rangeCollider.bounds.size.x;
        float range_Y = rangeCollider.bounds.size.y;

        float randomX = Random.Range((range_X / 2) * -1, range_X / 2);
        float randomY = Random.Range((range_Y / 2) * -1, range_Y / 2);
        Vector3 randomPosition = new Vector3(randomX, randomY, 0f);

        Vector3 respawnPosition = originPosition + randomPosition;
        return respawnPosition;
    }

    // ��ȯ�� Object
    public GameObject weapon;
    private void Start()
    {
        // 1�ʸ��� �ѹ� ����
        StartCoroutine(RandomRespawn_Coroutine());
    }

    IEnumerator RandomRespawn_Coroutine()
    {
        // while�� �ٲٱ�
        while (true)
        {
            yield return new WaitForSeconds(delay);

            // ���� ��ġ �κп� ������ ���� �Լ� Return_RandomPosition() �Լ� ����
            Instantiate(weapon, Return_RandomPosition(), Quaternion.identity);
        }
    }
}
