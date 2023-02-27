namespace VotingProject
{
    public static class Helper
    {
        public static string CnnVal(string name)
        {
            try
            {
                return System.Configuration.ConfigurationManager.ConnectionStrings[name].ConnectionString;
            }
            catch (Exception a)
            {
                Console.WriteLine(a);
                throw;
            }
        }
    }
}