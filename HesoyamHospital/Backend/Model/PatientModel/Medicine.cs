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
        public bool IsValid { get; set; }
        public MedicineType MedicineType { get; set; }
        private List<Ingredient> _ingredient;
        public virtual List<Ingredient> Ingredient
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
        private List<DiseaseMedicine> _usedFor;
        public virtual List<DiseaseMedicine> UsedFor
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
        public Medicine(string name, MedicineType medicineType, int inStock, int minNumber) : base(name, inStock, minNumber)
        {
            MedicineType = medicineType;
            IsValid = false;
            Ingredient = new List<Ingredient>();
            UsedFor = new List<DiseaseMedicine>();
        }


        public Medicine(string name, MedicineType medicineType, List<DiseaseMedicine> usedFor, List<Ingredient> ingredient,int inStock, int minNumber) : base(name, inStock, minNumber)
        {
            MedicineType = medicineType;
            IsValid = false;
            Ingredient = ingredient;
            UsedFor = usedFor;
        }

        public Medicine(long id, string name, MedicineType medicineType, bool isValid, List<DiseaseMedicine> usedFor, List<Ingredient> ingredient, int inStock, int minNumber) : base(id,name, inStock, minNumber)
        {
            MedicineType = medicineType;
            IsValid = isValid;
            Ingredient = ingredient;
            UsedFor = usedFor;
        }

        public void AddIngredient(Ingredient newIngredient)
        {
            if (newIngredient == null)
                return;
            if (Ingredient == null)
                Ingredient = new List<Ingredient>();
            if (!Ingredient.Contains(newIngredient))
                Ingredient.Add(newIngredient);
        }

        public void RemoveIngredient(Ingredient oldIngredient)
        {
            if (oldIngredient == null)
                return;
            if (Ingredient != null && Ingredient.Contains(oldIngredient))
                Ingredient.Remove(oldIngredient);
        }

        public void RemoveAllIngredient()
        {
            if (Ingredient != null)
                Ingredient.Clear();
        }

        public void AddUsedFor(Disease newDisease)
        {
            if (newDisease == null)
                return;
            if (UsedFor == null)
                UsedFor = new List<DiseaseMedicine>();
            if (UsedFor.Find(dm => dm.Disease.Equals(newDisease)) == null)
            {
                DiseaseMedicine dm = new DiseaseMedicine(newDisease, this);
                UsedFor.Add(dm);
                newDisease.AddAdministratedFor(this);
            }
        }

        public void RemoveUsedFor(Disease oldDisease)
        {
            if (oldDisease == null)
                return;
            if (UsedFor != null && UsedFor.Find(dm => dm.Disease.Equals(oldDisease)) == null)
            {
                DiseaseMedicine removeDm = UsedFor.Find(dm => dm.Disease.Equals(oldDisease));
                if (removeDm != null)
                    UsedFor.Remove(removeDm);
                oldDisease.RemoveAdministratedFor(this);
            }
        }

        public void RemoveAllUsedFor()
        {
            if (UsedFor != null)
            {
                System.Collections.ArrayList tmpUsedFor = new System.Collections.ArrayList();
                foreach (DiseaseMedicine oldDisease in UsedFor)
                    tmpUsedFor.Add(oldDisease.Disease);
                UsedFor.Clear();
                foreach (Disease oldDisease in tmpUsedFor)
                    oldDisease.RemoveAdministratedFor(this);
                tmpUsedFor.Clear();
            }
        }

    }
}