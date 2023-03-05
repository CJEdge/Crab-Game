using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStatsUI : MonoBehaviour
{
    #region Serialized Fields

    [SerializeField]
    private int playerIndex;

    [SerializeField]
    private int totalPoints;

    [Header("Speed")]
    [SerializeField]
    private Button speedPlusButton;

    [SerializeField]
    private Button speedMinusButton;

    [SerializeField]
    private Text speedText;

    [Header("Claw Size")]
    [SerializeField]
    private Button clawSizePlusButton;

    [SerializeField]
    private Button clawSizeMinusButton;

    [SerializeField]
    private Text clawSizeText;

    [Header("Claw Power")]
    [SerializeField]
    private Button clawPowerPlusButton;

    [SerializeField]
    private Button clawPowerMinusButton;

    [SerializeField]
    private Text clawPowerText;

    #endregion


    #region Properties

    public int PointsRemainging {
        get;
        set;
    }

    public int Speed {
        get;
        set;
    }

    public int ClawSize {
        get;
        set;
    }

    public int ClawPower {
        get;
        set;
    }
    #endregion


    #region Public Methods

    public void IncreaseSpeed() {
        if (this.PointsRemainging == totalPoints) {
            return;
        }
        this.Speed++;
        this.PointsRemainging--;
        UpdateSpeedText();
    }

    public void DecreaseSpeed() {
        if (this.PointsRemainging == 0) {
            return;
        }
        this.Speed--;
        this.PointsRemainging++;
        UpdateSpeedText();
    }

    #endregion


    #region Private Methods

    public void UpdateSpeedText() {
        speedText.text = this.Speed.ToString();
    }

    #endregion

}
