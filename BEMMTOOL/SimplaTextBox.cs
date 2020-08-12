using System.Drawing;
using System.Windows.Forms;

namespace BEMMTOOL
{
	public class SimplaTextBox : TextBox
	{
		public SimplaTextBox()
		{
			base.BorderStyle = BorderStyle.FixedSingle;
			Font = new Font("Tahoma", 9f, FontStyle.Bold);
			BackColor = Color.FromArgb(35, 35, 35);
			ForeColor = Color.WhiteSmoke;
		}
	}
}
