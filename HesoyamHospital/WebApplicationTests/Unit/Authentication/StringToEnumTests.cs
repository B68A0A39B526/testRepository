using Backend.Model.PatientModel;
using Backend.Model.UserModel;
using System;
using System.Collections.Generic;
using System.Text;
using WebApplication.Authentication;
using Xunit;
using Shouldly;

namespace WebApplicationTests.Unit.Authentication
{
    public class StringToEnumTests
    {
        [Theory]
        [MemberData(nameof(GenderData))]
        public void Gender_test(string gender, Sex value)
        {
            Sex sex = NewPatientMapper.GenderToEnum(gender);

            sex.ShouldBe(value);
        }

        [Theory]
        [MemberData(nameof(BloodTypeData))]
        public void BloodType_test(string blood, BloodType value)
        {
            BloodType bloodType = NewPatientMapper.BloodTypeToEnum(blood);

            bloodType.ShouldBe(value);
        }

        public static IEnumerable<object[]> GenderData =>
        new List<object[]>
        {
            new object[] { "MALE", Sex.MALE },
            new object[] { "0", Sex.MALE },
            new object[] { "male", Sex.OTHER },
            new object[] { "9", Sex.OTHER },
        };

        public static IEnumerable<object[]> BloodTypeData =>
        new List<object[]>
        {
            new object[] { "A_POSITIVE", BloodType.A_POSITIVE },
            new object[] { "1", BloodType.A_NEGATIVE },
            new object[] { "a_positive", BloodType.NOT_TESTED },
            new object[] { "20", BloodType.NOT_TESTED },
        };

    }
}
