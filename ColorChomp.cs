using System;
using System.Collections.Generic;
using Jypeli;
using Jypeli.Assets;
using Jypeli.Controls;
using Jypeli.Effects;
using Jypeli.Widgets;

public class ColorChomp : PhysicsGame
{

    const int LIIKUTUSVOIMA = 1500;
    IntMeter pisteLaskuri;

    public override void Begin()
    {

        Window.Width = 1200;
        Window.Height = 1000;
        LuoPistelaskuri();
        Level.CreateBorders(0.1, false);
        PhysicsObject pelaaja = LuoPelaaja(100, 100);
        Add(pelaaja);
        LuoVihu(100, 100, 10, pelaaja.Color);


        Keyboard.Listen(Key.Up, ButtonState.Down, Liikuta, "Liikuta pelaajaa ylöspäin", pelaaja, new Vector(0, LIIKUTUSVOIMA));
        Keyboard.Listen(Key.Down, ButtonState.Down, Liikuta, "Liikuta pelaajaa alaspäin", pelaaja, new Vector(0, -LIIKUTUSVOIMA));
        Keyboard.Listen(Key.Left, ButtonState.Down, Liikuta, "Liikuta pelaajaa vasemmalle", pelaaja, new Vector(-LIIKUTUSVOIMA, 0));
        Keyboard.Listen(Key.Right, ButtonState.Down, Liikuta, "Liikuta pelaajaa oikealle", pelaaja, new Vector(LIIKUTUSVOIMA, 0));
        Keyboard.Listen(Key.Space, ButtonState.Pressed, VaihdaVaria, "Vaihda pelaajan väriä", pelaaja);
        PhoneBackButton.Listen(ConfirmExit, "Lopeta peli");
        Keyboard.Listen(Key.Escape, ButtonState.Pressed, ConfirmExit, "Lopeta peli");

        AddCollisionHandler(pelaaja, "vihu", CollisionHandler.DestroyTarget);
        AddCollisionHandler(pelaaja, "vihu",  CollisionHandler.AddMeterValue(pisteLaskuri, 1));
    }



    public void LuoPistelaskuri()
    {
        pisteLaskuri = new IntMeter(0);

        Label pisteNaytto = new Label();
        pisteNaytto.X = Level.Left + 100;
        pisteNaytto.Y = Level.Top - 100;
        pisteNaytto.TextColor = Color.Black;
        pisteNaytto.Color = Color.White;

        pisteNaytto.BindTo(pisteLaskuri);
        Add(pisteNaytto);
    }

    public void LuoVihu(double leveys, double korkeus, double maara, Color pelaajanvari)
    {
        int i = 0;
        while (i < maara)
        {
            PhysicsObject vihu = new PhysicsObject(leveys, korkeus);
            
            vihu.Shape = Shape.Ellipse;
            vihu.Color = RandomGen.SelectOne<Color>(Color.Blue, Color.Green, Color.Red, Color.Yellow);
            vihu.Position = RandomGen.NextVector(Level.Left, Level.Right);
            vihu.Tag = "vihu";
            Add(vihu);
            i++;
        }
    }


    public PhysicsObject LuoPelaaja(int x, int y)
    {
        PhysicsObject pelaaja = new PhysicsObject(x, y);
        pelaaja.Shape = Shape.Circle;
        pelaaja.Color = Color.Blue;

        return pelaaja;
    }

    public void Liikuta(PhysicsObject liikutettava, Vector suunta)
    {
        liikutettava.Push(suunta);
    }

    public void VaihdaVaria(PhysicsObject kohde)
    {

        if (kohde.Color == Color.Blue)
        {
            kohde.Color = Color.Red;
        }
        else if(kohde.Color == Color.Red)
        {
            kohde.Color = Color.Green;
        }
        else if(kohde.Color == Color.Green)
        {
            kohde.Color = Color.Yellow;
        }
        else if (kohde.Color == Color.Yellow)
        {
            kohde.Color = Color.Blue;
        }

    }
}
