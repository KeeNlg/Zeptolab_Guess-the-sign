using System;
using System.Collections;
using UnityEngine;

public class Cursor : MonoBehaviour
{
    private Vector3 _startPos;
    private Vector3 _target;
    private float _t;

    private void Update()
    {
        /*RaycastHit2D hit;
 
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (hit = Physics2D.Raycast(ray.origin, new Vector2(0, 0)))
        {
            transform.position = hit.point;
        }*/
        transform.localPosition = Input.mousePosition - new Vector3(526, 744);
    }

    public void Move(Vector3 target, float time)
    {
        StartCoroutine(MoveCoroutine(target, time));
    }
    
    private IEnumerator MoveCoroutine(Vector3 target, float time)
    {
        _startPos = transform.position;
        _target = target - new Vector3(0, 0.085f, 0);
        _t = 0;
        while (Vector3.Distance(transform.position, _target) > 0)
        {
            _t += Time.deltaTime / time;
            transform.position = Vector3.Lerp(_startPos, _target, _t);
            yield return null;
        }
    }
}
