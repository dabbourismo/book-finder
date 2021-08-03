using A.Supermarket.BaseForms;
using BookFinder.Winform.BaseForms;
using BookFinder.Winform.BookForms;
using BookFinder.Winform.BookOneForms;
using BookFinder.Winform.BookTwoForms;
using BookFinder.Winform.ManuscriptForms;
using Repository;
using Repository.Repos;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Unity;

namespace BookFinder.Winform
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Database.SetInitializer(new NullDatabaseInitializer<ApplicationDbContext>());
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new HomeForm());
            RegisterUnity();
        }
        static void RegisterUnity()
        {
            var container = new UnityContainer();
            container.RegisterType<IUnitOfWork, UnitOfWork>();
            //container.Resolve<BookFormBase>();
            //container.Resolve<BookOneFormBase>();
            //container.Resolve<BookTwoFormBase>();
            //container.Resolve<ManuscriptFormBase>();

            Application.Run(container.Resolve<MainForm>());
        }
    }
}
