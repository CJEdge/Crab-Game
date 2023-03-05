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

    [SerializeField]
    private Text pointsRemainingText;

    [SerializeField]
    private Text speedText;

    [SerializeField]
    private Text clawSizeText;

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


    #region Mono Behaviours

    public void Start() {
        this.PointsRemainging = totalPoints;
    }

    #endregion


    #region Public Methods

    public void IncreaseSpeed() {
        if (this.PointsRemainging == 0) {
            return;
        }
        this.Speed++;
        this.PointsRemainging--;
        UpdateSpeedText();
    }

    public void DecreaseSpeed() {
        if (this.PointsRemainging == -totalPoints || this.Speed == -totalPoints) {
            return;
        }
        this.Speed--;
        this.PointsRemainging++;
        UpdateSpeedText();
    }

    public void IncreaseClawSize() {
        if (this.PointsRemainging == 0) {
            return;
        }
        this.ClawSize++;
        this.PointsRemainging--;
        UpdateClawSizeText();
    }

    public void DecreaseClawSize() {
        if (this.PointsRemainging == -totalPoints || this.ClawSize == -totalPoints) {
            return;
        }
        this.ClawSize--;
        this.PointsRemainging++;
        UpdateClawSizeText();
    }

    public void IncreaseClawPower() {
        if (this.PointsRemainging == 0) {
            return;
        }
        this.ClawPower++;
        this.PointsRemainging--;
        UpdateClawPowerText();
    }

    public void DecreaseClawPower() {
        if (this.PointsRemainging == -totalPoints || this.ClawPower == -totalPoints) {
            return;
        }
        this.ClawPower--;
        this.PointsRemainging++;
        UpdateClawPowerText();
    }

    #endregion


    #region Private Methods

    public void UpdateSpeedText() {
        speedText.text = this.Speed.ToString();
        pointsRemainingText.text = "Points Remaining: " + this.PointsRemainging.ToString();
    }

    public void UpdateClawSizeText() {
        clawSizeText.text = this.ClawSize.ToString();
        pointsRemainingText.text = "Points Remaining: " + this.PointsRemainging.ToString();
    }
    public void UpdateClawPowerText() {
        clawPowerText.text = this.ClawPower.ToString();
        pointsRemainingText.text = "Points Remaining: " + this.PointsRemainging.ToString();
    }

    #endregion

}
