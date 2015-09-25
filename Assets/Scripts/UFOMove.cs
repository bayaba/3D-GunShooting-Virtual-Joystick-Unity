using UnityEngine;
using System.Collections;

public class UFOMove : MonoBehaviour
{
    public GameObject Explosion;
	
	void Update()
	{
        transform.Translate(Vector3.forward * 10.0f * Time.deltaTime);
	}

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.name == "Main Camera")
        {
            Destroy(gameObject);
        }
    }

    void OnParticleCollision(GameObject tar)
    {
        if (tar.name == "Bullet")
        {
            Instantiate(Explosion, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
