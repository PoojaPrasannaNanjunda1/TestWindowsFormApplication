/***********************************
** Program.cs
** Author: Pooja Prasanna Nanjunda
** Email: poojananjunda1996@gmail.com
** Date: 04-12-2022
***********************************/

namespace WinFormsTestApp1
{
    /// <summary>
    /// The Program class.
    /// </summary>
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            Application.Run(new WinFormsTestApp1());
        }
    }
}