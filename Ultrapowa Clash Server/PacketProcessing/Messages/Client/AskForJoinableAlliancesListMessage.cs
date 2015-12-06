using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using UCS.Core;
using UCS.Helpers;
using UCS.Logic;
using UCS.Network;
using System.Configuration;

namespace UCS.PacketProcessing
{
    //14303
    class AskForJoinableAlliancesListMessage : Message
    {
        private const int m_vAllianceLimit = 40;

        public AskForJoinableAlliancesListMessage(Client client, BinaryReader br) : base(client, br)
        {
            //Empty pack
        }

        public override void Decode()
        {

        }

        public override void Process(Level level)
        {
            string disableClans = ConfigurationManager.AppSettings["disableClans"];
            if (disableClans.Equals("true"))
            {
                List<Alliance> joinableAlliances1 = new List<Alliance>();
                var p1 = new JoinableAllianceListMessage(this.Client);
                p1.SetJoinableAlliances(joinableAlliances1);
                PacketManager.ProcessOutgoingPacket(p1);
            }
            else {
                var alliances = ObjectManager.GetInMemoryAlliances();
                List<Alliance> joinableAlliances = new List<Alliance>();
                int i = 0;
                int j = 0;
                while (j < m_vAllianceLimit && i < alliances.Count)
                {
                    if (alliances[i].GetAllianceMembers().Count != 0 && !alliances[i].IsAllianceFull())
                    {
                        joinableAlliances.Add(alliances[i]);
                        j++;
                    }
                    i++;
                }
                joinableAlliances = joinableAlliances.ToList();

                var p = new JoinableAllianceListMessage(this.Client);
                p.SetJoinableAlliances(joinableAlliances);
                PacketManager.ProcessOutgoingPacket(p);
            }
        }
    }
}