
[System.Serializable]
public class Noticia
{
    public string noticia;
    public bool esFalsa;
}

[System.Serializable]
public class Pregunta
{
    public Noticia[] noticies;
    public bool acertat;
}
