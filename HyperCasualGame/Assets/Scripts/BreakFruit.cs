using UnityEngine;
using System.Collections;

public class BreakFruit : MonoBehaviour
{
    public Transform parts;
    private Transform breakable = null;

    public void Run()
    {   
        if (breakable) return;

        breakable = (Transform)Instantiate(parts, transform.position, transform.rotation);
        breakable.localScale = transform.localScale;

        if (breakable.GetComponent<AudioSource>())
            breakable.GetComponent<AudioSource>().pitch = Random.Range(0.84f, 1.28f);

        foreach (Transform part in breakable)
        {
            part.GetComponent<Rigidbody>().AddExplosionForce(200f, transform.position, 3.0f, 0.05f);

            float time = Random.Range(5f, 30f);
            Destroy(part.gameObject, time);
        }

        Destroy(breakable.gameObject, 30f);
        Destroy(gameObject);
    }
}
