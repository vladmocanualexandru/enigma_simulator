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
    class Reflector_GR
    {
        private ConfigurationHolder configHolder = ConfigurationHolder.GetInstance();

        private Reflector referencedReflector;
        private Theme theme;
        private int contactSize,contactSpace,reflectorWidth;

        public Reflector_GR(Reflector reflectorParam,Theme themeParam)
        {
            referencedReflector = reflectorParam;

            contactSize = Int32.Parse(configHolder.Settings["contact_size"]);
            contactSpace = Int32.Parse(configHolder.Settings["contact_space"]);
            reflectorWidth = Int32.Parse(configHolder.Settings["reflector_width"]);

            theme = themeParam;
        }

        public void DrawReflector(System.Drawing.Graphics graphics, int x, int y)
        {
            graphics.DrawString("Reflector", theme.SmallLabel, theme.Text, x, y - 90);

            foreach (Contact contact in referencedReflector.Contacts)
            {
                int arcX = x - reflectorWidth /2+ contactSize / 2, arcY, arcHeight;
                if (contact.LeftIndex < contact.RightIndex)
                {
                    arcY = y + contact.LeftIndex*contactSpace+contactSize/2;
                    arcHeight = (contact.RightIndex-contact.LeftIndex)*contactSpace;
                }
                else
                {
                    arcY = y + contact.RightIndex * contactSpace + contactSize / 2;
                    arcHeight = (contact.LeftIndex-contact.RightIndex)*contactSpace;
                }

                graphics.DrawArc(contact.State==ContactState.NORMAL?theme.ContactBody:theme.ContactBodyReflected, arcX, arcY, reflectorWidth, arcHeight, -90, 180);
            }

            for (int i =0; i<26; i++)
            {
                Brush drawingBrush = theme.ContactBlob;
                if (referencedReflector.MarkedContact.State != ContactState.NORMAL)
                {
                    if (i == referencedReflector.MarkedContact.LeftIndex ||
                        i == referencedReflector.MarkedContact.RightIndex)
                    {
                        drawingBrush = theme.ContactBlobReflected;
                    }
                }
                graphics.FillEllipse(drawingBrush, x, y + i * contactSpace, contactSize, contactSize);
                graphics.DrawEllipse(theme.ContactBlobOutline, x, y + i * contactSpace, contactSize, contactSize);

            }
        }


    }
}
