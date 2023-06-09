using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class BombExplosion : MonoBehaviour
{
    [SerializeField] public float ExplosionRadius = 1.5f;
    [SerializeField] public float ExplosionForce = 10.0f;
    private GameObject Player;
    public static bool Knocked = false;
    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        Collider[] colliders = Physics.OverlapBox(GameObject.Find("Player").transform.position, new Vector3(5,0.1f,5));
        try
        {
            if (colliders.Contains(GameObject.Find("Bomb(Clone)").GetComponent<Collider>())) { Knocked = true; }
            else { Knocked = false; }
        }
        catch { Knocked = false; }
        if (gameObject.transform.position.y < -10) { Destroy(gameObject); }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.name.Contains("Floor") | collision.collider.name.Contains("WorkBench") | collision.collider.name.Contains("Tesla Coil")) 
        {
            Collider[] Objects = Physics.OverlapSphere(gameObject.transform.position,ExplosionRadius);
            foreach (Collider hit in Objects) 
            {
                Rigidbody rb = hit.GetComponent<Rigidbody>();
                if (rb != null) 
                {
                    rb.AddExplosionForce(ExplosionForce, gameObject.transform.position, ExplosionRadius,0.0f,ForceMode.VelocityChange);
                }            
            }
            Instantiate(GameObject.Find("Bomb Explosion Partical Effect"),gameObject.transform.position,new Quaternion(0,0,0,0));
            if (!GameObject.Find("Bomb Explosion Partical Effect(Clone)").GetComponent<ParticleSystem>().isPlaying) { Destroy(GameObject.Find("Bomb Explosion Partical Effect(Clone)")); }
            Destroy(gameObject);
        }
    }
}
