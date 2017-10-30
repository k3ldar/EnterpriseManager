using System;
using System.Collections.Generic;
using System.IO;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;

using Library;
using Languages;
using Website.Library.Classes;
using Library.BOL.StockControl;
using Heavenskincare.Website.Staff.Reports.Stock;
using Library.BOL.Products;
using Library.BOL.Locations;

namespace Heavenskincare.WebsiteTemplate.Staff.Reports
{
    public partial class StockControl : BaseWebFormStaff
    {
        #region Private Members

        private Library.BOL.StockControl.Stock _stock;

        #endregion Private Members

        #region Protected Methods

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!GetUser().HasPermissionWebsite(Library.SecurityEnums.SecurityPermissionsWebsite.ViewOnlineReports))
            {
                DoRedirect("/Members/InvalidPermissions.aspx");
                return;
            }

            _stock = Library.BOL.StockControl.Stock.Get(GetUser(), GetFormValue("ID", -1));

            if (_stock == null)
                DoRedirect("/Staff/Reports/Index.aspx");

            if (!IsPostBack)
                LoadProductTypes();

            cmbProductType.SelectedIndexChanged += new EventHandler(cmbProductType_SelectedIndexChanged);
            LoadStock();
        }

        protected string GetLocationName()
        {
            string Result = "";

            StoreLocation location = Locations.Get(GetFormValue("ID", -1));

            if (location == null)
                Result = LanguageStrings.Unknown;
            else
                Result = location.StoreName;

            return (Result);
        }

        protected string GetLocationID()
        {
            return (GetFormValue("ID"));
        }

        protected void btnDownload_Click(object sender, EventArgs e)
        {
            PdfStockReport rpt = new PdfStockReport(GetLocationName(), _stock);

            string fname = rpt.FileName;

            string path = fname; // MapPath(fname);
            string name = Path.GetFileName(path);
            string ext = Path.GetExtension(path);
            string type = "application/pdf";

            Response.AppendHeader("content-disposition",
                    "attachment; filename=" + name);
            Response.ContentType = type;
            Response.WriteFile(path);
            Response.End();
        }

        #endregion Protected Methods

        #region Private Methods

        private void cmbProductType_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadStock();
        }

        private void LoadProductTypes()
        {
            cmbProductType.Items.Clear();

            foreach (ProductCostType item in ProductCostTypes.Get())
            {
                cmbProductType.Items.Add(item.Description);
            }

            cmbProductType.SelectedIndex = 0;
        }

        private void LoadStock()
        {
            for (int i = 1; i < tblStock.Rows.Count; i++)
                tblStock.Rows.RemoveAt(i);

            ProductCostType ptype = ProductCostTypes.Get((string)cmbProductType.Items[cmbProductType.SelectedIndex].Text);

            foreach (StockItem item in _stock)
            {
                if (item.ProductType.ID == ptype.ID)
                {
                    //new row
                    HtmlTableRow row = new HtmlTableRow();
                    tblStock.Rows.Add(row);

                    //sku
                    HtmlTableCell sku = new HtmlTableCell();
                    sku.InnerText = item.SKU;
                    sku.Align = "left";
                    row.Cells.Add(sku);

                    //product
                    HtmlTableCell prod = new HtmlTableCell();
                    prod.InnerText = item.Name;
                    prod.Align = "left";
                    row.Cells.Add(prod);

                    //size
                    HtmlTableCell size = new HtmlTableCell();
                    size.InnerText = item.Size;
                    size.Align = "left";
                    row.Cells.Add(size);

                    //quantity
                    HtmlTableCell qty = new HtmlTableCell();
                    qty.InnerText = item.Available.ToString();

                    if (item.Available < item.MinLevel)
                    {
                        qty.Attributes.Add("class", "lowStock textCenter");
                    }
                    else
                    {
                        if (item.Available < (item.MinLevel + 15))
                        {
                            qty.Attributes.Add("class", "nearStock textCenter");
                        }
                        else
                            qty.Attributes.Add("class", "textCenter");
                    }

                    row.Cells.Add(qty);

                    //min order level
                    HtmlTableCell min = new HtmlTableCell();
                    min.InnerText = item.MinLevel.ToString();
                    min.Attributes.Add("class", "textCenter");
                    row.Cells.Add(min);

                    //order qty
                    HtmlTableCell reorder = new HtmlTableCell();
                    reorder.InnerText = item.OrderQuantity.ToString();
                    reorder.Attributes.Add("class", "textCenter");
                    row.Cells.Add(reorder);

                    // product type
                    HtmlTableCell type = new HtmlTableCell();
                    type.InnerText = item.ProductType.Description;
                    row.Cells.Add(type);
                }
            }
        }

        #endregion Private Methods
    }
}