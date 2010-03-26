﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IrcDotNet.CTCP
{
    /// <summary>
    /// Provides methods for communicating with a server using CTCP (Client to Client Protocol), which operates over a
    /// connection to an IRC server.
    /// Do not inherit unless the protocol itself is being extended.
    /// </summary>
    public class CtcpClient
    {
        private IrcClient ircClient;

        /// <summary>
        /// Initializes a new instance of the <see cref="CtcpClient"/> class.
        /// </summary>
        /// <param name="ircClient">The IRC client by which the CTCP client should communicate.</param>
        public CtcpClient(IrcClient ircClient)
        {
            this.ircClient = ircClient;
            
            this.ircClient.Connected += ircClient_Connected;
            this.ircClient.Disconnected += ircClient_Disconnected;
        }

        /// <summary>
        /// Gets or sets the IRC client by which the CTCP client should communicate.
        /// </summary>
        /// <value>The IRC client.</value>
        public IrcClient IrcClient
        {
            get { return this.ircClient; }
        }

        private void ircClient_Connected(object sender, EventArgs e)
        {
            this.ircClient.LocalUser.PreviewMessageReceived += ircClient_LocalUser_PreviewMessageReceived;
            this.ircClient.LocalUser.PreviewNoticeReceived += ircClient_LocalUser_PreviewNoticeReceived;
        }

        private void ircClient_Disconnected(object sender, EventArgs e)
        {
            this.ircClient.LocalUser.PreviewMessageReceived -= ircClient_LocalUser_PreviewMessageReceived;
            this.ircClient.LocalUser.PreviewNoticeReceived -= ircClient_LocalUser_PreviewNoticeReceived;
        }

        private void ircClient_LocalUser_PreviewMessageReceived(object sender, IrcPreviewMessageEventArgs e)
        {
            // TODO
        }

        private void ircClient_LocalUser_PreviewNoticeReceived(object sender, IrcPreviewMessageEventArgs e)
        {
            // TODO
        }
    }
}
