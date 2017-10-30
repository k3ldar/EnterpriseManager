using System;
using System.Collections.Generic;
using System.Web.UI.DataVisualization.Charting;
using System.Text;
using System.Drawing;
using System.Data;

namespace Website.Library.Classes
{
    public static class Annotation
    {
        #region Annotation

        /// <summary>
        /// Adds annotation to a Chart
        /// </summary>
        /// <param name="chart">Chart to Annotate</param>
        /// <param name="date">Date of Annotation</param>
        /// <param name="description">Annotation Description</param>
        /// <param name="annotationText">Annotation Hint</param>
        /// <param name="createLine">Create an Annotation Line</param>
        public static void AddAnnotation(System.Web.UI.DataVisualization.Charting.Chart chart, DataTable table, DateTime date, 
            string description, string annotationText, bool createLine, bool useMonthOnly, bool createText, bool fullText)
        {
            for (int i = 0; i < table.Rows.Count; i++)
            {
                DateTime rowDate;

                if (useMonthOnly)
                    rowDate = Convert.ToDateTime(String.Format("01/{0}/{1}", (int)table.Rows[i]["Month"], (int)table.Rows[i]["Year"]));
                else
                    rowDate = (DateTime)table.Rows[i]["Date"];

                if ((useMonthOnly && (rowDate.Year == date.Year && rowDate.Month == date.Month)) || (DateTime)rowDate.Date == date.Date)
                {
                    if (createLine)
                    {
                        VerticalLineAnnotation vLine = new VerticalLineAnnotation();
                        vLine.AxisX = chart.ChartAreas[0].AxisX;
                        vLine.AxisY = chart.ChartAreas[0].AxisY;
                        vLine.LineColor = Color.Red;
                        vLine.LineWidth = 2;
                        vLine.LineDashStyle = ChartDashStyle.Solid;
                        vLine.AnchorY = 0;
                        //vLine.ClipToChartArea = chart.ChartAreas[0].Name;
                        vLine.IsInfinitive = true;
                        vLine.EndCap = LineAnchorCapStyle.Round;
                        AddVerticalLineAnnotation(chart, vLine, i);
                    }

                    if (createText)
                    {
                        TextAnnotation vText = new TextAnnotation();
                        vText.Text = description;
                        vText.TextStyle = TextStyle.Frame;
                        //vText.ClipToChartArea = chart.ChartAreas[0].Name;
                        AddTextAnnotation(chart, vText, i, annotationText);
                    }

                    CalloutAnnotation vCallOut = new CalloutAnnotation();

                    if (fullText)
                        vCallOut.Text = String.Format("{0}\r\n{1}", description, annotationText);
                    else
                        vCallOut.Text = description;

                    vCallOut.IsMultiline = vCallOut.Text.Contains("\r\n");

                    //vCallOut.ClipToChartArea = chart.ChartAreas[0].Name;
                    vCallOut.TextStyle = TextStyle.Default;
                    AddCalloutAnnotation(chart, vCallOut, i, annotationText);
                }
            }
        }

        private static void AddCalloutAnnotation(System.Web.UI.DataVisualization.Charting.Chart chart, CalloutAnnotation annotation, int index, string toolTip)
        {
            annotation.AnchorDataPoint = chart.Series[0].Points[index];
            annotation.TextStyle = TextStyle.Default;
            annotation.Font = new Font("Tahoma", 10.0f);
            annotation.LineColor = Color.Black;
            annotation.IsSizeAlwaysRelative = true;
            annotation.AnchorOffsetX = 0;
            annotation.AnchorOffsetY = 10;
            annotation.ToolTip = toolTip;
            annotation.BringToFront();
            annotation.SmartLabelStyle.AllowOutsidePlotArea = LabelOutsidePlotAreaStyle.Yes;
            annotation.SmartLabelStyle.Enabled = true;
            annotation.SmartLabelStyle.IsMarkerOverlappingAllowed = false;
            annotation.SmartLabelStyle.IsOverlappedHidden = false;
            chart.Annotations.Add(annotation);
        }

        private static void AddTextAnnotation(System.Web.UI.DataVisualization.Charting.Chart chart, TextAnnotation annotation, int index, string toolTip)
        {
            annotation.AnchorDataPoint = chart.Series[0].Points[index];
            annotation.TextStyle = TextStyle.Default;
            annotation.Font = new Font("Tahoma", 10.0f);
            annotation.LineColor = Color.Black;
            annotation.ToolTip = toolTip;
            annotation.IsSizeAlwaysRelative = true;
            annotation.AnchorOffsetX = -100;
            chart.Annotations.Add(annotation);
        }

        private static void AddVerticalLineAnnotation(System.Web.UI.DataVisualization.Charting.Chart chart, VerticalLineAnnotation annotation, int index, int lineWidth = 1)
        {
            annotation.AnchorDataPoint = chart.Series[0].Points[index];
            annotation.Height = chart.Series[0].Points[index].YValues[0];
            annotation.IsInfinitive = true;
            annotation.ClipToChartArea = "ChartArea1";
            annotation.LineDashStyle = ChartDashStyle.Solid;
            annotation.LineWidth = lineWidth;
            annotation.BackColor = annotation.LineColor = annotation.ForeColor = Color.Red;
            annotation.SendToBack();
            chart.Annotations.Add(annotation);
        }

        #endregion Annotation

    }
}
