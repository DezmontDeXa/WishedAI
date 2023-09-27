using System;
using UnityEngine;
using Scellecs.Morpeh;
using UnityEngine.AI;
using WishedAI.Ecs.Components;
using WishedAI.Core.SatisfyActions;

namespace WishedAI.SatisfyActions.NavMesh.Agent
{
	[Serializable]
	public class SetDestination : SatisfyActionBase
	{
		[SerializeField] private Transform _targetPoint = null;
		[SerializeField] private bool _waitArrival = true;

		public override bool Start(SatisfyActionContext context)
		{
			ref var pawn = ref context.PawnEntity.GetComponent<PawnComponent>();
			var agent = pawn.NavMeshAgent;
			agent.SetDestination(_targetPoint.position);
			return !_waitArrival;
		}

		public override bool Update(SatisfyActionContext context, float timeDelta)
		{
			ref var pawn = ref context.PawnEntity.GetComponent<PawnComponent>();
			var agent = pawn.NavMeshAgent;

			if (!agent.pathPending)
			{
				if (agent.remainingDistance <= agent.stoppingDistance)
				{
					if (!agent.hasPath || agent.velocity.sqrMagnitude == 0f)
					{
						return true;
					}
				}
			}

			return false;
		}
	}
}
