using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Particle : MonoBehaviour
{
    public enum ParticleType
    {
        Water,
        Lava,
        Tar,
        Oil,
        Bedrock
    }

    public ParticleType particleType;
    public float chageTime = .25f;

    // Update is called once per frame
    void Update()
    {
        switch (particleType)
        {
            case ParticleType.Water:

                break;
            case ParticleType.Lava:

                break;
            case ParticleType.Tar:

                break;
            case ParticleType.Oil:

                break;
            case ParticleType.Bedrock:

                break;
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.GetComponent<Particle>().particleType == ParticleType.Lava &&
            particleType == ParticleType.Water || 
            other.gameObject.GetComponent<Particle>().particleType == ParticleType.Water &&
            particleType == ParticleType.Lava)
        {
            chageTime -= .1f;
            if (chageTime <= 0)
            {
                particleType = ParticleType.Bedrock;
                gameObject.GetComponent<SpriteRenderer>().color = Color.black;
                gameObject.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
            }
        }
    }
}
