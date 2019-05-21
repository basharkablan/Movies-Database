using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Serie
/// </summary>
public class Serie
{
    private int id;
    private string serie;

	public Serie(int id, string serie)
	{
        this.id = id;
        this.serie = serie;
	}
    public int GetID()
    {
        return this.id;
    }

    public string GetSerie()
    {
        return this.serie;
    }
}
