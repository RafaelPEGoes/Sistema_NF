using ESCPOS_NET;
using ESCPOS_NET.Emitters;
namespace MiniSistema_TOPNFE
{
    public partial class ImpressaoFiscal : Form
    {
        public ImpressaoFiscal()
        {
            InitializeComponent();
        }

        private void ImpressaoFiscal_Load(object sender, EventArgs e)
        {   
            try
            {
             //entender o porque a conexão não está funcionando
             //n ha sobrecarga para ipAddress no método da biblioteca
             //var printer1 = new NetworkPrinter(ipAddress: "192.168.2.220", port: "9200");
                var printer = new SerialPrinter(portName: "COM5", baudRate: 9600);

                var eps = new EPSON();

                printer.Write(
                    eps.PrintLine("123")
                    );
            } catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
            
        }
    }
}
