using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using InTheHand.Net.Bluetooth;
using InTheHand.Net.Sockets;

namespace CopterEmulator
{
    class Program
    {

        static readonly Guid CopterGUID = new Guid("633e589e-2036-4fac-8371-d9a9544e9355");

        static void Main(string[] args)
        {
            System.Console.WriteLine("--- Copter Emulator ---");
            System.Console.WriteLine("Listening for commands...");
            System.Console.WriteLine();

            //Guid serviceClass = BluetoothService.SerialPort;
            var lsnr = new BluetoothListener(CopterGUID);
            lsnr.Start();

            BluetoothClient conn = lsnr.AcceptBluetoothClient();
            Stream peerStream = conn.GetStream();

            byte[] buffer = new byte[256];

            while (!false)
            {
                int readSize = peerStream.Read(buffer, 0, buffer.Length);
                if (readSize > 0)
                {
                    String s = System.Text.Encoding.ASCII.GetString(buffer, 0, readSize);
                    System.Console.Write(s);
                }
            }
            
        }

        
    }
}
