using System;
using System.Web.UI.WebControls;

namespace AKSite.UserControl
{
    /// <summary>
    /// Show 3 dropDownList to input date.
    /// </summary>
    public partial class DateDropDown : System.Web.UI.UserControl
    {
        /// <summary>
        /// Default value to none select.
        /// </summary>
        protected string NoneValue = "--";

        /// <summary>
        /// Raises the <see cref="E:System.Web.UI.Control.Init"/> event.
        /// </summary>
        /// <param name="e">
        /// An <see cref="T:System.EventArgs"/> object that contains the event data.</param>
        protected override void OnInit(EventArgs e)
        {
           if (!Parent.Page.IsPostBack || day.Controls.Count == 0)
            {
                var none = new ListItem
                               {
                                   Text = NoneValue,
                                   Value = (string) GetLocalResourceObject("ZeroValue")
                               };

                day.Items.Add(none);
                month.Items.Insert(0, none);
                year.Items.Add(none);

                for (var x = 1; x < 32; x++)
                {
                    day.Items.Add(new ListItem
                                      {
                                          Text = x.ToString(),
                                          Value = x.ToString(),
                                      });
                }

                var curYear = DateTime.Now.Year;
                for (int x = 18; x < 65; x++)
                {
                    var str = (curYear - x).ToString();
                    year.Items.Add(new ListItem
                                       {
                                           Text = str,
                                           Value = str,
                                       });
                }
            }
            base.OnInit(e);
        }

        /// <summary>
        /// Gets or sets the get date.
        /// </summary>
        /// <value>The get date.</value>
        public DateTime GetDate
        {
            get
            {
                int valueYear;
                int valueDay;
                int valueMonth;
                int.TryParse(year.SelectedValue, out valueYear);
                int.TryParse(month.SelectedValue, out valueMonth);
                int.TryParse(day.SelectedValue, out valueDay);

                if (valueYear == 0 || valueMonth == 0 || valueDay == 0)
                    return DateTime.Now;

                return new DateTime(valueYear, valueMonth, valueDay);
            }
            set
            {
                var valueDay = value.Day.ToString();
                var valueMonth = value.Month.ToString();
                var valueYear = value.Year.ToString();

                SetDate(valueDay, day);
                SetDate(valueMonth, month);
                SetDate(valueYear, year);
            }
        }

        /// <summary>
        /// Sets the date.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="list">The list.</param>
        protected void SetDate(string value, DropDownList list)
        {
            for (var i = 1; i < list.Items.Count; i++)
            {
                if (list.Items[i].Value != value) continue;

                list.SelectedIndex = i;
                break;
            }
        }
    }
}