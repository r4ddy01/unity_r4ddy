using System;

public class Sorteio
{
    string[] cartasPaus = {
        "Ás", "2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K"
    };
    
    public void SortearCarta()
    {
        Random rng = new Random();
        
        for (int i = 0; i < cartasPaus.Length; i++)
        {
            int j = rng.Next(i, cartasPaus.Length);
            string temp = cartasPaus[i];
            cartasPaus[i] = cartasPaus[j];
            cartasPaus[j] = temp;
        }
        
        
        string cartaSorteada = cartasPaus[rng.Next(cartasPaus.Length)];
        
        
        string tipo = "";
        if (cartaSorteada == "J" || cartaSorteada == "Q" || cartaSorteada == "K")
        {
            tipo = "figura (letra)";
        }
        else
        {
            tipo = "nao figura";
        }
        
        Console.WriteLine("Carta sorteada: " + cartaSorteada + " de paus");
        Console.WriteLine("Tipo: " + tipo);
    }
    
    public static void Main(string[] args)
    {
        Sorteio jogo = new Sorteio();
        jogo.SortearCarta();
    }
}
