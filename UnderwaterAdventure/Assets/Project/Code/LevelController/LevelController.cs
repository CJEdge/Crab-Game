using Project.LevelController.Interfaces;
using RPG.Application;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Project.Application {
    public class LevelController : AbstractLevelController<LevelController.State>, ILevelController {

        #region Types

        public enum State {
            None,
            Initialization,
            InitializationComplete,
            Playing,
            Outro
        }

        #endregion


        #region Properties

        public string SampleText => $"Sample Level Controller";

        #endregion


        #region ILevelController

        public override void Initialize() {
            SetState(State.Initialization);
        }

        public override bool IsReady() {
            return this.CurrentState == State.InitializationComplete;
        }

        public override void Run() {
            SetState(State.Playing);
        }

        #endregion


        #region AbstractStateBehaviour

        protected override void IntroState(State state) {
            switch (state) {
                case State.None:
                    break;
                case State.Initialization:
                    //TODO: Initialize things
                    break;
                case State.InitializationComplete:
                    break;
                case State.Playing:
                    break;
                case State.Outro:
                    break;
            }
        }

        protected override void OutroState(State state) {
            switch (state) {
                case State.None:
                    break;
                case State.Initialization:
                    break;
                case State.InitializationComplete:
                    break;
                case State.Playing:
                    break;
                case State.Outro:
                    break;
            }
        }

        protected override void UpdateState(State state) {
            switch (state) {
                case State.None:
                    SetState(State.Initialization);
                    break;
                case State.Initialization:
                    SetState(State.InitializationComplete);
                    break;
                case State.InitializationComplete:
                    break;
                case State.Playing:
                    break;
                case State.Outro:
                    break;
            }
        }

        #endregion
    }
}
