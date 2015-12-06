using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using UCS.Logic;
using UCS.Helpers;
using UCS.GameFiles;
using UCS.Core;
using UCS.Network;

namespace UCS.PacketProcessing
{
    class AddResCommand : GameOpCommand
    {
        private string[] m_vArgs;
       
        public AddResCommand(string[] args)
        {
            m_vArgs = args;
           
           
        }

        public override void Execute(Level level)
        {
          
                if(m_vArgs.Length >= 2)
                {
                if (m_vArgs[1].Equals("Gold") || m_vArgs[1].Equals("Elixir") || m_vArgs[1].Equals("DarkElixir") || m_vArgs[1].Equals("Diamonds"))
                {
                    try
                    {
                        long senderId = level.GetPlayerAvatar().GetId();
                        var l = ResourcesManager.GetPlayer(senderId, true);
                        var resourceinput = m_vArgs[1];
                        int amount = Int32.Parse(m_vArgs[2]);
                        ClientAvatar ca = level.GetPlayerAvatar();
                        var resource = ObjectManager.DataTables.GetResourceByName(resourceinput);
                        int currentres = ca.GetResourceCount(resource);
                        ca.SetResourceCount(resource, amount + currentres);
                        PacketManager.ProcessOutgoingPacket(new OwnHomeDataMessage(level.GetClient(), level));
                        var p = new GlobalChatLineMessage(level.GetClient());
                        p.SetChatMessage("Added Resource: " + resourceinput + " Amount: " + amount.ToString());
                        p.SetPlayerId(senderId);
                        p.SetLeagueId(level.GetPlayerAvatar().GetLeagueId());
                        PacketManager.ProcessOutgoingPacket(p);
                    }
                    catch (Exception ex)
                    {
                        Debugger.WriteLine("RenameAvatar failed with error: " + ex.ToString());
                    }
                }
                else
                {
                    long senderId = level.GetPlayerAvatar().GetId();
                    var p = new GlobalChatLineMessage(level.GetClient());
                    p.SetChatMessage("Add Resource failed! Invalid Type. Avaible Resources: Elixir, Gold, DarkElixir, Diamonds. Usage: /addres resource amount");
                    p.SetPlayerId(senderId);
                    p.SetLeagueId(level.GetPlayerAvatar().GetLeagueId());
                    PacketManager.ProcessOutgoingPacket(p);

                }
            }
            else
            {
                long senderId = level.GetPlayerAvatar().GetId();
                var p = new GlobalChatLineMessage(level.GetClient());
                p.SetChatMessage("Add Resource failed! Invalid Type. Avaible Resources: Elixir, Gold, DarkElixir, Diamonds. Usage: /addres resource amount");
                p.SetPlayerId(senderId);
                p.SetLeagueId(level.GetPlayerAvatar().GetLeagueId());
                PacketManager.ProcessOutgoingPacket(p);
            }
            }
            
        }
    }

