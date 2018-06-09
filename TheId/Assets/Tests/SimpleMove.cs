using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleMove : MonoBehaviour {

    [SerializeField] private float _speed;
    [SerializeField] private float _moveColourChangeDelay;
    [SerializeField] private Material[] _moveMaterials;
    [SerializeField] private Material _stillMaterial;
    private Renderer _myRenderer;

    private void Start()
    {
        _myRenderer = gameObject.GetComponent<Renderer>();

        StartCoroutine(ChangeMovementColour());
    }

    private void Update()
    {
        if(Input.GetKey(KeyCode.W))
        {
            transform.position += transform.forward * _speed * Time.deltaTime;
        }
        else if(Input.GetKey(KeyCode.S))
        {
            transform.position += -transform.forward * _speed * Time.deltaTime;
        }
        else if(Input.GetKey(KeyCode.A))
        {
            transform.position += -transform.right * _speed * Time.deltaTime;
        }
        else if(Input.GetKey(KeyCode.D))
        {
            transform.position += transform.right * _speed * Time.deltaTime;
        }
    }

    private IEnumerator ChangeMovementColour()
    {
        while(true)
        {
            while(Input.anyKey)
            {
                foreach(Material mat in _moveMaterials)
                {
                    _myRenderer.material = mat;
                    yield return new WaitForSeconds(_moveColourChangeDelay);
                }
            }

            if(!Input.anyKey)
            {
                _myRenderer.material = _stillMaterial;
            }

            yield return null;
        }
    }
}
