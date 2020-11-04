// File:    ISequencer.cs
// Author:  Windows 10
// Created: 23. maj 2020 16:20:06
// Purpose: Definition of Interface ISequencer

using System;

namespace Backend.Repository.Sequencer
{
    public interface ISequencer<T>
    {
        void Initialize(T initID);

        T GenerateID();

    }
}