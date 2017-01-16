using UnityEngine;
using System.Collections;
#if UNITY_5_5_OR_NEWER
using UnityEngine.AI;
#endif

public class Agent : MonoBehaviour
{
	protected NavMeshAgent agent;
	protected Animator animator;
	protected Locomotion locomotion;

	private void Start ()
	{
		agent = GetComponent<NavMeshAgent>();
		agent.updateRotation = false;

		animator = GetComponent<Animator>();
		locomotion = new Locomotion(animator);
	}

	protected void SetupAgentLocomotion()
	{
		if (AgentDone())
		{
			locomotion.Do(0, 0);
		}
		else
		{
			float speed = agent.desiredVelocity.magnitude;
			Vector3 velocity = Quaternion.Inverse(transform.rotation) * agent.desiredVelocity;
			float angle = Mathf.Atan2(velocity.x, velocity.z) * 180.0f / 3.14159f;
			locomotion.Do(speed, angle);
		}
	}

    private void OnAnimatorMove()
    {
        agent.velocity = animator.deltaPosition / Time.deltaTime;
		transform.rotation = animator.rootRotation;
    }

	protected bool AgentDone()
	{
		return !agent.pathPending && AgentStopping();
	}

	protected bool AgentStopping()
	{
		return agent.remainingDistance <= agent.stoppingDistance;
	}

	private void Update () 
	{
		SetupAgentLocomotion();
	}
}
