using System;
using System.Collections.Generic;
using Jypeli;
using Jypeli.Assets;
using Jypeli.Controls;
using Jypeli.Effects;
using Jypeli.Widgets;

public class ColorChomp : PhysicsGame
{

    int LIIKUTUSVOIMA = 1500;

    public override void Begin()
    {
        Level.CreateBorders();

        LuoPelaaja(100, 100);

        PhoneBackButton.Listen(ConfirmExit, "Lopeta peli");
        Keyboard.Listen(Key.Escape, ButtonState.Pressed, ConfirmExit, "Lopeta peli");
    }

    public void LuoPelaaja(int x, int y)
    {
        PhysicsObject pelaaja = new PhysicsObject(x, y);
        pelaaja.Shape = Shape.Circle;
        pelaaja.Color = Color.Blue;
        Add(pelaaja);

        Keyboard.Listen(Key.Up, ButtonState.Down, Liikuta, "Liikuta pelaajaa ylöspäin", pelaaja, new Vector(0, LIIKUTUSVOIMA));
        Keyboard.Listen(Key.Down, ButtonState.Down, Liikuta, "Liikuta pelaajaa alaspäin", pelaaja, new Vector(0, -LIIKUTUSVOIMA));
        Keyboard.Listen(Key.Left, ButtonState.Down, Liikuta, "Liikuta pelaajaa vasemmalle", pelaaja, new Vector(-LIIKUTUSVOIMA, 0));
        Keyboard.Listen(Key.Right, ButtonState.Down, Liikuta, "Liikuta pelaajaa oikealle", pelaaja, new Vector(LIIKUTUSVOIMA, 0));
        Keyboard.Listen(Key.Space, ButtonState.Released, VaihdaVaria, "Vaihda pelaajan väriä", pelaaja);
    }

    public void Liikuta(PhysicsObject liikutettava, Vector suunta)
    {
        liikutettava.Push(suunta);
    }

    public void VaihdaVaria(PhysicsObject kohde)
    {
        bool varivaihdettu = false;

        if (varivaihdettu == false && kohde.Color == Color.Blue)
        {
            kohde.Color = Color.Red;
            varivaihdettu = true;
        }
        if (varivaihdettu == false && kohde.Color == Color.Red)
        {
            kohde.Color = Color.Green;
            varivaihdettu = true;
        }
        if (varivaihdettu == false && kohde.Color == Color.Green)
        {
            kohde.Color = Color.Yellow;
            varivaihdettu = true;
        }
        if (varivaihdettu == false && kohde.Color == Color.Yellow)
        {
            kohde.Color = Color.Blue;
            varivaihdettu = true;
        }

    }
}
