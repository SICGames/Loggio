using com.HellStormGames.Diagnostics;

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
            Loggio.Info("Loaded Main Form.");
        }
    }
}
