using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Behavior : MonoBehaviour
{
    private float SleepTimer;
    private Vector3 cellPoint;

    // Start is called before the first frame update
    void Start()
    {
    }


    private void FixedUpdate()
    {
        switch (gameObject.GetComponent<Stats>().status)
        {
            case Stats.Status.dead:
                break;
            case Stats.Status.decide:
                Decide();
                break;
            case Stats.Status.patrool:
                Patrool();
                break;
            case Stats.Status.await:
                Wait();
                break;
            default:
                break;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "Cube(Clone)" && !other.isTrigger)
            Fighter.FightNpc(this.gameObject, other.gameObject);
    }

    private void Decide()
    {
        float sizePlane = 25;
        Stats stats = gameObject.GetComponent<Stats>();
        if (1 == Random.Range(0, 2))
        {
            SleepTimer = stats.WaitTime;
            gameObject.GetComponent<Stats>().status = Stats.Status.await;
        }
        else
        {
            do
            {
                cellPoint = transform.position + stats.Radius * UnityEngine.Random.insideUnitSphere;
                } while (!(cellPoint.x > -sizePlane/2 && cellPoint.z > -sizePlane/2 && cellPoint.x < sizePlane/2 && cellPoint.z < sizePlane/2));
            cellPoint.y = transform.localScale.y/2;
            gameObject.GetComponent<Stats>().status = Stats.Status.patrool;
        }
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void Patrool()
    {
        var movement = (cellPoint - transform.position).normalized * gameObject.GetComponent<Stats>().Speed * Time.fixedDeltaTime;
        var deltaDist = (cellPoint - transform.position);
        if (movement.magnitude > deltaDist.magnitude)
        {
            movement = deltaDist;
        }
        transform.Translate(movement);
        deltaDist = (cellPoint - transform.position);
        if (deltaDist.magnitude < 1e-04)
        {
            gameObject.GetComponent<Stats>().status = Stats.Status.decide;
        }
    }

    private void Wait()
    {
        SleepTimer -= Time.fixedDeltaTime;
        if (SleepTimer <= 0.0f)
        {
            gameObject.GetComponent<Stats>().status = Stats.Status.decide;
        }
    }

    public void Fight()
    {

    }

    public void Die()
    {

        Vector3 position = transform.position;
        position.y = transform.localScale.y / 2;
        var expRef = Instantiate(gameObject.GetComponent<Stats>().explousive, position, Quaternion.identity);

        gameObject.GetComponent<Stats>().status = Stats.Status.dead;
        Destroy(gameObject);
        Destroy(expRef, expRef.GetComponent<ParticleSystem>().main.startLifetimeMultiplier);
    }
}
