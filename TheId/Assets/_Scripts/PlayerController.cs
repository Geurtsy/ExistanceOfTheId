using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    [SerializeField] private Transform _trailFolder;
    [SerializeField] private GameObject _lightSpiritTrail;
    [SerializeField] private GameObject _runningSpiritTrail;
    private IMove _moveMech;

    private void Start()
    {
        _moveMech = GetComponent<IMove>();
    }

    private void Update()
    {
        float inputX = Input.GetAxis("Horizontal");
        float inputY = Input.GetAxis("Vertical");

        if(Mathf.Abs(inputX) > 0.0f || Mathf.Abs(inputY) > 0.0f)
        {
            if(Input.GetButton("Run"))
            {
                _moveMech.CurrentSpeedState = Movement.SpeedState.RUN;

                if(!_runningSpiritTrail.activeSelf)
                {
                    _runningSpiritTrail.SetActive(true);
                    _lightSpiritTrail.SetActive(false);
                }
            }
            else
            {
                _moveMech.CurrentSpeedState = Movement.SpeedState.WALK;

                if(!_lightSpiritTrail.activeSelf)
                {
                    _lightSpiritTrail.SetActive(true);
                    _runningSpiritTrail.SetActive(false);
                }
            }

            _moveMech.Move(new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")));
        }
        else
        {
            if(_lightSpiritTrail.activeSelf || _runningSpiritTrail.activeSelf)
            {
                _runningSpiritTrail.SetActive(false);
                _lightSpiritTrail.SetActive(false);
            }
        }
    }
}
