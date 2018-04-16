using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace boxitem.View
{
    /// <summary>
    /// Interaction logic for Boxes.xaml
    /// </summary>
    public partial class Boxes : Window
    {

        public Boxes(int id)
        {
            InitializeComponent();
            CurrentInfo currentuser = new CurrentInfo();
            //MessageBox.Show(currentuser.ToString());
            //MessageBox.Show(id.ToString());
                DisplayBoxes(id);
        }
        private void DisplayBoxes(int id)
        {
            using (var bb = new BoxesEntities())
            {
                //var boxes = from b in bb.Boxes
                //            select new
                //            {
                //                Name = b.Name,
                //                Number = b.Number,
                //                Description = b.Description

                //            };

                //IQueryable<Boxes> box =
                //        from u in bb.Boxes
                //        where u.UserId=id;
                //        select u;

                //foreach (var item in box)
                //{

                //}
               
                var boxes = bb.Boxes
                    .ToList()
                    .Where(x=>x.UserId==id)
                    .Select(x => ViewModel.BoxViewModel.Create(x.Name, x.Number, x.Description))
                    //.Where()
                    .ToList();               

                datagridBoxes.ItemsSource = boxes;

               // boxes.Add(ViewModel.BoxViewModel.Create("asd", 234, "asd"));
                bb.SaveChanges();

            }
        }
    }
}
