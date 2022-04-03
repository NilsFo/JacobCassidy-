using System;
using System.Collections;
using System.Collections.Generic;
using System.Windows.Forms;
using UnityEngine;

public class CultistPointOfInterest : MonoBehaviour
{
    public List<GameObject> congregation;
    public int congregationSize;

    public bool fillOnStart = true;
    public bool fillOnCultistDeath = true;

    public GameObject zombiePrefab;

    private void Start()
    {
        if (fillOnStart)
        {
            FillCompletely();
        }
    }

    public void FillCompletely()
    {
        while (NeedsZombie())
        {
            GameObject newZombie = Instantiate(zombiePrefab, transform.position, Quaternion.Euler(Vector3.up));
            AddZombie(newZombie);
            newZombie.transform.position = transform.position;
        }
    }

    public void AddZombie(GameObject newZombie)
    {
        EnemyBehaviourScript script = newZombie.GetComponent<EnemyBehaviourScript>();
        congregation.Add(script.gameObject);
        script.OnDeath += ZombieOnDeath;
    }

    private void ZombieOnDeath(GameObject zombie)
    {
        congregation.Remove(zombie);
    }

    public bool NeedsZombie()
    {
        return congregation.Count < congregationSize;
    }
}