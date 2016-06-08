using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace QuestRacoon
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public App() : base()
        {
            this.Dispatcher.UnhandledException += OnDispatcherUnhandledException;
        }

        void OnDispatcherUnhandledException(object sender, System.Windows.Threading.DispatcherUnhandledExceptionEventArgs e)
        {
            var builder = new StringBuilder();
            builder.Append("exception: ");
            builder.Append(e.Exception.ToString());
            builder.Append("\r\n\r\nmessage: ");
            builder.Append(e.Exception.Message);
            //builder.Append("\r\n\r\ndata: ");
            //foreach (var item in e.Exception.Data.Keys)
            //{
            //    builder.Append(item.ToString() + " : " + e.Exception.Data[item].ToString() + "\r\n");
            //}
            builder.Append("\r\n\r\nsource: ");
            builder.Append(e.Exception.Source);
            builder.Append("\r\n\r\nstack trace: ");
            builder.Append(e.Exception.StackTrace);

            string errorMessage = string.Format("An unhandled exception occurred: {0}", builder.ToString());
            System.IO.File.WriteAllText("error.txt", errorMessage);
            MessageBox.Show(errorMessage, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
        }
    }
}
