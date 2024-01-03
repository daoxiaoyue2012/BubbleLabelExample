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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace BubbleLabelExample
{
    /// <summary>
    /// Interaction logic for BubbleLabel.xaml
    /// </summary>
    public partial class BubbleLabel : UserControl
    {
        public BubbleLabel()
        {
            InitializeComponent();
        }

        public static new readonly DependencyProperty BackgroundProperty = DependencyProperty.Register("Background", typeof(Brush), typeof(BubbleLabel), new PropertyMetadata(new SolidColorBrush()));
        public new Brush Background
        {
            get { return (Brush)GetValue(BackgroundProperty); } 
            set { SetValue(BackgroundProperty, value); }
        }

        public static new readonly DependencyProperty ContentProperty = DependencyProperty.Register("Content", typeof(string), typeof(BubbleLabel), new PropertyMetadata(""));
        public new string Content
        {
            get { return (string)GetValue(ContentProperty); }
            set { SetValue(ContentProperty, value); }
        }

        public static readonly DependencyProperty PositionProperty = DependencyProperty.Register("Position", typeof(BubbleLabelPosition), typeof(BubbleLabel), new PropertyMetadata(BubbleLabelPosition.Left, new PropertyChangedCallback(OnPositionChanged)));
        public BubbleLabelPosition Position
        {
            get { return (BubbleLabelPosition)GetValue(PositionProperty); }
            set { SetValue(PositionProperty, value); }
        }

        private static void OnPositionChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var bubbleLabel = (BubbleLabel)d;
            if (bubbleLabel.Position is BubbleLabelPosition position)
            {
                switch(position)
                {
                    case BubbleLabelPosition.Left:
                        bubbleLabel.labelPath.Data = Geometry.Parse("M0,0 L-9,9 -9,11 0,20");
                        bubbleLabel.labelPath.Margin = new Thickness(0, 10, 0, 0);
                        bubbleLabel.labelPath.HorizontalAlignment = HorizontalAlignment.Left;
                        bubbleLabel.labelPath.VerticalAlignment = VerticalAlignment.Top;
                        bubbleLabel.labelBorder.Margin = new Thickness(8, 0, 0, 0);
                        break;

                    case BubbleLabelPosition.Right:
                        bubbleLabel.labelPath.Data = Geometry.Parse("M0,0 L9,9 9,11 0,20");
                        bubbleLabel.labelPath.Margin = new Thickness(0, 10, 0, 0);
                        bubbleLabel.labelPath.HorizontalAlignment = HorizontalAlignment.Right;
                        bubbleLabel.labelPath.VerticalAlignment = VerticalAlignment.Top;
                        bubbleLabel.labelBorder.Margin = new Thickness(0, 0, 8, 0);
                        break;

                    case BubbleLabelPosition.Top:
                        bubbleLabel.labelPath.Data = Geometry.Parse("M0,0 L9,-12 11,-12 20,0");
                        bubbleLabel.labelPath.HorizontalAlignment = HorizontalAlignment.Center;
                        bubbleLabel.labelPath.VerticalAlignment = VerticalAlignment.Top;
                        bubbleLabel.labelBorder.Margin = new Thickness(0, 8, 0, 0);
                        break;

                    case BubbleLabelPosition.Bottom:
                        bubbleLabel.labelPath.Data = Geometry.Parse("M0,0 L9,12 11,12 20,0");
                        bubbleLabel.labelPath.HorizontalAlignment = HorizontalAlignment.Center;
                        bubbleLabel.labelPath.VerticalAlignment = VerticalAlignment.Bottom;
                        bubbleLabel.labelBorder.Margin = new Thickness(0, 0, 0, 8);
                        break;
                }
            }
        }
    }

    public enum BubbleLabelPosition
    {
        Top,
        Bottom,
        Left,
        Right
    }
}
