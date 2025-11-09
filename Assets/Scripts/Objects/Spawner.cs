using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject[] objects;
    [SerializeField] private float cooldown;
    [SerializeField] private float startTime;

    // private float timer;

    void Awake()
    {
        InvokeRepeating(nameof(SpawnObject), startTime, cooldown);
    }

    // void Update()
    // {
    //     timer += Time.deltaTime;

    //     if (timer >= cooldown)
    //     {
    //         timer = 0;
    //         SpawnObject();
    //     }
    // }

    private void SpawnObject()
    {
        int randIndex = Random.Range(0, objects.Length);
        GameObject objectt = Instantiate(objects[randIndex], transform.position, Quaternion.identity);

        Rigidbody2D rbObject = objectt.GetComponent<Rigidbody2D>();

        if (rbObject != null)
        {
            rbObject.linearVelocity = new Vector2(Random.Range(-3f, 3f), Random.Range(14f, 18f));
        }
    }
}
