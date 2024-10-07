using Newtonsoft.Json;

namespace TssRocket.UniGate.DataTransferingObjects
{
	public struct FakeUnigateSomeDTO
	{
		public int Id { get; set; }
		public required string Name { get; set; }

		[JsonProperty("life_time")]
		public int LifeTime { get; set; }
	}
}
