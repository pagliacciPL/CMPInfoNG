using System;
using System.Collections.Generic;
using System.DirectoryServices.AccountManagement;
using System.Linq;
using System.Text;

namespace CMPInfoNG
{
    class Methods
    {
        private static string GetUser()
        {

            string userName = Environment.UserName;

            return userName;
        }

        private static string GetHost()
        {

            string hostName = Environment.MachineName;
            return hostName;
        }

        private static string GetMail()
        {

            string mail = "helpdesk@example.com";
            return mail;
        }



        private static string GetExpiration()
        {

            try
            {
                PrincipalContext context = new PrincipalContext(ContextType.Domain);
                string userFull = System.Security.Principal.WindowsIdentity.GetCurrent().Name;
                UserPrincipal p = UserPrincipal.FindByIdentity(context, userFull);
            }

            catch (Exception e)
            {
                return "Cannot connect to AD!";
            }

            try
            {
                PrincipalContext context = new PrincipalContext(ContextType.Domain);
                string userFull = System.Security.Principal.WindowsIdentity.GetCurrent().Name;
                UserPrincipal p = UserPrincipal.FindByIdentity(context, userFull);

                if (p.PasswordNeverExpires == true)
                {
                    return "Password never expires!";
                }

                else
                {

                    DateTime setPass = p.LastPasswordSet.Value.ToLocalTime();
                    DateTime expiration = setPass.AddDays(42);


                    return expiration.ToString();

                }


            }

            catch (Exception e)
            {

                return "Brak danych";
            }



        }


    }
}
