namespace CodePasswordDLL
{
    public static class CodePassword
    {
        public static string GetPassword(string Passw)
        {
            string password = "";
            foreach (char a in Passw)
            {
                char ch = a;
                ch--;
                password += ch;
            }
            return password;
        }

        public static string EncryptPassword(string Passw)
        {
            string sCode = "";
            foreach (char a in Passw)
            {
                char ch = a;
                ch++;
                sCode += ch;
            }
            return sCode;
        }
    }
}
