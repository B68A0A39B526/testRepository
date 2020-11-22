// File:    DocTypeEnum.cs
// Author:  Windows 10
// Created: 15. april 2020 19:30:08
// Purpose: Definition of Enum DocTypeEnum

using System;

namespace Backend.Model.DoctorModel
{
    public enum DoctorType
    {
        UNDEFINED,
        FAMILYMEDICINE,
        SURGEON,
        CARDIOLOGIST,
        DERMATOLOGIST,
        INFECTOLOGIST,
        OPHTAMOLOGIST,
        ENDOCRINIOLOGIST,
        GASTROENEROLOGIST
    }
}