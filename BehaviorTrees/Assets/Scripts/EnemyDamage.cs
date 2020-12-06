using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    [SerializeField]
    private LayerMask mask;
    [SerializeField]
    private float damage;
    [SerializeField]
    private GameObject[] enemyAIs;

    private void Start()
    {
        enemyAIs = GameObject.FindGameObjectsWithTag("Enemy");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
            Damage();
    }

    private void Damage()
    {
        foreach(var enemy in enemyAIs)
        {
            float distance = Mathf.Abs(Vector3.Distance(transform.position, enemy.transform.position));
            if(distance <= 10.0f)
            {
                EnemyAI ai = enemy.GetComponent<EnemyAI>();
                ai.TakeDamage(damage);
            }
        }
    }
}
