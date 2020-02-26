using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleEmmit : MonoBehaviour {

    public Transform target;
    public float force = 10.0f;

    ParticleSystem ps;

    void Start()
    {
        ps = this.GetComponent<ParticleSystem>();
    }

    void Update()
    {
        ParticleSystem.Particle[] particles =
            new ParticleSystem.Particle[ps.particleCount];

       //Debug.Log("ps.particleCount "+ ps.particleCount+ "particles.Length: "+ particles.Length);

        ps.GetParticles(particles);

        for (int i = 0; i < particles.Length; i++)
        {
            ParticleSystem.Particle p = particles[i];

            Vector3 particleWorldPosition;

            if (ps.main.simulationSpace == ParticleSystemSimulationSpace.Local)
            {
                particleWorldPosition = transform.TransformPoint(p.position);
            }
            else if (ps.main.simulationSpace == ParticleSystemSimulationSpace.Custom)
            {
                particleWorldPosition = ps.main.customSimulationSpace.TransformPoint(p.position);
            }
            else
            {
                particleWorldPosition = p.position;
            }

            Vector3 directionToTarget = (target.position - particleWorldPosition).normalized;//normalized:把向量轉換成長度 1 的「單位向量」
            Vector3 seekForce = (directionToTarget * force) * Time.deltaTime;

            p.velocity +=  seekForce;
            particles[i] = p;
          //Debug.Log(particles[0].velocity);

        }

        ps.SetParticles(particles, particles.Length);
    }
}
