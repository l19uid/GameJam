using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FluidSpawner : MonoBehaviour
{
    public int count = 100;

    public GameObject particle;
    
    // Start is called before the first frame update
    void Start()
    {
        SpawnParticles();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.G))
            SpawnParticles();
    }
    
    private void SpawnParticles()
    {
        for (int i = 0; i < count; i++)
        {
            StartCoroutine(SpawnParticlesOverTime(i));
        }
    }
    public IEnumerator SpawnParticlesOverTime(float time)
    {
        yield return new WaitForSeconds(time/1000);
        Vector3 randomPosition = Random.insideUnitCircle * 2;
        Instantiate(particle, transform.position + randomPosition, Quaternion.identity);
    }
}
