using com.HellStormGames.Diagnostics;
using com.HellStormGames.Diagnostics.Logging;

namespace Sample01_HelloLoggio
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.FormClosing += Form1_FormClosing;
            this.FormClosed += Form1_FormClosed;
        }

        private void Form1_FormClosing(object? sender, FormClosingEventArgs e)
        {
            Loggio.Info("Main form is closing...");
        }

        private void Form1_FormClosed(object? sender, FormClosedEventArgs e)
        {
            Loggio.Info("Main Form Is Closed.");
            Loggio.Shutdown();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Loggio.Logger = new LoggioConfiguration().SubscribeTo.File("loggio.log", LoggioEventType.VERBOSE).CreateLogger();
           
            Loggio.Info("Loaded Main Form.");
            Loggio.Warn("This is a warning.");
            Loggio.Error("This is an error");
            List<int> numbers = new List<int>(2);
            try
            {
                numbers[5] = 10;
            }
            catch (Exception ex)
            {
                Loggio.Error(ex, "List Out Of Range.", "This is a error with exception.");
            }
        }
    }
}
