namespace ais.Models
{
    public class Users
    {
        private string _name;
        private string _lastName;
        private string _login;
        private string _type;

        public Users(string name, string lastName, string login, string type)
        {
            _name = name;
            _lastName = lastName;
            _login = login;
            _type = type;
        }

        public string Name
        {
            get => _name;
            set
            {
                _name = value;
            }
        }
        public string LastName
        {
            get => _lastName;
            set
            {
                _lastName = value;
            }
        }
        public string Login
        {
            get => _login;
            set
            {
                _login = value;
            }
        }
        public string Type
        {
            get => _type;
            set
            {
                _type = value;
            }
        }
    }
}
