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

namespace Enigma.Graphics
{
    class Contact_GR
    {
        public static void DrawContact(System.Drawing.Graphics graphics, Contact contact, int xA, int yA, int xB, int yB, Theme theme)
        {
            Point contactA = new Point(xA,yA);
            Point contactB = new Point(xB,yB);

            Pen drawingPen;
            switch (contact.State)
            {
                case ContactState.LEFT_TO_RIGHT:
                    drawingPen = theme.ContactBodyLR;
                    break;
                case ContactState.RIGHT_TO_LEFT:
                    drawingPen = theme.ContactBodyRL;
                    break;
                default:
                    drawingPen = theme.ContactBody;
                    break;
            }

            graphics.DrawLine(drawingPen, contactA, contactB);
        }
    }
}
