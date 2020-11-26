using System;
using System.Collections.Generic;
using System.Text;

namespace MAD_Superfit
{


    public class Request
    {
        public string q { get; set; }
        public int from { get; set; }
        public int to { get; set; }
        public bool more { get; set; }
        public int count { get; set; }
        public Hit[] hits { get; set; }
    }

    public class Hit
    {
        public Recipe recipe { get; set; }
        public bool bookmarked { get; set; }
        public bool bought { get; set; }
    }

    public class Recipe
    {
        public string uri { get; set; }
        public string label { get; set; }
        public string image { get; set; }
        public string source { get; set; }
        public string url { get; set; }
        public string shareAs { get; set; }
        public float yield { get; set; }
        public string[] dietLabels { get; set; }
        public string[] healthLabels { get; set; }
        public string[] cautions { get; set; }
        public string[] ingredientLines { get; set; }
        public Ingredient[] ingredients { get; set; }
        public float calories { get; set; }
        public float totalWeight { get; set; }
        public float totalTime { get; set; }
        public Dictionary<String, Nurtient> totalNutrients { get; set; }
        public Dictionary<String, Dictionary<String, String>> totalDaily { get; set; }
        public Digest[] digest { get; set; }
        
    }

    public class Nurtient
    {
        public string label { get; set; }
        public float quantity { get; set; }
        public string unit{ get; set; }
    }

    public class Ingredient
    {
        public string text { get; set; }
        public float weight { get; set; }
        public string image { get; set; }
    }

    public class Digest
    {
        public string label { get; set; }
        public string tag { get; set; }
        public string schemaOrgTag { get; set; }
        public float total { get; set; }
        public bool hasRDI { get; set; }
        public float daily { get; set; }
        public string unit { get; set; }
        public Sub[] sub { get; set; }
    }

    public class Sub
    {
        public string label { get; set; }
        public string tag { get; set; }
        public string schemaOrgTag { get; set; }
        public float total { get; set; }
        public bool hasRDI { get; set; }
        public float daily { get; set; }
        public string unit { get; set; }
    }

}
