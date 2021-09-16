using System;
using System.Reflection;
using Npgsql;
using ThinkingHome.Migrator;

namespace DbMigrator
{
    public class Program
    {
        static void Main(string[] args)
        {
            MigrationRunner a = new MigrationRunner();
            a.MigrationConnection("Server=localhost;Port=5432;Database=tasksite;UserId=postgres;Password=admin");
            //исправлен пароль с 123 на admin
            Console.WriteLine("Successfully imported DB");
        }
    }
}
