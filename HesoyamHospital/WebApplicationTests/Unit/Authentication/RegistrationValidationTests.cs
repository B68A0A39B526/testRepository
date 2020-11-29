using System;
using System.Collections.Generic;
using System.Text;
using WebApplication.Authentication;
using Xunit;
using Shouldly;

namespace WebApplicationTests.Unit.Authentication
{
    public class RegistrationValidationTests
    {
        [Theory]
        [MemberData(nameof(Data))]
        public void Patient_validation(NewPatientDTO patient, bool value)
        {
            bool valid = RegistrationValidation.IsNewPatientValid(patient);

            valid.ShouldBe(value);
        }

        public static IEnumerable<object[]> Data =>
        new List<object[]>
        {
            new object[] { new NewPatientDTO("E8mina", "Turkovic", "Mirsad", "FEMALE", "team.psw18@gmail.com", "eminaturk", "perapera", new DateTime(2025, 11, 9), "27100785057", "0911998777025", "0605552233", "033244377", "A_NEGATIVE", new List<string>(), "Serbia", "Priboj", "Alekse Santica 4"), false },
            new object[] { new NewPatientDTO("Emina", "Turkovic", "", "FEMALE", "team.psw18@gmail.com", "eminaturk", "perapera", new DateTime(2025, 11, 9), "27100785057", "0911998777025", "0605552233", "033244377", "A_NEGATIVE", new List<string>(), "Serbia", "Priboj", "Alekse Santica 4"), false },
            new object[] { new NewPatientDTO("Emina", "Turkovic", "Mirsad", "FEMALE", "team.psw18@gmail.com", "eminaturk", "perapera", new DateTime(2025, 11, 9), "27100785057", "0911998777025", "0605552233", "033244377", "A_NEGATIVE", new List<string>(), "Serbia", "Priboj", "Alekse Santica 4"), false },
            new object[] { new NewPatientDTO("Emina", "Turkovic", "Mirsad", "FEMALE", "team.psw18@gmail.com", "eminaturk", "perapera", new DateTime(1998, 11, 9), "27100785057", "0911998777025", "0605552233", "", "A_NEGATIVE", new List<string>(), "Serbia", "Priboj", "Alekse Santica 4"), true },
            new object[] { new NewPatientDTO("Emina", "Turkovic", "Mirsad", "FEMALE", "team.psw18@gmail.com", "eminaturk", "perapera", new DateTime(1998, 11, 9), "27100785057", "0911998777025", "0605552233", "", "A_NEGATIVE", null, "Serbia", "Priboj", "Alekse Santica 4"), true },
        };

        [Theory]
        [MemberData(nameof(UsernameData))]
        public void Is_username_unique(NewPatientDTO patient, bool value)
        {;
            bool valid = RegistrationValidation.IsPatientValid(patient);

            valid.ShouldBe(value);
        }

        public static IEnumerable<object[]> UsernameData =>
        new List<object[]>
        {
            new object[] { new NewPatientDTO("Emina", "Turkovic", "Mirsad", "FEMALE", "team.psw18@gmail.com", "milijanadj", "perapera", new DateTime(1998, 11, 9), "27100785057", "0911998777025", "0605552233", "", "A_NEGATIVE", null, "Serbia", "Priboj", "Alekse Santica 4"), false },
            new object[] { new NewPatientDTO("Emina", "Turkovic", "Mirsad", "FEMALE", "team.psw18@gmail.com", "milijanadjxxx", "perapera", new DateTime(1998, 11, 9), "27100785057", "0911998777025", "0605552233", "", "A_NEGATIVE", null, "Serbia", "Priboj", "Alekse Santica 4"), true },
        };
    }
}
