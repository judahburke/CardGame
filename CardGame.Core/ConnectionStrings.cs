using System;

namespace CardGame.Helpers
{
    public static class ConnectionStrings
    {
        public class DatabaseConnection
        {
            public string Connection { get; set; }
            public string Schema { get; set; }
            public string Table { get; set; }
        }

        private static string DbCardGame => "Server=Judah-PC\\SQLEXPRESS; Database=CardGame; Trusted_Connection=True; Connection LifeTime=300;";

        public static DatabaseConnection Logging = new DatabaseConnection
        { Connection = DbCardGame, Schema = "dbo", Table = "Log" };
        public static DatabaseConnection Rules = new DatabaseConnection
        { Connection = DbCardGame, Schema = "dbo", Table = "GameRules" };
        public static DatabaseConnection TowerStatistics = new DatabaseConnection
        { Connection = DbCardGame, Schema = "Solitaire", Table = "TowerStatistics" };
        public static DatabaseConnection KlondikeStatistics = new DatabaseConnection
        { Connection = DbCardGame, Schema = "Solitaire", Table = "KlondikeStatistics" };
        public static DatabaseConnection PitchStatistics = new DatabaseConnection
        { Connection = DbCardGame, Schema = "Klondike", Table = "Statistics" };
        public static DatabaseConnection SpitStatistics = new DatabaseConnection
        { Connection = DbCardGame, Schema = "Spit", Table = "Statistics" };

    }
}
