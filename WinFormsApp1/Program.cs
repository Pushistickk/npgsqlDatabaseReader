using NHibernate;
using Npgsql;
using FluentNHibernate;
namespace WinFormsApp1
{
    internal static class Program
    {
        public static DatabaseConnection DBC = new DatabaseConnection();
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            if (!DBC.TestConnection())
            {
                MessageBox.Show("no connection");
                Application.Exit();
            }
            ApplicationConfiguration.Initialize();
            Application.Run(new Form1());
        }
    }
}