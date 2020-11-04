/***********************************************************************
 * Module:  Medicine.cs
 * Author:  nikola
 * Purpose: Definition of the Class Medicine
 ***********************************************************************/

using System;
using Backend.Model.PatientModel;
using System.Collections.Generic;

namespace Backend.Model.PatientModel
{
    public class Medicine : Item
    {
        private double _strength;
        private bool _isValid;
        private MedicineType _medicineType;

        private List<Ingredient> _ingredient;
        private List<DiseaseMedicine> _usedFor;

        public List<Ingredient> Ingredient
        {
            get
            {
                if (_ingredient == null)
                    _ingredient = new List<Ingredient>();
                return _ingredient;
            }
            set
            {
                RemoveAllIngredient();
                if (value != null)
                {
                    foreach (Ingredient oIngredient in value)
                        AddIngredient(oIngredient);
                }
            }
        }

        public double Strength { get => _strength; set => _strength = value; }
        public bool IsValid { get => _isValid; set => _isValid = value; }
        public MedicineType MedicineType { get => _medicineType; set => _medicineType = value; }
        public List<DiseaseMedicine> UsedFor
        {
            get
            {
                if (_usedFor == null)
                    _usedFor = new List<DiseaseMedicine>();
                return _usedFor;
            }
            set
            {
                RemoveAllUsedFor();
                if (value != null)
                {
                    foreach (DiseaseMedicine oDisease in value)
                        AddUsedFor(oDisease.Disease);
                }
            }
        }

        public Medicine(long id) : base(id)
        {
        }
        public Medicine(string name,double strength, MedicineType medicineType,int inStock, int minNumber) : base(name, inStock, minNumber)
        {
            _strength = strength;
            _medicineType = MedicineType;
            _isValid = false;
            _ingredient = new List<Ingredient>();
            _usedFor = new List<DiseaseMedicine>();
        }


        public Medicine(string name, double strength, MedicineType medicineType,bool isValid,List<DiseaseMedicine> usedFor, List<Ingredient> ingredient,int inStock, int minNumber) : base(name, inStock, minNumber)
        {
            _strength = strength;
            _medicineType = MedicineType;
            _isValid = false;
            _ingredient = ingredient;
            _usedFor = usedFor;
        }

        public Medicine(long id, string name, double strength, MedicineType medicineType, bool isValid, List<DiseaseMedicine> usedFor, List<Ingredient> ingredient, int inStock, int minNumber) : base(id,name, inStock, minNumber)
        {
            _strength = strength;
            _medicineType = MedicineType;
            _isValid = isValid;
            _ingredient = ingredient;
            _usedFor = usedFor;
        }



        /// <summary>
        /// Property for collection of Ingredient
        /// </summary>
        /// <pdGenerated>Default opposite class collection property</pdGenerated>
      
        /// <summary>
        /// Add a new Ingredient in the collection
        /// </summary>
        /// <pdGenerated>Default Add</pdGenerated>
        public void AddIngredient(Ingredient newIngredient)
        {
            if (newIngredient == null)
                return;
            if (_ingredient == null)
                _ingredient = new List<Ingredient>();
            if (!_ingredient.Contains(newIngredient))
                _ingredient.Add(newIngredient);
        }

        /// <summary>
        /// Remove an existing Ingredient from the collection
        /// </summary>
        /// <pdGenerated>Default Remove</pdGenerated>
        public void RemoveIngredient(Ingredient oldIngredient)
        {
            if (oldIngredient == null)
                return;
            if (_ingredient != null)
                if (_ingredient.Contains(oldIngredient))
                    _ingredient.Remove(oldIngredient);
        }

        /// <summary>
        /// Remove all instances of Ingredient from the collection
        /// </summary>
        /// <pdGenerated>Default removeAll</pdGenerated>
        public void RemoveAllIngredient()
        {
            if (_ingredient != null)
                _ingredient.Clear();
        }


        /// <summary>
        /// Add a new Disease in the collection
        /// </summary>
        /// <pdGenerated>Default Add</pdGenerated>
        public void AddUsedFor(Disease newDisease)
        {
            if (newDisease == null)
                return;
            if (_usedFor == null)
                _usedFor = new List<DiseaseMedicine>();
            if (_usedFor.Find(dm => dm.Disease.Equals(newDisease)) == null)
            {
                DiseaseMedicine dm = new DiseaseMedicine(newDisease, this);
                _usedFor.Add(dm);
                newDisease.AddAdministratedFor(this);
            }
        }

        /// <summary>
        /// Remove an existing Disease from the collection
        /// </summary>
        /// <pdGenerated>Default Remove</pdGenerated>
        public void RemoveUsedFor(Disease oldDisease)
        {
            if (oldDisease == null)
                return;
            if (_usedFor != null)
                if (_usedFor.Find(dm => dm.Disease.Equals(oldDisease)) == null)
                {
                    DiseaseMedicine removeDm = _usedFor.Find(dm => dm.Disease.Equals(oldDisease));
                    if(removeDm != null)
                    _usedFor.Remove(removeDm);
                    oldDisease.RemoveAdministratedFor(this);
                }
        }

        /// <summary>
        /// Remove all instances of Disease from the collection
        /// </summary>
        /// <pdGenerated>Default removeAll</pdGenerated>
        public void RemoveAllUsedFor()
        {
            if (_usedFor != null)
            {
                System.Collections.ArrayList tmpUsedFor = new System.Collections.ArrayList();
                foreach (DiseaseMedicine oldDisease in _usedFor)
                    tmpUsedFor.Add(oldDisease.Disease);
                _usedFor.Clear();
                foreach (Disease oldDisease in tmpUsedFor)
                    oldDisease.RemoveAdministratedFor(this);
                tmpUsedFor.Clear();
            }
        }

    }
}