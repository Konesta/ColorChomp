using System;
using System.Collections.Generic;
using Jypeli;
using Jypeli.Assets;
using Jypeli.Controls;
using Jypeli.Effects;
using Jypeli.Widgets;

public class ColorChomp : PhysicsGame
{
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
        pelaaja.Mass = 10.0;
        Add(pelaaja);

        Keyboard.Listen(Key.Up, ButtonState.Down, Liikuta, "Liikuta pelaajaa ylöspäin", pelaaja, new Vector(1000, 0));
    }

    public void Liikuta(PhysicsObject liikutettava, Vector suunta)
    {
        liikutettava.Push(suunta);
    }
}
