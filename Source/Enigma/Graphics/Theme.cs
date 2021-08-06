using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace Enigma.Graphics
{
    class Theme
    {
        public Brush ContactBlob { get; set; }
        public Brush ContactBlobLR { get; set; }
        public Brush ContactBlobRL { get; set; }
        public Brush ContactBlobStep { get; set; }
        public Brush ContactBlobReflected { get; set; }
        public Pen ContactBlobOutline { get; set; }

        public Pen ContactBody { get; set; }
        public Pen ContactBodyLR { get; set; }
        public Pen ContactBodyRL { get; set; }

        public Brush Text { get; set;}

        public Pen ContactBodyReflected { get; set; }

        public Font SmallLabel { get; set; }
        public Font BigLabel { get; set; }
        public Font SmallBoldLabel { get; set; }

    }
}
