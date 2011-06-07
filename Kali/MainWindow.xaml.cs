using System.Linq;
using System.Windows;

namespace Kali
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void ResolveKotusResults(object sender, RoutedEventArgs e)
        {
            var resolveFromKotus = Module1.resolveFromKotus(textBox1.Text);
            textBlock1.Text = "";
            /*for (var i = 0; i < resolveFromKotus.Count(); i++)
            {
                textBlock1.Text += resolveFromKotus.ElementAt(i) + ", ";
                textBlock1.Text += i%8 == 0 ? "\n" : "";
            }*/
            int ui = 0;

            var splits = from name in resolveFromKotus
                         group name by ui++ < 8 into part
                         select part.AsEnumerable().Aggregate(((x, y) => x + ", " + y));
            var f = resolveFromKotus.Where((x, i) => i % 8 == 0).Select((x, i) => resolveFromKotus.Skip(i * 8).Take(8));
            var joined = f.Select(chunk => chunk.Aggregate(((x, y) => x + ", " + y)));
            foreach (var result in joined)
            {
                textBlock1.Text += result + "\n";
            }
        


            // from x in resolveFromKotus
            /*while(resolveFromKotus.Any())
            {
                var enumerable = resolveFromKotus.Take(5);
                textBlock1.Text += enumerable.Aggregate((x, y) => x + ", " + y);
                resolveFromKotus.Skip(5);
            }
             */
        }
    }
}