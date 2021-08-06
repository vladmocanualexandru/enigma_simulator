using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using Enigma.Logistics;
using Enigma.Components;

namespace Enigma.Graphics
{
    class InterRotorsConnections_GR
    {
        private ConfigurationHolder configHolder = ConfigurationHolder.GetInstance();

        private InterRotorsConnection referencedConnection;

        private Theme theme;
        private int contactSpace, contactSize, distanceBetweenRotors, rotorWidth;


        public InterRotorsConnections_GR(InterRotorsConnection connection, Theme themeParam)
        {
            referencedConnection = connection;

            contactSpace = Int32.Parse(configHolder.Settings["contact_space"]);
            contactSize = Int32.Parse(configHolder.Settings["contact_size"]);
            distanceBetweenRotors = Int32.Parse(configHolder.Settings["contact_size"]);
            rotorWidth = Int32.Parse(configHolder.Settings["rotor_width"]);

            theme = themeParam;
        }

        public void DrawInterRotorsConnection(System.Drawing.Graphics graphics, int x, int y)
        {
            for (int i = 0; i < referencedConnection.Contacts.Keys.Count; i++ )
            {

                for (int j = 0; j < 26; j++)
                {
                    Contact_GR.DrawContact(graphics, referencedConnection.Contacts["rotor_" + i][j], x + (2 * i - 1) * rotorWidth + contactSize / 2, y + j * contactSpace + contactSize / 2,
                        x + 2 * i * rotorWidth + contactSize / 2, y + j * contactSpace + contactSize / 2,theme);

                }
            }

        }
    }
}
