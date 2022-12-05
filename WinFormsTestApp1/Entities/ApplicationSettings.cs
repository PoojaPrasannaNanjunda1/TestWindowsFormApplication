/***********************************
** ApplicationSettings.cs
** Author: Pooja Prasanna Nanjunda
** Email: poojananjunda1996@gmail.com
** Date: 04-12-2022
***********************************/

namespace WinFormsTestApp1.Entities
{
    /// <summary>
    /// This class has application configuration parameters.
    /// </summary>
    internal class ApplicationSettings
    {
        /// <summary>
        /// Gets or sets the application instance name.
        /// </summary>
        internal string? ApplicationInstanceName { get; set; }

        /// <summary>
        /// Gets or sets the Database path.
        /// </summary>
        internal string? DatabasePath { get; set; }
    }
}
