using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerX : MonoBehaviour
{
    public bool gameOver = false;
    public ParticleSystem _bombParticle;
    public ParticleSystem _coinParticle;
    private AudioSource _playerAD;
    public AudioClip _coinSound;
    public AudioClip _bombSound;
    public float gravityModifier;
    public float speed;


    // Start is called before the first frame update
    void Start()
    {
        _playerAD = GetComponent<AudioSource>();
        Physics.gravity *= (gravityModifier * Time.deltaTime);
    }

    // Update is called once per frame
    void Update()
    {
        float minYRange = 2.5f;
        float maxYRange = 14.5f;
        bool verticalMovement = Input.GetKey(KeyCode.Space);
        if (verticalMovement && !gameOver)
        {
            transform.Translate(Vector3.up * Time.deltaTime * speed);
        }

        float clampY = Mathf.Clamp(transform.position.y, minYRange, maxYRange);
        transform.position = new Vector3(transform.position.x,clampY, transform.position.z);

    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Bomb"))
        {
            gameOver = true;
            _bombParticle.Play();
            _playerAD.PlayOneShot(_bombSound, 1.0f);
            Destroy(other.gameObject);
        }
        if (other.gameObject.CompareTag("Money"))
        {
            _coinParticle.Play();
            _playerAD.PlayOneShot(_coinSound, 1.0f);
        }

    }

}
