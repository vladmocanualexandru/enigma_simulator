using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using Enigma.Components;
using Enigma.Logistics;

namespace Enigma.Graphics
{
    class Enigma_GR
    {
        private List<Rotor_GR> rotors;
        private InterRotorsConnections_GR connections;
        private Reflector_GR reflector;
        private Plugboard_GR entryBoard_GR;
        private ConfigurationHolder configHolder = ConfigurationHolder.GetInstance();
        private Theme theme;

        private int distanceBetweenRotors;

        public Enigma_GR(EnigmaMachine enigmaMachineParam, Theme theme)
        {
            this.theme = theme;

            entryBoard_GR = new Plugboard_GR(enigmaMachineParam.Plugboard, theme);

            rotors = new List<Rotor_GR>(enigmaMachineParam.Rotors.Count);
            foreach (var rotor in enigmaMachineParam.Rotors.Values)
            {
                rotors.Add(new Rotor_GR(rotor, theme));
            }

            connections = new InterRotorsConnections_GR(enigmaMachineParam.Connections, theme);

            reflector = new Reflector_GR(enigmaMachineParam.Reflector, theme);

            distanceBetweenRotors = Int32.Parse(configHolder.Settings["distance_between_rotors"]);
        }

        public void DrawEnigma(System.Drawing.Graphics graphics , int x, int y)
        {
            graphics.DrawString("Rotors", theme.SmallLabel, theme.Text, x+(distanceBetweenRotors * 3 / 4 + (rotors.Count) * distanceBetweenRotors)/2, y - 60);

            connections.DrawInterRotorsConnection(graphics, x + distanceBetweenRotors*3/4, y + 30);

            for (int i = 0; i < rotors.Count; i++)
            {
                rotors[i].DrawRotor(graphics, x+distanceBetweenRotors*3/4 + i * distanceBetweenRotors, y);
            }

            entryBoard_GR.DrawEntryboard(graphics, x, y + 30);

            reflector.DrawReflector(graphics, x+distanceBetweenRotors*3/4 + rotors.Count*distanceBetweenRotors, y+30);

        }
    }
}
