using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    [SerializeField]
    private SpriteRenderer spriteRenderer;

    private float _speed = 1.0f;
    private float _destroyTime = 10.0f;
    private float _timer = 0.0f;
    
    public void SetSpeed(float speed)
    {
        if(speed < 0)
            speed = 0;
        _speed = speed;
    }

    public void SetDestroyTime(float time)
    {
        if(time < 0)
            time = 0;
        _destroyTime = time;
    }

    public void SetSprite(Sprite sprite)
    {
        spriteRenderer.sprite = sprite;
    }

    private void Update()
    {
        Move(Vector3.left);
        Timer();
    }

    private void Move(Vector3 direction)
    {
        if(gameObject.activeSelf)
            transform.position += Time.deltaTime * direction * _speed;
    }

    private void Timer()
    {
        _timer += Time.deltaTime;
        if (_timer >= _destroyTime)
        {
            // Destroy / ReturnToPool
            Destroy(gameObject); // Just for now - TODO: ReturnToPool

            // Timer reset
            _timer =0.0f;
        }
    }

}
