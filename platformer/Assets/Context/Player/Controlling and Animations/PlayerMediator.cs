using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMediator 
{
    public bool IsJumping { get; set; }
    public bool IsJumpKeyUp { get; set; }

    public bool CanReversWallJump { get; set; }

    public int CurrentWallDirections { get; set; }

    public PlayerMediator()
    {
        AmountOfJumps = 1;
    }

    #region AirJumps
    public int AmountOfJumps { get; private set; }
    public int JumpLefts { get; set; }
    
    public void PerformAirJump()
    {
        JumpLefts -= 1;
    }
    public void ResetAirJump()
    {
        JumpLefts = AmountOfJumps;
    }
    public bool CanAirJump()
    {
        if (JumpLefts > 0)
            return true;
        else
            return false;
    }
    #endregion

}
