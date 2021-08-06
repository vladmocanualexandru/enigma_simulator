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
using Enigma.Enumerations;

namespace Enigma.Graphics
{
    class Rotor_GR
    {
        private ConfigurationHolder configHolder = ConfigurationHolder.GetInstance();

        private Rotor referencedRotor;
        private Theme theme;
        private int contactSize,contactSpace,rotorWidth;

        public Rotor_GR(Rotor rotorParam, Theme themeParam)
        {
            referencedRotor = rotorParam;

            contactSize = Int32.Parse(configHolder.Settings["contact_size"]);
            contactSpace = Int32.Parse(configHolder.Settings["contact_space"]);
            rotorWidth = Int32.Parse(configHolder.Settings["rotor_width"]);

            theme = themeParam;

        }

        public void DrawRotor(System.Drawing.Graphics graphics, int x, int y)
        {
            graphics.DrawString(referencedRotor.ConfigNumber.ToString(), theme.BigLabel, theme.Text, x +20, y-30);

            y += 30;

            for (int i = 0; i < 26; i++)
            {

                Contact_GR.DrawContact(graphics, referencedRotor.Contacts[i], x + contactSize / 2, y + referencedRotor.Contacts[i].LeftIndex * contactSpace + contactSize / 2,
                    x + rotorWidth + contactSize / 2, y + referencedRotor.Contacts[i].RightIndex * contactSpace + contactSize / 2, theme);

            }

            for (int i =0; i<26; i++)
            {
                Brush leftDrawingBrush = theme.ContactBlob;
                Brush rightDrawingBrush = theme.ContactBlob;
                if (i == referencedRotor.StepIndex) leftDrawingBrush = rightDrawingBrush = theme.ContactBlobStep;

                Contact leftRefContact = referencedRotor.Contacts.First(contact => contact.LeftIndex == i);
                Contact rightRefContact = referencedRotor.Contacts.First(contact => contact.RightIndex == i);


                switch (leftRefContact.State)
                {
                    case ContactState.NORMAL :
                        break;
                    case ContactState.LEFT_TO_RIGHT:
                        leftDrawingBrush = theme.ContactBlobLR;
                        break;
                    case ContactState.RIGHT_TO_LEFT:
                        leftDrawingBrush = theme.ContactBlobRL;
                        break;
                }

                switch (rightRefContact.State)
                {
                    case ContactState.NORMAL:
                        break;
                    case ContactState.LEFT_TO_RIGHT:
                        rightDrawingBrush = theme.ContactBlobLR;
                        break;
                    case ContactState.RIGHT_TO_LEFT:
                        rightDrawingBrush = theme.ContactBlobRL;
                        break;
                }

                graphics.DrawString(Convert.ToChar((i+referencedRotor.CurrentIndex)%26+65).ToString(), theme.SmallLabel, theme.Text, x+rotorWidth/2, y + i * contactSpace -1 );

                graphics.FillEllipse(leftDrawingBrush, x, y + i * contactSpace, contactSize, contactSize);
                graphics.DrawEllipse(theme.ContactBlobOutline, x, y + i * contactSpace, contactSize, contactSize);

                graphics.FillEllipse(rightDrawingBrush, x + rotorWidth, y + i * contactSpace, contactSize, contactSize);
                graphics.DrawEllipse(theme.ContactBlobOutline, x + rotorWidth, y + i * contactSpace, contactSize, contactSize);



            }
        }



    }
}
