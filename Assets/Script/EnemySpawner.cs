using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [System.Serializable]
    public class TimedEnemy
    {
        public GameObject enemyPrefab;   // ������ ���� ������
        public float spawnInterval;      // ���� ���� ���� (�� ����)
    }

    public List<TimedEnemy> timedEnemies = new List<TimedEnemy>(); // ������ ���� ����Ʈ
    private Vector3 spawnPosition; // ������ ���� ���� ��ġ ����

    private void Start()
    {
        // ������ ���� ��ġ ����
        spawnPosition = new Vector3(6f, -1.4f, transform.position.z);

        // �� ���ֿ� ���� ������ �������� �����ϵ��� �ڷ�ƾ ����
        foreach (TimedEnemy timedEnemy in timedEnemies)
        {
            StartCoroutine(SpawnTimedEnemy(timedEnemy));
        }
    }

    private IEnumerator SpawnTimedEnemy(TimedEnemy timedEnemy)
    {
        while (true) // ���������� ���� �����ϱ� ���� ���� �ݺ�
        {
            // ������ ���ݸ�ŭ ��� �� ���� ����
            yield return new WaitForSeconds(timedEnemy.spawnInterval);

            if (timedEnemy.enemyPrefab != null)
            {
                Instantiate(timedEnemy.enemyPrefab, spawnPosition, Quaternion.identity);
            }
            else
            {
                Debug.LogWarning("Enemy prefab is missing.");
            }
        }
    }
}
