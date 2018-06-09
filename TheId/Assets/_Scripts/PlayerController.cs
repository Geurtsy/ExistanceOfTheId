using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    [SerializeField] private GameObject _lightSpiritTrail;
    [SerializeField] private GameObject _runningSpiritTrail;
    private IMove _moveMech;

    private void Start()
    {
        _moveMech = GetComponent<IMove>();
    }

    private void Update()
    {
        if(Mathf.Abs(Input.GetAxisRaw("Horizontal")) > 0.0f || Mathf.Abs(Input.GetAxisRaw("Vertical")) > 0.0f)
        {
            if(!_lightSpiritTrail.activeSelf)
            {
                _lightSpiritTrail.SetActive(true);
                _runningSpiritTrail.SetActive(false);
            }

            _moveMech.CurrentSpeedState = Movement.SpeedState.WALK;

            if(Input.GetButton("Run"))
            {
                _moveMech.CurrentSpeedState = Movement.SpeedState.RUN;

                if(!_runningSpiritTrail.activeSelf)
                {
                    _runningSpiritTrail.SetActive(true);
                    _lightSpiritTrail.SetActive(false);
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
