using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    [SerializeField]
    GameObject bullet;

    float fireRate;
    float nextFire;
    public int lives;
    bool canBeHit = true;
    bool isRed = false;
    private float invincibilityTime = 0.15f;
    private float invincibilityDuration = 0.5f;
    Color tempColor = new Color();
    Renderer temp;
    // Start is called before the first frame update
    void Start()
    {
        lives = 3;
        fireRate = 2f;
        nextFire = Time.time;
        temp = gameObject.GetComponent<Renderer>();
        tempColor=temp.material.color;
    }

    // Update is called once per frame
    void Update()
    {
        CheckIfTimeToFire();
        if (lives <= 0)
        {
            StartCoroutine(Die());
        }
    }
    void CheckIfTimeToFire()
    {
        if (Time.time > nextFire)
        {
            Instantiate(bullet, transform.position, Quaternion.identity);
            nextFire = Time.time + fireRate;
        }

    }
    public void Hit()
    {
        if (!canBeHit) return;
        canBeHit = false;

        lives--;
        StartCoroutine(Invincible());
    }

    public IEnumerator Die()
    {
        yield return new WaitForSeconds(1);
        Destroy(gameObject);

        
   
    }


    private IEnumerator Invincible()
    {

        canBeHit = false;

        for (float i = 0; i < invincibilityDuration; i += invincibilityTime)
        {
            if (isRed)
            {
                temp.material.color = Color.red;

            }
            else
            {
                temp.material.color = tempColor;
            }
            isRed = !isRed;
            yield return new WaitForSeconds(invincibilityTime);
        }

       temp.material.color = tempColor;
        canBeHit = true;
    }
}
