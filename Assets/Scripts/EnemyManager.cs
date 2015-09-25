using UnityEngine;
using System.Collections;

public class EnemyManager : MonoBehaviour
{
    public GameObject EnemyUFO;

	void Start()
	{
        StartCoroutine(CreateUFO());
	}

    IEnumerator CreateUFO()
    {
        while (true)
        {
            // create UFO on the camera position
            GameObject ufo = Instantiate(EnemyUFO, Camera.main.transform.position, Quaternion.identity) as GameObject;

            // UFO rotate random directions
            ufo.transform.rotation = Quaternion.Euler(new Vector3(Random.Range(0f, 360), Random.Range(0f, 360f), Random.Range(0f, 360f)));

            ufo.transform.Translate(Vector3.forward * 100f);

            // look at the camera for UFO
            ufo.transform.LookAt(Camera.main.transform);

            yield return new WaitForSeconds(0.3f); 
        }
    }
}
