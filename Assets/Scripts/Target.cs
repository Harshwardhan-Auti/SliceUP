using UnityEngine;

public class Target : MonoBehaviour
{
    private float maxTorque = 8f;
    private float maxSpeed = 15f;
    private float minSpeed = 12f;
    private float spawnX = 4f;
    private float spwanY = 2f;

    private GameManeger gameManeger;
    private Rigidbody targetRb;

    public int scoreValue;
    public ParticleSystem explosionParticales;
    
    

    void Start()
    {
        targetRb = GetComponent<Rigidbody>();
        targetRb.AddForce(GetForce(), ForceMode.Impulse);
        targetRb.AddTorque(GetTorque(), GetTorque(), GetTorque() );
        transform.position = GetPos();
        gameManeger = GameObject.Find("Game Maneger").GetComponent<GameManeger>();
    }


    void Update()
    {

    }

    Vector3 GetForce()
    {
        return Vector3.up * Random.Range(minSpeed, maxSpeed);

    }

    float GetTorque()
    {

        return Random.Range(-maxTorque, maxTorque);

    }

    Vector3 GetPos()
    {

        return new Vector3(Random.Range(-spawnX, spawnX), -spwanY);

    }

    private void OnMouseDown()
    {
        if (gameManeger.isgameActive)
        {
            Destroy(gameObject);
            gameManeger.UpdateScore(scoreValue);
            Instantiate(explosionParticales, transform.position, explosionParticales.transform.rotation);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);
        if (!gameObject.CompareTag("Bad"))
        {
            gameManeger.GameOver();

        }

       
        
    }

    
}
