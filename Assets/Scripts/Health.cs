using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    private float _health = 100;

    public float maxHealth;
    // Start is called before the first frame update
    void Start()
    {
        _health = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionStay2D(Collision2D col)
    {
        if (col.transform.tag == "Lava")
        {
            _health -= 10 * Time.deltaTime;
            Debug.Log(_health);
        }
    }
}
