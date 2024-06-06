using RZDModel.DBContext;
using RZDModel.Repository;
using RZDModel.Repository.Configuration;

namespace RZDTestConsole
{
    internal class Program
    {
        public static ConnectionConfiguration config;
        static void Main(string[] args)
        {
            config = new ConnectionConfiguration()
            {
                DataSource = "C:\\Users\\NAEug\\source\\repos\\RZDModel\\RZDModel\\DataBase\\TestDB.db",
            };


        }
    }
}
