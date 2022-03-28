using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerLife : MonoBehaviour
{
    public int lives = 5;
    bool canBeHit = true;
    private float invincibilityTime = 0.15f;
    private float invincibilityDuration = 1.5f;
    GameObject Player;
    public IEnumerator Die()
    {
        
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene("GameOverScreen");
    }

    private IEnumerator Invincible()
    {

        canBeHit = false;

        for (float i = 0; i < invincibilityDuration; i += invincibilityTime)
        {
            if (Player.transform.localScale == Vector3.one)
            {
                Player.transform.localScale = Vector3.zero;
               
            }
            else
            {
                Player.transform.localScale = Vector3.one;
            }
            yield return new WaitForSeconds(invincibilityTime);
        }

        Player.transform.localScale = Vector3.one;
        canBeHit = true;
    }

    public void Hit()
    {
        if (!canBeHit) return;
        canBeHit = false;
        
        lives--;
        StartCoroutine(Invincible());
    }
    

    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
    }


    // Update is called once per frame
    void Update()
    {
        

        

        if (lives<=0)
        {
            StartCoroutine(Die());
        }
        
    }
}
