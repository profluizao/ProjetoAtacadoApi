using Atacado.Envelope.Ancestral;
using Newtonsoft.Json;

namespace Atacado.Envelope.Auxiliar
{
    public class AquiculturaEnvelopeJSON : BaseEnvelopeJSON
    {
		[JsonProperty(PropertyName = "IdAquicultura")]
		public int IdAquicultura { get; set; }

		[JsonProperty(PropertyName = "Ano")]
		public int Ano { get; set; }

		[JsonProperty(PropertyName = "IdMunicipio")]
		public int IdMunicipio { get; set; }

		[JsonProperty(PropertyName = "IdTipoAquicultura")]
		public int IdTipoAquicultura { get; set; }

		[JsonProperty(PropertyName = "Producao")]
		public int? Producao { get; set; }

		[JsonProperty(PropertyName = "ValorProducao")]
		public int? ValorProducao { get; set; }

		[JsonProperty(PropertyName = "ProporcaoValorProducao")]
		public double? ProporcaoValorProducao { get; set; }

		[JsonProperty(PropertyName = "Moeda")]
		public string Moeda { get; set; }

        public override void SetLinks()
        {
			this.Links.List = "GET /empresa";
			this.Links.Self = "GET /empresa/" + this.IdAquicultura.ToString();
			this.Links.Exclude = "DELETE /empresa/" + this.IdAquicultura.ToString();
			this.Links.Update = "PUT /empresa";
			this.Links.Create = "POST /empresa";
		}
    }
}
