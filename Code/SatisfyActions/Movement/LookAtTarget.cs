using Scellecs.Morpeh;
using System;
using UnityEngine;
using WishedAI.Core.SatisfyActions;
using WishedAI.Ecs.Components;

namespace WishedAI.SatisfyActions.Movement
{
	[Serializable]
	public class LookAtTarget : SatisfyActionBase
	{
		public Transform TargetPoint = null;
		public float _rotationSpeed = 1f;
		public float _rotationThreshold = 1f;

		public override bool Start(SatisfyActionContext context)
		{
			return false;
		}

		public override bool Update(SatisfyActionContext context, float timeDelta)
		{
			ref var pawn = ref context.PawnEntity.GetComponent<PawnComponent>();

			var transform = pawn.Transform;
			var direction = TargetPoint.position - transform.position;
			direction.y = 0f;

			var targetRotation = Quaternion.LookRotation(direction);

			transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, _rotationSpeed * timeDelta);

			return Quaternion.Angle(transform.rotation, targetRotation) < _rotationThreshold;
		}
	}
}
