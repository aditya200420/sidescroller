using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class EnemyController : GazePointer
{
    public GameObject particleEffect;
    public Animator enemyModel;
    public float speed;
    Vector3 endPos;

    // Start is called before the first frame update
    void Start()
    {
        endPos = 1.5f * (transform.position - Vector3.zero).normalized;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.Lerp(transform.position, endPos, speed * Time.deltaTime);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
            Attack();
    }
    public override void OnPointerDown(PointerEventData eventData)
    {
        base.OnPointerDown(eventData);
        Death();
    }
    public void Death()
    {
        particleEffect.SetActive(true);
        particleEffect.transform.SetParent(null);
        Destroy(gameObject);
    }
    public void Attack()
    {
        enemyModel.SetTrigger("attack");
    }
       
}
