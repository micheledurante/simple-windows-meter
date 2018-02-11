using System.Text;
using System.IO;
using System.Windows.Forms;

namespace NiceMeter
{
    class StreamWriter : TextWriter
    {
        TextBox TextBox = null;

        public StreamWriter(TextBox textBox)
        {
            TextBox = textBox;
        }

        public override void Write(char value)
        {
            base.Write(value);
            TextBox.AppendText(value.ToString()); // When character data is written, append it to the text box.
        }

        public override Encoding Encoding
        {
            get { return Encoding.UTF8; }
        }
    }
}
