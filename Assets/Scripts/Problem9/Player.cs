using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace problem9
{
    public class Player : MonoBehaviour
    {
        private Rigidbody2D rigidBody2D;
        public GameObject gameOverPanel;
        public float speed;
        public int currentScore;


        // Start is called before the first frame update
        void Start()
        {
            rigidBody2D = GetComponent<Rigidbody2D>();
        }
        private void Update()
        {
            Movement();
        }

        private void Movement()
        {
            var force = new Vector2(0f, 0f);
            if (Input.GetKeyDown(KeyCode.W))
            {
                var north = new Vector2(0f, 1f);
                force = north;
                rigidBody2D.velocity = force.normalized * speed;
            }
            else if (Input.GetKeyDown(KeyCode.D))
            {
                var east = new Vector2(1f, 0f);
                force = east;
                rigidBody2D.velocity = force.normalized * speed;
            }
            else if (Input.GetKeyDown(KeyCode.S))
            {
                var south = new Vector2(0f, -1f);
                force = south;
                rigidBody2D.velocity = force.normalized * speed;
            }
            else if (Input.GetKeyDown(KeyCode.A))
            {
                var west = new Vector2(-1f, 0f);
                force = west;
                rigidBody2D.velocity = force.normalized * speed;
            }

        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            var ball = collision.gameObject.GetComponent<Ball>();
            if (ball != null)
            {
                //gameover here
                gameObject.SetActive(false);
                gameOverPanel.SetActive(true);
                Invoke("RestartGame",3f);
            }
        }

        private void RestartGame()
        {
            SceneManager.LoadScene("Problem 9");
        }
    }
}

