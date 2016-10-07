using SAT.Libreria.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;

namespace RecursosHumanos.Models.Clases
{
    /*
    public class MenuMVC
    {
        public void CrearSubMenu(HtmlTextWriter writer, Menu menuItem, List<Menu> lstMenu)
        {
            try
            {

                var lstSubMenus = lstMenu.Where(m => m.MenuPadre == menuItem.Id);

                bool bExisteSubMenu = lstSubMenus.Count() > 0;

                MostrarItemMenu(writer, menuItem, bExisteSubMenu);

                foreach (var item in lstSubMenus)
                {
                    CrearSubMenu(writer, item, lstMenu);
                }

                if (bExisteSubMenu)
                {
                    writer.WriteEndTag("ul");
                }

                writer.WriteEndTag("li");
            }
            catch (Exception)
            {
                throw;
            }

        }

        private static void MostrarItemMenu(HtmlTextWriter writer, Menu menuItem, bool bExisteSubMenu)
        {
            try
            {
                if (bExisteSubMenu)
                {

                    writer.WriteBeginTag("li");
                    writer.WriteAttribute("class", "treeview");
                    writer.Write(HtmlTextWriter.TagRightChar);

                    writer.WriteBeginTag("a");
                    writer.WriteAttribute("href", "#");
                    writer.Write(HtmlTextWriter.TagRightChar);

                    writer.WriteBeginTag("i");

                    //if (menuItem.MenuPadre == 0)
                    if (menuItem.MenuPadre == "0")
                    {
                        writer.WriteAttribute("class", "fa fa-link");
                    }
                    else
                    {
                        writer.WriteAttribute("class", "fa fa-circle-o");
                    }

                    writer.Write(HtmlTextWriter.TagRightChar);
                    writer.WriteEndTag("i");

                    writer.WriteBeginTag("span");
                    writer.Write(HtmlTextWriter.TagRightChar);
                    writer.Write(menuItem.Nombre);
                    writer.WriteEndTag("span");

                    writer.WriteBeginTag("span");
                    writer.WriteAttribute("class", "pull-right-container");
                    writer.Write(HtmlTextWriter.TagRightChar);

                    writer.WriteBeginTag("i");
                    writer.WriteAttribute("class", "fa fa-angle-left pull-right");
                    writer.Write(HtmlTextWriter.TagRightChar);
                    writer.WriteEndTag("i");
                    writer.WriteEndTag("span");

                    writer.WriteEndTag("a");

                    writer.WriteBeginTag("ul");
                    writer.WriteAttribute("class", "treeview-menu");
                    writer.Write(HtmlTextWriter.TagRightChar);
                }
                else
                {
                    writer.WriteBeginTag("li");
                    writer.Write(HtmlTextWriter.TagRightChar);

                    writer.WriteBeginTag("a");
                    writer.WriteAttribute("href", menuItem.Link);
                    writer.Write(HtmlTextWriter.TagRightChar);

                    writer.WriteBeginTag("i");
                    writer.WriteAttribute("class", "fa fa-circle-o");
                    writer.Write(HtmlTextWriter.TagRightChar);
                    writer.WriteEndTag("i");

                    writer.WriteBeginTag("span");
                    writer.Write(HtmlTextWriter.TagRightChar);
                    writer.Write(menuItem.Nombre);
                    writer.WriteEndTag("span");

                    writer.WriteEndTag("a");
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
    */
}