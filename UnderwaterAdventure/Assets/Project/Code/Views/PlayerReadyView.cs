using System.Collections;
using UnityEngine;
using RPG.View;
using RPG.View.Attributes;
using UnityEngine.UI;
using RPG.Nodes;
using RPG.Application;

namespace Project.Views {
    public class PlayerReadyView : ViewBase {

        [SerializeField]
        private Button continueButton;

        #region XNode

        [ViewOutput]
        public EmptyNode ContinueNode {
            get;
            set;
        }

		public override GameObject FirstSelected => throw new System.NotImplementedException();

		#endregion

		public override void CleanupButtonListeners() {
            continueButton.onClick.RemoveAllListeners();
        }

        public override void SetupButtonListeners() {
            continueButton.onClick.AddListener(() => {
                ApplicationManager.Instance.SetSceneTransition(Project.Application.SceneList.GAME);
                OnProcessNode("ContinueNode");
            });
        }
    }
}