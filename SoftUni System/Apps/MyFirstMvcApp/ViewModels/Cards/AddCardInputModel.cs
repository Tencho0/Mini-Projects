﻿namespace BattleCards.ViewModels.Cards;

public class AddCardInputModel
{
    public int Attack { get; set; }

    public int Health { get; set; }

    public string Description { get; set; }

    public string Name { get; set; }

    public string ImageUrl { get; set; }

    public string Keyword { get; set; }
}