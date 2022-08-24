using MiniSistema_TOPNFE.Resources;

namespace MiniSistema_TOPNFE
{
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
            //Application.Run(new ImpressaoFiscal());
            Application.Run(new ConsultaPedidosView());
            //Application.Run(new AlteraInfoPedido());
        }
    }
}