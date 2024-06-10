using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyController : MonoBehaviour
{
    public Animator enemyAnimator;
    BoxCollider enemyBoxC;

    Vector3 initialColliderCenter;
    Vector3 initialColliderSize;

    public int enemyLevel;
    public bool enemyGameOver;
    public Text enemyLevelText;

    [SerializeField] Transform[] patrolPoints;
    [SerializeField] float moveSpeed = 2f;
    [SerializeField] float waitTime = 1f;
    int currentPointIndex = 0;
    bool waiting = false;
    bool patrolling = false;

    // Start is called before the first frame update
    void Start()
    {
        enemyAnimator = GetComponent<Animator>();
        enemyBoxC = GetComponent<BoxCollider>();

        enemyLevel = Random.Range(1, 5);

        initialColliderCenter = enemyBoxC.center;
        initialColliderSize = enemyBoxC.size;

        UpdateLevelText();
        Invoke("StartPatrol", 3f);
    }

    void LateUpdate()
    {
        if (enemyBoxC != null)
        {
            enemyBoxC.center = initialColliderCenter;
            enemyBoxC.size = initialColliderSize;
        }
        if (patrolling && !waiting && !enemyGameOver)
        {
            Patrol();
        }
    }

    void UpdateLevelText()
    {
        if (enemyLevelText != null)
        {
            enemyLevelText.text = "LVL. " + enemyLevel;
        }
    }

    void EnemyCircle()
    {

        enemyAnimator.SetBool("isCircle", true);
    }

    void StartPatrol()
    {
        enemyAnimator.SetBool("isCircle", true);
        Invoke("BeginPatrol", 5f);
    }

    void BeginPatrol()
    {
        enemyAnimator.SetBool("isCircle", false);
        patrolling = true;
    }

    void Patrol()
    {
        if (patrolPoints.Length == 0)
        {
            return;
        }

        enemyAnimator.SetBool("isEnemyPatrolling", true);

        Transform targetPoint = patrolPoints[currentPointIndex];
        Vector3 direction = targetPoint.position - transform.position;

        if (direction != Vector3.zero)
        {
            Vector3 directionToNextPoint = patrolPoints[(currentPointIndex + 1) % patrolPoints.Length].position - patrolPoints[currentPointIndex].position;

            if (Vector3.Dot(transform.forward, directionToNextPoint) > 0)
            {
                transform.Rotate(0f, 180, 0f);
            }
        }

        transform.position = Vector3.MoveTowards(transform.position, targetPoint.position, moveSpeed * Time.deltaTime);

        if (Vector3.Distance(transform.position, targetPoint.position) < 0.1f)
        {
            waiting = true;
            StartCoroutine(WaitAtPoint());
        }



    }

    IEnumerator WaitAtPoint()
    {
        yield return new WaitForSeconds(waitTime);
        waiting = false;

        currentPointIndex = (currentPointIndex + 1) % patrolPoints.Length;
    }
}
