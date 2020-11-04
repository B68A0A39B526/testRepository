using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Util
{
    public class Regexes
    {
        public static string usernameRegex = "[a-zA-Z_0-9]{3,32}";
        public static string passwordRegex = "[a-zA-Z_0-9]{8,32}";
        public static string nameRegex = "([A-Z][a-z]+)+";
        public static string illegalNameCharactersRegex = "([0-9])+";
        public static string uidnRegex = "[0-9]{13}";
        public static string emailRegex = "[A-Za-z_.]+@([A-Za-z.])+\\.[a-z]+$";           // TODO: Proveri regex
        public static string phoneRegex = "^[+]*[(]{0,1}[0-9]{1,4}[)]{0,1}[- /0-9]*$";
        public static string diseaseName = ".{3,}";

        public static string medicineNamePattern = @"[a-zA-Z0-9\\-\\! ]*";
        public static string roomNumberPattern = @"[a-zA-Z0-9\\- ]*";
    }
}
