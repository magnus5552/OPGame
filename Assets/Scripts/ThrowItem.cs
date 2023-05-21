using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowItem : MonoBehaviour
{
    [SerializeField]
    private float speed;
    [SerializeField]
    private GameObject player;
    [SerializeField]
    private Transform enemy;

    
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        var inventory = player.GetComponent<Inventory>();
        var item = inventory.sprites.Pop();

        if (item is not null && Input.GetKeyDown(KeyCode.Space))
            Throw(item);
    }

    private void Throw(GameObject item)
    {
        var enemyPosition = enemy.position;
        var playerPosition = player.transform.position;
        var direction = enemyPosition - playerPosition;
        // ballistic
        /*while (true)
        {
            // ������������ ���������� ����� ��������� � �������� �������
            float distance = Vector3.Distance(startPos, target.position);
            // ������������ ������, �� ������� ����� ������� ���
            float maxHeight = startPos.y + height;
            // ������������ ���� ������
            float angle = Mathf.Atan((maxHeight - target.position.y) / distance) * Mathf.Rad2Deg;
            // ������������ �������� �� ��� X � Y
            float velX = Mathf.Sqrt(distance * Physics.gravity.magnitude / Mathf.Sin(2 * angle));
            float velY = velX * Mathf.Sin(angle);

            // ������� ������ ����������� �������� ����
            Vector3 dir = (target.position - startPos).normalized;
            // ������ �������� � ����������� �������� ����
            GetComponent<Rigidbody>().velocity = new Vector3(dir.x * velX, velY, dir.z * velX);

            // �������, ���� ��� �� ��������� ����
            yield return new WaitForSeconds(0.1f);
            if (Vector3.Distance(transform.position, target.position) < 1f)
            {
                break;
            }
        }*/

    }
    
}
