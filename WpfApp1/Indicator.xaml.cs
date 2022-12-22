//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using System.Windows;
//using System.Windows.Controls;
//using System.Windows.Data;
//using System.Windows.Documents;
//using System.Windows.Input;
//using System.Windows.Media;
//using System.Windows.Media.Imaging;
//using System.Windows.Navigation;
//using System.Windows.Shapes;

//namespace WpfApp1
//{
//    /// <summary>
//    /// Логика взаимодействия для Indicator.xaml
//    /// </summary>
//    public partial class ColorPicker : UserControl
//    {
//        public ColorPicker()
//        {
//            InitializeComponent();
//        }

//        public Color Color
//        {
//            get { return (Color)GetValue(ColorProperty); }
//            set { SetValue(ColorProperty, value); }
//        }
//        public byte Red
//        {
//            get { return (byte)GetValue(RedProperty); }
//            set { SetValue(RedProperty, value); }
//        }
//        public byte Green
//        {
//            get { return (byte)GetValue(GreenProperty); }
//            set { SetValue(GreenProperty, value); }
//        }
//        public byte Blue
//        {
//            get { return (byte)GetValue(BlueProperty); }
//            set { SetValue(BlueProperty, value); }
//        }

//        public static readonly DependencyProperty ColorProperty;
//        public static readonly DependencyProperty RedProperty;
//        public static readonly DependencyProperty GreenProperty;
//        public static readonly DependencyProperty BlueProperty;

//        public static readonly RoutedEvent ColorChangedEvent;

//        //статический конструктор
//        static ColorPicker() 
//        {
//            ColorProperty =DependencyProperty.Register(
//                "Color",
//                typeof(Color),
//                typeof(ColorPicker),
//                new FrameworkPropertyMetadata(
//                    Colors.Black,
//                    new PropertyChangedCallback(OnColorChanged)
//                ));

//            RedProperty = DependencyProperty.Register(
//                "Red",
//                typeof(Color),
//                typeof(ColorPicker),
//                new FrameworkPropertyMetadata(
//                    new PropertyChangedCallback(OnColorRGBChanged)
//                ));

//            GreenProperty = DependencyProperty.Register(
//                "Green",
//                typeof(Color),
//                typeof(ColorPicker),
//                new FrameworkPropertyMetadata(
//                    new PropertyChangedCallback(OnColorRGBChanged)
//                ));

//            BlueProperty = DependencyProperty.Register(
//                "Blue",
//                typeof(Color),
//                typeof(ColorPicker),
//                new FrameworkPropertyMetadata(
//                    new PropertyChangedCallback(OnColorRGBChanged)
//                ));

//            ColorChangedEvent = EventManager.RegisterRoutedEvent("ColorChanged", RoutingStrategy.Bubble,
//                typeof(RoutedPropertyChangedEventHandler<Color>), typeof(ColorPicker));
//        }


//        private static void OnColorRGBChanged(DependencyObject sender,
//            DependencyPropertyChangedEventArgs e)
//        {
//            ColorPicker indicator = (ColorPicker)sender;
//            Color color = indicator.Color;
//            if (e.Property == RedProperty)
//                color.R = (byte)e.NewValue;
//            else if (e.Property == GreenProperty)
//                color.G = (byte)e.NewValue;
//            else if (e.Property == BlueProperty)
//                color.B = (byte)e.NewValue;

//            indicator.Color = color;
//        }

//        public event RoutedPropertyChangedEventHandler<Color> ColorChanged
//        {
//            add { AddHandler(ColorChangedEvent, value); }
//            remove { RemoveHandler(ColorChangedEvent, value); }
//        }

//        //Событие изменения цвета
//        private static void OnColorChanged(DependencyObject sender,
//        DependencyPropertyChangedEventArgs e)
//        {
//            Color newColor = (Color)e.NewValue;
//            ColorPicker indicator = (ColorPicker)sender;
//            indicator.Red = newColor.R;
//            indicator.Green = newColor.G;
//            indicator.Blue = newColor.B;

//            RoutedPropertyChangedEventArgs<Color> args = new RoutedPropertyChangedEventArgs<Color>(indicator.Color, newColor);
//            args.RoutedEvent = ColorChangedEvent;
//            indicator.RaiseEvent(args);
//        }


//    }
//}

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

namespace WpfApp1
{
    /// <summary>
    /// Логика взаимодействия для ColorPicker.xaml
    /// </summary>
    public partial class ColorPicker : System.Windows.Controls.UserControl//создаем класс и наследуем от системного класса UserControl
    {
        public ColorPicker()
        {
            InitializeComponent();
        }
 
        public static DependencyProperty ColorProperty;
        public static DependencyProperty RedProperty;
        public static DependencyProperty GreenProperty;
        public static DependencyProperty BlueProperty;
       
        public static readonly RoutedEvent ColorChangedEvent;

        static ColorPicker()
        {
            // Регистрация свойств зависимости
            ColorProperty = DependencyProperty.Register("Color", typeof(Color), typeof(ColorPicker),
                new FrameworkPropertyMetadata(Colors.Black, new PropertyChangedCallback(OnColorChanged)));
            RedProperty = DependencyProperty.Register("Red", typeof(byte), typeof(ColorPicker),
                new FrameworkPropertyMetadata(new PropertyChangedCallback(OnColorRGBChanged)));
            GreenProperty = DependencyProperty.Register("Green", typeof(byte), typeof(ColorPicker),
                new FrameworkPropertyMetadata(new PropertyChangedCallback(OnColorRGBChanged)));
            BlueProperty = DependencyProperty.Register("Blue", typeof(byte), typeof(ColorPicker),
                 new FrameworkPropertyMetadata(new PropertyChangedCallback(OnColorRGBChanged)));

            // Регистрация маршрутизируемого события
            ColorChangedEvent = EventManager.RegisterRoutedEvent("ColorChanged", RoutingStrategy.Bubble,
                typeof(RoutedPropertyChangedEventHandler<Color>), typeof(ColorPicker));
        }

        //Cвойства
        public Color Color
        {
            get { return (Color)GetValue(ColorProperty); }
            set { SetValue(ColorProperty, value); }
        }
        public byte Red
        {
            get { return (byte)GetValue(RedProperty); }
            set { SetValue(RedProperty, value); }
        }
        public byte Green
        {
            get { return (byte)GetValue(GreenProperty); }
            set { SetValue(GreenProperty, value); }
        }
        public byte Blue
        {
            get { return (byte)GetValue(BlueProperty); }
            set { SetValue(BlueProperty, value); }
        }
        //Делегат события
        public event RoutedPropertyChangedEventHandler<Color> ColorChanged
        {
            add { AddHandler(ColorChangedEvent, value); }
            remove { RemoveHandler(ColorChangedEvent, value); }
        }

        //Метод для изменения цвета через RGB
        private static void OnColorRGBChanged(DependencyObject sender,
            DependencyPropertyChangedEventArgs e)
        {
            ColorPicker colorPicker = (ColorPicker)sender;
            Color color = colorPicker.Color;
            if (e.Property == RedProperty)
                color.R = (byte)e.NewValue;
            else if (e.Property == GreenProperty)
                color.G = (byte)e.NewValue;
            else if (e.Property == BlueProperty)
                color.B = (byte)e.NewValue;

            colorPicker.Color = color;
        }
        //Метод для изменения цвета через Color
        private static void OnColorChanged(DependencyObject sender,
      DependencyPropertyChangedEventArgs e)
        {
            Color newColor = (Color)e.NewValue;
            ColorPicker colorpicker = (ColorPicker)sender;
            colorpicker.Red = newColor.R;
            colorpicker.Green = newColor.G;
            colorpicker.Blue = newColor.B;

            RoutedPropertyChangedEventArgs<Color> args = new RoutedPropertyChangedEventArgs<Color>(colorpicker.Color, newColor);
            args.RoutedEvent = ColorChangedEvent;
            colorpicker.RaiseEvent(args);
        }
    }
}