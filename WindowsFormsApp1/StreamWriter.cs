using System.Text;
using System.IO;
using System.Windows.Forms;

namespace NiceMeter
{
    class StreamWriter : TextWriter
    {
        TextBox Output = null;

        public StreamWriter(TextBox output)
        {
            Output = output;
        }

        public override void Write(char value)
        {
            base.Write(value);
            Output.AppendText(value.ToString()); // When character data is written, append it to the text box.
        }

        public override Encoding Encoding
        {
            get { return Encoding.UTF8; }
        }
    }
}
