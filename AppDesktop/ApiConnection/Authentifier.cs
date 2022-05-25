namespace AppDesktop.ApiConnection
{
    public class Authentifier
    {
        public string username { get; set; }
        public string password { get; set; }

        //public string Username { get => username; set => username = value; }
        //public string Password { get => password; set => password = value; }

        public Authentifier(string username, string password)
        {
            this.username = username;
            this.password = password;
        }
    }
}