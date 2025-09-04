using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Snake : MonoBehaviour
{
    private Vector2 _direction = Vector2.left;
    private float _timer = 7f;
    private float _currentTimer;
    private float _speed;
    private float _moveTimer = 0f;

    private List<Transform> _segments = new List<Transform>();
    public Transform segmentPrefab;
    private void Start()
    {
        _segments.Add(this.transform);
    }
    private void Update()
    {

        if (Keyboard.current.wKey.IsPressed())
        {
            _direction = Vector2.up;
        }
        else if (Keyboard.current.sKey.IsPressed())
        {
            _direction = Vector2.down;
        }
        if (Keyboard.current.aKey.IsPressed())
        {
            _direction = Vector2.left;
        }
        if (Keyboard.current.dKey.IsPressed())
        {
            _direction = Vector2.right;
        }

    }

    private void FixedUpdate()
    {
        _currentTimer += Time.deltaTime;
        _moveTimer += Time.deltaTime;

        if (_moveTimer >= _speed)
        {
            for (int i = _segments.Count - 1; i > 0; i--)
            {
                _segments[i].position = _segments[i - 1].position;
            }

            this.transform.position = new Vector3(
            Mathf.Round(this.transform.position.x) + _direction.x,
            Mathf.Round(this.transform.position.y) + _direction.y,
            0.0f);

            _moveTimer = 0f;
        }

        if (_currentTimer >= _timer)
        {
            Shrink();
        }

    }

    private void ResetState()
    {
        for (int i = 1; i < _segments.Count; i++)
        {
            Destroy(_segments[i].gameObject);
        }

        _segments.Clear();
        _segments.Add(this.transform);

        this.transform.position = Vector3.zero;
    }

    private void Shrink()
    {
        if (_segments.Count > 1)
        {
            Transform lastSegment = _segments[_segments.Count - 1];

            _segments.RemoveAt(_segments.Count - 1);
            
            Destroy(lastSegment.gameObject);
        }
        else
        {
            ResetState();
        }
        _currentTimer = 0f;
    }

    private void Grow()
    {
        Transform segment = Instantiate(this.segmentPrefab);
        segment.position = _segments[_segments.Count - 1].position;
        _segments.Add(segment);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Food")
        {
            Grow();
        }
        else if (collision.tag == "SafeFood")
        {
            Grow();
            _currentTimer = -10f;
        }
        else if (collision.tag == "Obstacle")
        {
            ResetState();
        }
    }
}
