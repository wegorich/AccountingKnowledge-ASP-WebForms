using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;
using BusinessLogic;
using Model;

namespace AKSite.Profile
{
    /// <summary>
    /// Resume simple constructor for user profile.
    /// </summary>
    public partial class ResumeConstructor : System.Web.UI.Page
    {
        protected string NoneSkill = "--";

        /// <summary>
        /// Personals the data selecting.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">
        /// The <see cref="System.Web.UI.WebControls.ObjectDataSourceSelectingEventArgs"/> 
        /// instance containing the event data.
        /// </param>
        protected void PersonalDataSelecting(object sender, ObjectDataSourceSelectingEventArgs e)
        {
            e.InputParameters["login"] = HttpContext.Current.User.Identity.Name;
        }

        /// <summary>
        /// Nexts the click.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">
        /// The <see cref="System.EventArgs"/>
        ///  instance containing the event data.
        /// </param>
        protected void NextClick(object sender, EventArgs e)
        {
            multiView.ActiveViewIndex++;
            stepView.Items[multiView.ActiveViewIndex].Selected = true;

            if (multiView.ActiveViewIndex != multiView.Controls.Count - 1) return;

            resume.ResumeDataSource = new List<Model.Resume> {GetResume()};
            
            start.Visible = false;
            save.Visible = true;
            dontSave.Visible = true;
        }

        private Model.Resume GetResume()
        {
            return ResumeService.GetFakeResume(
                title.Text,
                description.Text,
                User.Identity.Name,
                GetResumeField());

        }

        /// <summary>
        /// Gets the resume field.
        /// </summary>
        protected List<ResumeField> GetResumeField()
        {
            var result = new List<ResumeField>();
            foreach (RepeaterItem filed in fieldRepeater.Items)
            {
                var lbl = (Label)filed.FindControl("field");
                var listView = (ListView)filed.FindControl("themeListView");
                var item = new ResumeField
                {
                    FieldName = lbl.Text,
                    Theme = new List<ResumeTheme>()
                };

                foreach (var theme in listView.Items)
                {
                    var skill = (DropDownList)theme.FindControl("themeSkils");
                    if (skill.SelectedIndex == 0) continue;

                    var themeId = (Label)theme.FindControl("themeId");
                    var themeName = (Label)theme.FindControl("theme");

                    item.Theme.Add(new ResumeTheme
                                       {
                                           SkillId = Convert.ToInt32(skill.SelectedValue),
                                           SkillName = skill.SelectedItem.Text,
                                           ThemeId = Convert.ToInt32(themeId.Text),
                                           ThemeName = themeName.Text
                                       });
                }
                result.Add(item);
            }
            foreach (var item in result.Where(item => item.Theme.Count == 0))
            {
                result.Remove(item);
            }
            return result;
        }

        /// <summary>
        /// Saves the resume.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">
        /// The <see cref="System.EventArgs"/> instance containing the event data.
        /// </param>
        protected void SaveResume(object sender, EventArgs e)
        {
            ResumeService.AddResume(GetResume());

            Response.Redirect("~/Profile/Default.aspx");
        }

        /// <summary>
        /// Backs the specified sender.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">
        /// The <see cref="System.EventArgs"/> instance containing the event data.</param>
        protected void Back(object sender, EventArgs e)
        {
            Response.Redirect(HttpContext.Current.Request.Path);
        }

        /// <summary>
        /// Fields the check box index changed.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">
        /// The <see cref="System.EventArgs"/> instance containing the event data.</param>
        protected void FieldCheckBoxIndexChanged(object sender, EventArgs e)
        {
            var list = new List<Field>();
            foreach (ListItem item in fieldCheckBox.Items)
            {
                item.Enabled = true;
                if (item.Selected)
                    list.Add(new Field
                                 {
                                     Id = Convert.ToInt32(item.Value),
                                     Title = item.Text
                                 });
            }

            if (list.Count == 3)
                foreach (var item in fieldCheckBox.Items.Cast<ListItem>().Where(item => !item.Selected))
                    item.Enabled = false;

            fieldRepeater.DataSource = list;
            fieldRepeater.DataBind();
        }

        /// <summary>
        /// Fields the repeater item data bound.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">
        /// The <see cref="System.Web.UI.WebControls.RepeaterItemEventArgs"/> 
        /// instance containing the event data.
        /// </param>
        protected void FieldRepeaterItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            var item = e.Item;
            if ((item.ItemType != ListItemType.Item) &&
                (item.ItemType != ListItemType.AlternatingItem)) return;

            var rep = (ListView)item.FindControl("themeListView");
            var value = ((Field)item.DataItem).Id.ToString();

            themesData.SelectParameters[0].DefaultValue = value;
            object data = themesData.Select();

            rep.DataSource = data;
            rep.DataBind();

        }
    }
}