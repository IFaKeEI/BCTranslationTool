using System;
using TranslationTool;

namespace TranslationTool
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();
            Application.Run(new TranslationToolForm());
        }
    }
}