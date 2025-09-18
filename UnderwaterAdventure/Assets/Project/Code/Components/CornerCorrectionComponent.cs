using UnityEngine;

namespace Project.Components {
	public class CornerCorrectionComponent : MonoBehaviour {
		#region Serialized Fields

		[SerializeField]
		private CircleCollider2D leftCollider;

		[SerializeField]
		private CircleCollider2D rightCollider;

		[SerializeField]
		private LayerMask layerMask;

		[SerializeField]
		private PlayerMovementComponent playerMovementComponent;

		[SerializeField]
		private Rigidbody2D rb;

		[SerializeField]
		private float verticalCorrection;

		[SerializeField]
		private float horizontalCorrection;

		#endregion

		#region Mono Behaviours

		public void Update() {

			if (leftCollider.IsTouchingLayers(layerMask) && !rightCollider.IsTouchingLayers(layerMask)) {
				if (playerMovementComponent.Horizontal < 0) {
					rb.AddForce(new Vector2(-horizontalCorrection, verticalCorrection));
				}
			}

			if (rightCollider.IsTouchingLayers(layerMask) && !leftCollider.IsTouchingLayers(layerMask)) {
				if (playerMovementComponent.Horizontal > 0) {
					rb.AddForce(new Vector2(horizontalCorrection, verticalCorrection));
				}
			}
		}

		#endregion
	}
}
