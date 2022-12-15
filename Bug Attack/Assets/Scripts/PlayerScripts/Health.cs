using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Health : MonoBehaviour
{
    [SerializeField] private float startingHealth;
    [SerializeField] private AudioSource gameOverSound;
    private float timeElapsed;

    public float currentHealth { get; private set; }

    private void Awake()
    {
        currentHealth = startingHealth;
    }

    public void TakeDamage(float _damage)
    {
        currentHealth = Mathf.Clamp(currentHealth - _damage, 0, startingHealth);

        if (currentHealth > 0)
        {
            // Player Hurt
        }
        
        if (currentHealth <= 0)
        {
            // Player Dead
           // Die();
            gameOverSound.Play();
            int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
            StartCoroutine(WaitSceneToLoad());
           // Destroy(this.gameObject);

            // TODO: ADD DEATH SCREEN
        }
    }

    private IEnumerator WaitSceneToLoad()
    {
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene("Death");

    }
    //private void Die()
    //{
    //    gameObject.SetActive(false);
    //}

}
