using System;
using System.Windows.Forms;
using CClient.Network;
using Microsoft.VisualBasic.Devices;

namespace Cclient;

static class Program
{

    [STAThread]
    static void Main()
    {
        Application.EnableVisualStyles();
        Application.SetCompatibleTextRenderingDefault(false);
        ApplicationConfiguration.Initialize();
        Form1 Form1 = new Form1();
        Application.Run(Form1);
        UdpBroadcaster.BroadcastPresenceAsync();
    }
}