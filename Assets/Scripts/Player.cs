using Unity.Mathematics;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    [SerializeField] private float speed = 5.0f;
    [SerializeField] private int health = 10;
    [SerializeField] private GameObject replayButton;
    [SerializeField] private Text currentHealth;
    [SerializeField] private Text score;
    private int _score = 0;
    private GameObject _currentFloor;
    // Update is called once per frame
    void Update()
    {
        var input = Input.GetAxis("Horizontal");
        transform.Translate(input * speed * Time.deltaTime, 0, 0);
    }

    private void OnCollisionEnter2D(Collision2D col)
    {

        if (col.gameObject.CompareTag("Platform"))
        {
            if (col.contacts[0].normal == Vector2.up)
            {
                _currentFloor = col.gameObject;
                ModifyHealth(1);
                _score += 1;

            }
        }
        if (col.gameObject.CompareTag("Spike"))
        {
            if (col.contacts[0].normal == Vector2.up)
            {
                _currentFloor = col.gameObject;
                ModifyHealth(-3);
                _score += 1;
            }
        }
        if (col.gameObject.CompareTag("Ceiling"))
        {

            _currentFloor.GetComponent<Collider2D>().enabled = false;
            ModifyHealth(-5);
        }

        if (col.gameObject.CompareTag("Finish"))
        {
            Finish();
        }

        score.text = _score.ToString();
    }

    private void Finish()
    {
        Time.timeScale = 0;
        replayButton.SetActive(true);
    }

    private void ModifyHealth(int hp)
    {
        health = math.clamp(hp + health, 0, 10);
        currentHealth.text = health.ToString();
        if (health == 0)
        {
            Finish();
        }

        
    }

    public void Replay()
    {
        Time.timeScale = 1.0f;
        SceneManager.LoadScene("SampleScene");
    }
}
