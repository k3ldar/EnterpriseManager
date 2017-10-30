using System;

namespace Classes.Web
{
	/// <summary>
	/// Summary description for FixedTextBox.
	/// </summary>
	public class FixedTextBox : System.Web.UI.WebControls.TextBox
	{
		protected override void Render(System.Web.UI.HtmlTextWriter writer)
		{
			#region Add Cross Browser Size To Attributes Collection
			#region Width
			if(this.Width != System.Web.UI.WebControls.Unit.Empty)
			{
				string WidthString = this.Width.Value.ToString();
				#region Append UnitType Symbol
				switch(this.Width.Type)
				{
					case System.Web.UI.WebControls.UnitType.Percentage:
						WidthString += "%";
						break;

					case System.Web.UI.WebControls.UnitType.Pixel:
						WidthString += "px";
						break;
				}
				#endregion Append UnitType Symbol
				if(this.TextMode == System.Web.UI.WebControls.TextBoxMode.MultiLine)
				{
					this.Attributes.Add("width", WidthString);
					this.Attributes.Add("style", "width:" + WidthString); // Firefox
				}
				else
				{
					//this.Attributes.Add("width", WidthString);
					this.Attributes.Add("style", "width:" + WidthString); // Firefox
				}
			}
			#endregion Width
			#region Height
			if(this.Height != System.Web.UI.WebControls.Unit.Empty)
			{
				string HeightString = this.Height.Value.ToString();
				#region Append UnitType Symbol
				switch(this.Height.Type)
				{
					case System.Web.UI.WebControls.UnitType.Percentage:
						HeightString += "%";
						break;

					case System.Web.UI.WebControls.UnitType.Pixel:
						HeightString += "px";
						break;
				}
				#endregion Append UnitType Symbol
				this.Attributes.Add("height", HeightString);
			}
			#endregion Height
			#endregion Add Cross Browser Size To Attributes Collection
			base.Render (writer);
		}

	}
}
