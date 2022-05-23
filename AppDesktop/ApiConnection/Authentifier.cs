namespace AppDesktop.ApiConnection
{
    internal class Authentifier
    {
        private string username;
        private string password;

        public Authentifier(string username, string password)
        {
            this.username = username;
            this.password = password;
        }
    }
}