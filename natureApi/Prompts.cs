namespace natureApi;

public class Prompts
{
    public static string GeneratePlacesPrompt(string jsonData)
    {
        return $@"
        Eres un analista experto en turismo de naturaleza y senderismo.

        Analiza los siguientes datos de lugares, senderos y amenidades en formato JSON:
        {jsonData}

        Debes responder EXCLUSIVAMENTE en formato JSON con la siguiente estructura:

        {{
          ""topCategories"": [{{""name"": ""string"", ""count"": int}}],
          ""difficultyStats"": {{
            ""easy"": int,
            ""moderate"": int,
            ""hard"": int
          }},
          ""accessiblePercentage"": double,
          ""highlightPlaces"": [""string""],
          ""patterns"": [""string""]
        }}

        En ""patterns"" incluye observaciones como:
        - Qué tipo de dificultad es más común.
        - Qué porcentaje aproximado de lugares son accesibles.
        - Cualquier patrón interesante sobre ubicaciones, entrada, horarios, etc.

        Si por alguna razón NO puedes generar una respuesta válida con ese JSON
        (por ejemplo, falta de datos o error en el formato),
        responde SOLO con el texto: error

        NO me saludes, NO des explicaciones extra, NO agregues texto fuera del JSON.
        ";
    }
    
    public static string GenerateTrailsPrompt(string jsonData)
    {
        return $@"
        Eres un analista experto en senderismo y rutas de naturaleza.

        Analiza los siguientes datos de senderos en formato JSON:
        {jsonData}

        Debes responder EXCLUSIVAMENTE en formato JSON con la siguiente estructura:

        {{
          ""totalTrails"": int,
          ""averageDistanceKm"": double,
          ""averageTimeMinutes"": double,
          ""difficultyCounts"": {{
            ""easy"": int,
            ""moderate"": int,
            ""hard"": int
          }},
          ""loopPercentage"": double,
          ""notableTrails"": [
            {{
              ""name"": ""string"",
              ""placeName"": ""string"",
              ""reason"": ""string""
            }}
          ],
          ""patterns"": [""string""]
        }}

        En ""notableTrails"" incluye senderos que destaquen por distancia, tiempo, dificultad o cualquier característica interesante.
        En ""patterns"" incluye observaciones como:
        - Qué dificultad es más frecuente.
        - Si la mayoría son loops o no.
        - Si hay patrones en distancia/tiempo (por ejemplo, la mayoría son cortos y fáciles).

        Si NO puedes generar una respuesta válida con ese JSON
        (por ejemplo, falta de datos o error en el formato),
        responde SOLO con el texto: error

        NO me saludes, NO des explicaciones extra, NO agregues texto fuera del JSON.
        ";
    }

}