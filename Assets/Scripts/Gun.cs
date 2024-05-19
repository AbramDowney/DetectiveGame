using UnityEngine;

public class Gun : MonoBehaviour {

    public float damage = 10f;
    public float range = 100f;
    public float fireRate = 15f;

    public Camera fpsCam;
    public ParticleSystem muzzelFlash;
    public GameObject impact;
    private float nextTimeToFire = 0f;

    void Update() {

        if (Input.GetButton("Fire1") && Time.time >= nextTimeToFire) {
            nextTimeToFire = Time.time + 1f/fireRate;
            Shoot();
        }
        
        if (Input.GetButtonDown("Fire1")){

            Shoot();

        }

    }

    void Shoot () {

        muzzelFlash.Play();



        RaycastHit hit;
        if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range)){
            GameObject.Find("MainCamera").GetComponent<AudioSource>().Play();
            Debug.Log(hit.transform.name);

            Target target = hit.transform.GetComponent<Target>();

            if (target != null){
                target.TakeDamage(damage);
            }

            Instantiate(impact, hit.point, Quaternion.LookRotation(hit.normal));
        }

    }
}
