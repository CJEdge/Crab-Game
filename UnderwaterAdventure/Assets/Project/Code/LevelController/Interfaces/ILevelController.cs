using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RPG.Application.Interfaces;


namespace Project.LevelController.Interfaces {
    public interface ILevelController : IAbstractLevelController {
        public string SampleText {
            get;
        }
    }
}
