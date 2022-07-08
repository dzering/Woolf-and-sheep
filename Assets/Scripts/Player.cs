using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SheepsWolf
{
    public class Player : MonoBehaviour, IPlayar
    {
        [SerializeField] private float speed = 2f;

        private void Start()
        {

        }

        public void Move(float x, float z)
        {
            transform.Translate(x * speed * Time.deltaTime, 0, z * speed * Time.deltaTime);
        }
    }
}