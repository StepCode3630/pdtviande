using System;
using backend.context;
using backend.models;
using Bogus;

namespace backend.Fakers;

public class RecipeFaker : Faker<Recipe>
{
    public RecipeFaker()
    {
        RuleFor(r => r.Name, f => f.Lorem.Word());
        RuleFor(r => r.Summary, f => f.Lorem.Sentence());
        RuleFor(r => r.Ingredients, f => f.Lorem.Words(5).ToArray());
        RuleFor(r => r.Instructions, f => f.Lorem.Words(5).ToArray());
        RuleFor(r => r.CreatedAt, f => f.Date.Past().ToUniversalTime());
        RuleFor(r => r.UpdatedAt, f => f.Date.Recent().ToUniversalTime());
        RuleFor(r => r.ImageUrl, f => f.Image.PicsumUrl());
    }
}
