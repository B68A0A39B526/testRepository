/***********************************************************************
 * Module:  BloodType.cs
 * Author:  nikola
 * Purpose: Definition of the Enum BloodType
 ***********************************************************************/

using System;

namespace Backend.Model.PatientModel
{
    public enum BloodType
    {
        A_POSITIVE,
        A_NEGATIVE,
        B_POSITIVE,
        B_NEGATIVE,
        O_POSITIVE,
        O_NEGATIVE,
        AB_POSITIVE,
        AB_NEGATIVE,
        NOT_TESTED
    }
}