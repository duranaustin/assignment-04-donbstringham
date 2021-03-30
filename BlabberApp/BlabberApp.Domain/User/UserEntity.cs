using System;
using System.Net.Mail;

namespace BlabberApp.Domain
{
    public class UserEntity : IDomain
    {
        private string _ID;
        public string Name {get; set;}

        public UserEntity SetId(string newID)
        {
            try
            {
                MailAddress m =  new MailAddress(newID); // validation only
            }
            catch (FormatException fe)
            {
                throw new FormatException(fe.ToString());
            }

            _ID = newID;
            return this;
        }
        public string GetId()
        {
            return _ID;
        }
    }
}
