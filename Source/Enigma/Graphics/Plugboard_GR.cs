using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using Enigma.Components;
using Enigma.Enumerations;
using Enigma.Logistics;
using Enigma.Interfaces;

namespace Enigma.Graphics
{
    class Plugboard_GR
    {
        private Plugboard referencedPB;

        private ConfigurationHolder configHolder = ConfigurationHolder.GetInstance();
        private Theme theme;
        private int contactSize, contactSpace, reflectorWidth;

        public Plugboard_GR(Plugboard referencedPbParam, Theme themeParam)
        {
            contactSize = Int32.Parse(configHolder.Settings["contact_size"]);
            contactSpace = Int32.Parse(configHolder.Settings["contact_space"]);
            reflectorWidth = Int32.Parse(configHolder.Settings["reflector_width"]);

            theme = themeParam;

            referencedPB = referencedPbParam;


        }

        public void DrawEntryboard(System.Drawing.Graphics graphics, int x, int y)
        {
            graphics.DrawString("Plugboard", theme.SmallLabel, theme.Text, x-10, y - 90);

            x += 15;

            foreach (var contact in referencedPB.Contacts)
            {
                if (contact.LeftIndex != contact.RightIndex)
                {

                    int arcX = x - reflectorWidth / 2 + contactSize / 2, arcY, arcHeight;
                    if (contact.LeftIndex < contact.RightIndex)
                    {
                        arcY = y + contact.LeftIndex * contactSpace + contactSize / 2;
                        arcHeight = (contact.RightIndex - contact.LeftIndex) * contactSpace;
                    }
                    else
                    {
                        arcY = y + contact.RightIndex * contactSpace + contactSize / 2;
                        arcHeight = (contact.LeftIndex - contact.RightIndex) * contactSpace;
                    }

                    var activeBrush = theme.ContactBody;
                    if (contact.State!=ContactState.NORMAL)
                    {
                        activeBrush = contact.State == ContactState.LEFT_TO_RIGHT
                                          ? theme.ContactBodyLR
                                          : theme.ContactBodyRL;
                    }

                    graphics.DrawArc(activeBrush, arcX + 10, arcY, reflectorWidth, arcHeight, -90, -180);
                }
            }

            for (int i = 0; i < 26; i++)
            {
                Brush specialCaseBrush=null;

                if (referencedPB.Contacts[i].State==ContactState.LEFT_TO_RIGHT)
                {
                    specialCaseBrush = theme.ContactBlobLR;
                }
                else if (referencedPB.Contacts[i].State == ContactState.RIGHT_TO_LEFT)
                {
                    specialCaseBrush = theme.ContactBlobRL;
                }


                graphics.DrawString(Convert.ToChar(i + 65).ToString(), theme.SmallBoldLabel, specialCaseBrush ?? theme.Text, x, y + i * contactSpace - 1);

                graphics.FillEllipse(specialCaseBrush ?? theme.ContactBlob, x + 15, y + i * contactSpace, contactSize, contactSize);
                graphics.DrawEllipse(theme.ContactBlobOutline, x + 15, y + i * contactSpace, contactSize, contactSize);

            }
        }

    }
}
