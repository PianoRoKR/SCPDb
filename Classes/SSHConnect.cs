using System;
using System.Windows.Forms;
using System.Threading;
using Renci.SshNet;
using Renci.SshNet.Common;

public class SSHConnector
{
    private SshClient mClient;
    private ForwardedPortLocal mPort;
    private string mHost = "scpdb.dyndns.info";
    private string mUser = "rs4090";
    private string mPassword = "scpdbpass123";

	public SSHConnector()
	{
        ConnectionInfo cInfo = new ConnectionInfo(mHost, 40, mUser, ProxyTypes.None, "", 0, "","", new PasswordAuthenticationMethod(mUser,mPassword));
        mClient = new SshClient(cInfo);
        mPort = new ForwardedPortLocal("127.0.0.1", 3306, "127.0.0.1", 3306);
	}

    public bool Connect()
    {
        bool lSuccess = true;
        try
        {
            mClient.Connect();
            mClient.AddForwardedPort(mPort);
            mPort.Exception += delegate(object sender, ExceptionEventArgs e)
            {
                MessageBox.Show(e.Exception.ToString());
            };
            mPort.Start();
        }
        catch
        {
            lSuccess = false;
        }
        return lSuccess;
    }

    public bool Disconnect()
    {
        bool lSuccess = true;
        try
        {
            mPort.Start();
            mClient.Disconnect();
        }
        catch
        {
            lSuccess = false;
        }
        return lSuccess;
    }
}
