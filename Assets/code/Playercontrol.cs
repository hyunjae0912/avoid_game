using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//�÷��̾� ä�� ����� ���...
public class PlayerCounter : MonoBehaviour
{
    public int PlayerHealth = 3;
    // Start is called before the first frame update
    public void TakeDamage()
    {
        PlayerHealth--;
        if (PlayerHealth <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        //�ӽ� ����
        Destroy(gameObject);


        //�� ��ȯ �ֱ�
    }
}