using System;
using Xamarin.Forms;
using SkiaSharp.Views.Forms;
using SkiaSharp;

namespace Menghi.Massimo._4H.RiassuntoSkia
{

    public partial class MainPage : ContentPage
    {
        //ESISTO ANCHE IO --Liam
        public int MARGINE_SINISTRO { get; set; } = 100;
        public int MARGINE_SOPRA { get; set; } = 100;
        public int LARGHEZZA_RETTANGOLO { get; set; } = 200;
        public int ALTEZZA_RETTANGOLO { get; set; } = 300;

        SKPath Path { get; set; }
        public MainPage()
        {
            InitializeComponent();
        }

        private void btnDisegno_Clicked(object sender, EventArgs e)
        {
            Path = new SKPath();

            disegnaRettangolo();
            disegnaDiagonali();

            Tela.InvalidateSurface();

            //double xDispositivo = trasformaXfoglio(xFoglio);
            //double yDispositivo = trasformaYfoglio(yFoglio);

            //disegnaRettangolo(xDispositivo, yDispositivo);

        }
        private void disegnaRettangolo()
        {
            double xEDispositivo = MARGINE_SINISTRO;
            double yEDispositivo = MARGINE_SOPRA;
            double xFDispositivo = MARGINE_SINISTRO+LARGHEZZA_RETTANGOLO;
            double yFDispositivo = MARGINE_SOPRA;
            double xGDispositivo = MARGINE_SOPRA+LARGHEZZA_RETTANGOLO;
            double yGDispositivo = MARGINE_SOPRA+ALTEZZA_RETTANGOLO;
            double xHDispositivo = MARGINE_SINISTRO;
            double yHDispositivo = MARGINE_SOPRA+ALTEZZA_RETTANGOLO;
            

            disegnaSegmento(xEDispositivo, yEDispositivo, xFDispositivo, yFDispositivo);
            disegnaSegmento(xFDispositivo, yFDispositivo, xGDispositivo, yGDispositivo);
            disegnaSegmento(xGDispositivo, yGDispositivo, xHDispositivo, yHDispositivo);
            disegnaSegmento(xHDispositivo, yHDispositivo, xEDispositivo, yEDispositivo);
        }
        private void disegnaDiagonali()
        {
            double xFFoglio = 0;
            double yFFoglio = 0;
            double xHFoglio = 200;
            double yHFoglio = 300;

            disegnaSegmentoSulFoglio(xFFoglio, yFFoglio, xHFoglio, yHFoglio);
        }
        private void disegnaSegmento(double x1, double y1, double x2, double y2)
        {
            SKPoint p1 = new SKPoint((float)x1, (float)y1);
            SKPoint p2 = new SKPoint((float)x2, (float)y2);
            Path.MoveTo(p1);
            Path.LineTo(p2);
        }
        private void disegnaSegmentoSulFoglio(double x1, double y1, double x2, double y2)
        {
            double x1Dispositivo = trasformaXfoglio(x1);
            double y1Dispositivo = trasformaYfoglio(y1);
            double x2Dispositivo = trasformaXfoglio(x2);
            double y2Dispositivo = trasformaYfoglio(y2);

            SKPoint p1 = new SKPoint((float)x1Dispositivo, (float)y1Dispositivo);
            SKPoint p2 = new SKPoint((float)x2Dispositivo, (float)y2Dispositivo);
            Path.MoveTo(p1);
            Path.LineTo(p2);
        }
        private double trasformaXfoglio(double x)
        {
            return x+MARGINE_SINISTRO;
        }
        private double trasformaYfoglio(double y)
        {
            return MARGINE_SOPRA + ALTEZZA_RETTANGOLO-y;
        }
        private void SKCanvasView_PaintSurface(object sender, SKPaintSurfaceEventArgs e)
        {
            var info = e.Info;
            //var surface = e.Surface;
            var canvas = e.Surface.Canvas;
            canvas.Clear();

            //int larghezza = info.Rect.Width; //1200
            //int altezza = info.Rect.Height; //794
            SKPaint Pennello = new SKPaint
            {
                Style = SKPaintStyle.Stroke,
                Color = SKColors.White,
                StrokeWidth = 3
            };
            if(Path!=null)
                canvas.DrawPath(Path, Pennello);
        }
        //SKPath AreaDelDisegno()
        //{
        //    SKPath rettangolo = new SKPath();
        //    rettangolo.MoveTo();
        //    return;
        //}
    }
}
