using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Explosion : MonoBehaviour
{
    [SerializeField] private float _explosionPower=300;
    [SerializeField] private float _radius=5;
    private float _timer = 5f;
    private bool _isExpolsion=false;

    public Transform ExplPoint;
    public GameObject Ball;
    public Text Timer;
    

    // Update is called once per frame
    void Update()
    {
        if (Ball.transform.position.y <= 6)
        {
            if (_timer <= 0)
            {
                Timer.text = "";
                _isExpolsion = true;
            }
            else
            {
                Timer.text = "";
                Timer.text += _timer;
            }

            if (_isExpolsion)
            {
                Explosions();
            }
            _timer -= Time.deltaTime;
        }
        

        
    }


    private void Explosions()
    {
        var hits = Physics.SphereCastAll(ExplPoint.position,_radius, ExplPoint.up);
        foreach (var item in hits)
        {
            var rigidbody = item.collider.GetComponent<Rigidbody>();
            if (rigidbody != null)
            {
                rigidbody.AddExplosionForce(_explosionPower, ExplPoint.position,_radius);
            }
        }
    }
}
