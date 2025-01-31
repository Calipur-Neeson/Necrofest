using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveRepeatedly : MonoBehaviour
{
    [SerializeField]
    private Transform MovePoint_1, Movepoint_2;
    [SerializeField] 
    private float MoveSpeed = 5f;

    private Transform targetPos;
    private bool firstMovePoint;


    private void Awake()
    {
        if (Random.Range(0, 2) > 1)
        {
            firstMovePoint = false;
            targetPos = Movepoint_2;


        }
        else
        {
            firstMovePoint = true;
            targetPos = MovePoint_1;
        }
    }

    private void Update()
    {
        HandleMovement();
    }
    void HandleMovement()
    {
        transform.position = Vector3.MoveTowards(transform.position, targetPos.position, MoveSpeed * Time.deltaTime);
        if(Vector3.Distance(transform.position, targetPos.position) < 0.1f)
        {
            if(firstMovePoint) 
            {
                firstMovePoint = false;
                targetPos = Movepoint_2;
            }
            else
            {
                firstMovePoint = true;
                targetPos = MovePoint_1;
            }
        }
    }
}
